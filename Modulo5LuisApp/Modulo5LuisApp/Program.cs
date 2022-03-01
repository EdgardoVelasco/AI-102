using System;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Newtonsoft.Json.Linq;
namespace Modulo5LuisApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Conexión de servicio LUIS*/
            var servicio = luis.LuisClient.Luis;
            GetIntent(servicio);
            Console.ReadKey();
        }

        private static async void GetIntent(LUISRuntimeClient luis) {
            var appId = "d8a12324-a9d1-40f0-8cd1-72f121a31fc7";
            Console.WriteLine("Escribe un mensaje: ");
            var texto = Console.ReadLine();
            var request = new PredictionRequest
            {
                Query = texto
            };
            var resultado = await luis.Prediction.GetSlotPredictionAsync(Guid.Parse(appId), 
                slotName:"Staging", request);

            switch (resultado.Prediction.TopIntent) {
                case "EnviarCorreo":
                    Console.WriteLine("se ha reconocido Enviar correo");
                    var entities = resultado.Prediction.Entities;
                    var correo = entities["correo"];
                    Console.WriteLine($"Enviando correo a {((JArray)correo)[0]}");
                    break;
                case "LlamarTelefono":
                    Console.WriteLine("se ha reconocido Llamar por telefono");
                    var entities2 = resultado.Prediction.Entities;
                    var telefono = entities2["telefono"];
                    Console.WriteLine($"Llamando al número {((JArray)telefono)[0]}");
                    break;
                default:
                    Console.WriteLine("No se reconoce ninguna intención");
                    break;
            
            }

        }
    }
}
