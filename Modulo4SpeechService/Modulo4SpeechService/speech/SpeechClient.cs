using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CognitiveServices.Speech;

namespace Modulo4SpeechService.speech
{
    /*Esta clase se usa para conectarnos al servicio
     * de Speech en azure
    */
    class SpeechClient
    {
        /*APIKEY y ENDPOINT lo extraigo del portal de Azure*/
        private static readonly string APIKEY = "4a3caeeed30b4120a631a25ec63158c0";
        private static readonly string ENDPOINT = "https://eastus.api.cognitive.microsoft.com/sts/v1.0/issuetoken";

        /*Variable necesaria para usar el servicio
         en cualquier parte de mi proyecto*/

        public static SpeechConfig Speech { get; private set; }

        /*Constructor usado para inicializar nuestro servicio de speech*/
        static SpeechClient() { Init(); }

        private static void Init() {
            if (Speech==null) {
                Speech = SpeechConfig.FromEndpoint(new Uri(ENDPOINT), APIKEY);
            }
        }

    }
}
