using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading;

namespace Modulo11ComputerVOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Computer vision conexión*/
            var vision = computer.ComputerService.Vision;
            Console.WriteLine("-.-.-.Lectura de Texto en imagenes-.-.-.");
            Console.WriteLine("url de imagen local: ");
            var url = Console.ReadLine();
            GetTextInImg(url, vision);
            Console.ReadKey();

        }
        public static async void GetTextInImg(string url, ComputerVisionClient servicio) {
            /*Convierto la img en bits*/
            var imgB = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.Read);

            /*Enviamos la imagen a OCR*/
            var respuesta = await servicio.ReadInStreamAsync(imgB, language:"es");
            Thread.Sleep(2000);

            /*Obtenemos el id de la operación*/
            int caracteres = 36;
            string textoCompleto = respuesta.OperationLocation;
            string idOperacion = textoCompleto.Substring(textoCompleto.Length-caracteres);

            /*Extraer el resultado de OCR*/
            ReadOperationResult resultado;
            Console.WriteLine("-*-*-*Extrayendo Texto de OCR-*-*-*-*");
            do {
                resultado = await servicio.GetReadResultAsync(Guid.Parse(idOperacion));

            } while ((resultado.Status==OperationStatusCodes.Running)||
            (resultado.Status==OperationStatusCodes.NotStarted));


            /*Imprimiendo resultados de OCR*/
            Console.WriteLine("-*-*-*Se ha completado OCR-*-*-*-*\n");
            var salida = resultado.AnalyzeResult.ReadResults;
            foreach (var page in salida) {
                foreach (var linea in page.Lines) {
                    Console.WriteLine(linea.Text);
                }
            }
            Console.WriteLine("-*-*-*fin de resultados-*-*-*-*");

        }

    }
}
