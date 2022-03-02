using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading;

namespace ComputerVC.Computer
{
    class ComputerServices
    {
        private static readonly ComputerVisionClient CLIENTE = ComputerClient.Computer;

        public async static Task DescribeImagen(string url) {
            using (var imagen = File.OpenRead(url))
            {
                var result = await CLIENTE.DescribeImageInStreamAsync(imagen, language: "es");
                var captions = result.Captions;
                var tags = result.Tags;
                Console.WriteLine("-.-.-.-.-.-.Captions-.-.-.-.-.-.");
                captions.ToList().ForEach(t => Console.WriteLine(t.Text));
                Console.WriteLine("-.-.-.-.-.-.-Tags-.-.-.-.-.");
                tags.ToList().ForEach(t => Console.WriteLine(t));
            }
        }

        public async static Task Rostros(string url) {
            using (var imagen=File.OpenRead(url)) {
                IList<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                   VisualFeatureTypes.Faces
                };
                var resultado = await CLIENTE.AnalyzeImageInStreamAsync(imagen, features, language:"es");
                var faces = resultado.Faces;
                
                faces.ToList().ForEach(t => {
                    StringBuilder build = new StringBuilder();
                    build.Append("age:  ").Append(t.Age).Append("\n")
                    .Append("Genero: ").Append(t.Gender).Append("\n")
                    .Append("-*-*-*Rectangule-*-*-*\n")
                    .Append("left: ").Append(t.FaceRectangle.Left).Append("\n")
                    .Append("top: ").Append(t.FaceRectangle.Top).Append("\n")
                    .Append("width: ").Append(t.FaceRectangle.Width).Append("\n")
                    .Append("height: ").Append(t.FaceRectangle.Height).Append("\n");
                    Console.WriteLine(build.ToString());
                });


            }

        }


        public async static Task Colores(string url) {
            using (var imagen=File.OpenRead(url)) {
                IList<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                   VisualFeatureTypes.Color
                };
                var resultado = await CLIENTE.AnalyzeImageInStreamAsync(imagen, features, language: "es");
                var colors = resultado.Color;
                Console.WriteLine($"color dominante-background {colors.DominantColorBackground}");
                Console.WriteLine($"color dominante-foreground {colors.DominantColorForeground}");
              
                Console.WriteLine("-*-*-*colores dominantes-*-*-* ");
                colors.DominantColors.ToList().ForEach(t => Console.WriteLine($"color: {t}"));

            }
        }

        public async static Task Adulto(string url)
        {
            using (var imagen = File.OpenRead(url))
            {
                IList<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                   VisualFeatureTypes.Adult
                };
                var resultado = await CLIENTE.AnalyzeImageInStreamAsync(imagen, features, language: "es");
                var adult = resultado.Adult;
                Console.WriteLine($"es contenido para adulto: {adult.IsAdultContent}");
                Console.WriteLine($"score adult {adult.AdultScore}");


            }
        }

       
    }
}
