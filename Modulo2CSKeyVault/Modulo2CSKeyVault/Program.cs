using System;

namespace Modulo2CSKeyVault
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Obteniendo el servicio Cognitivo*/
            var servicio = cognitive.TextClient.Text;
            Console.WriteLine("Escribe un texto: ");
            var texto = Console.ReadLine();
            var resultado = servicio.DetectLanguage(texto);
            Console.WriteLine($"idioma: {resultado.Value.Name}");
            Console.WriteLine($"ISO: {resultado.Value.Iso6391Name}");
            Console.WriteLine($"Confidence: {resultado.Value.ConfidenceScore}");

        }
    }
}
