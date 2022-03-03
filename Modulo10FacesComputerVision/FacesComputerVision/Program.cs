using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FacesComputerVision
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Conexión a Computer Vision*/
            var vision = computer.ComputerService.Vision;
            Console.WriteLine("URL de imagen local: ");
            var url = Console.ReadLine();
            GetFaces(url, vision);
            Console.ReadKey();
        }

        private static async void GetFaces(string url, ComputerVisionClient servicio) {
            using (var imagen=File.OpenRead(url)) {
                IList<VisualFeatureTypes?> feature = new List<VisualFeatureTypes?>() { 
                    VisualFeatureTypes.Faces
                };

                var respuesta = await servicio.AnalyzeImageInStreamAsync(imagen, feature, language:"es");

                var rostros = respuesta.Faces;
                Console.WriteLine($"Se han encontrado {rostros.Count} rostros\n");
                rostros.ToList()
                    .ForEach(t=> {
                        StringBuilder cadena = new StringBuilder();
                        cadena.Append("-.-.-.Rostro-.-.-.-.\n")
                        .Append("Genero: ").Append(t.Gender).Append("\n")
                        .Append("Edad: ").Append(t.Age).Append("\n")
                        .Append("-.-.-.Ubicación-.-.-.\n")
                        .Append("left: ").Append(t.FaceRectangle.Left).Append("\n")
                        .Append("top: ").Append(t.FaceRectangle.Top).Append("\n")
                        .Append("width: ").Append(t.FaceRectangle.Width).Append("\n")
                        .Append("height: ").Append(t.FaceRectangle.Height).Append("\n")
                        .Append("-.-.-.-.-.-.-.-.-.-.\n");
                        Console.WriteLine(cadena.ToString());
                    });

            
            }
        }



    }
}
