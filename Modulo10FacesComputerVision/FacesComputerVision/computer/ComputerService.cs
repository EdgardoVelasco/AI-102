using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace FacesComputerVision.computer
{
    /*Estta clase es usada para conectarnos a Computer Vision*/
    class ComputerService
    {
        /*ENDPOINT & APIKEY: Los extraemos del portal de azure 
         en el servicio Computer Vision 'Keys and Endpoint'*/
        private static readonly string ENDPOINT = "https://computerenvf.cognitiveservices.azure.com/";
        private static readonly string APIKEY = "c078b918334f43b68874242ed964fbc6";

        public static ComputerVisionClient Vision { get; private set; }

        static ComputerService() { Init(); }

        private static void Init() {
            if (Vision==null) {
                var credencial = new ApiKeyServiceClientCredentials(APIKEY);
                Vision = new ComputerVisionClient(credencial) { Endpoint=ENDPOINT};
            }
        
        }

    }
}
