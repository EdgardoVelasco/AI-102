using System;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
namespace Modulo4SpeechService
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicio = speech.SpeechClient.Speech;
            Console.WriteLine("Habla en el micrófono");
            reconociendoVoz(servicio);
            Console.ReadKey();

        }

        private static async void reconociendoVoz(SpeechConfig speech) {
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            var speechRecogn = new SpeechRecognizer(speech, "es-MX", audioConfig);
            var respuesta = await speechRecogn.RecognizeOnceAsync();
            Console.WriteLine($"Texto reconocido: {respuesta.Text}");
        }
    }
}
