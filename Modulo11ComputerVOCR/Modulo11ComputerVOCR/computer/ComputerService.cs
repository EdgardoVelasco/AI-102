using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace Modulo11ComputerVOCR.computer
{
    class ComputerService
    {
        private static readonly string ENDPOINT = "https://computerenvf.cognitiveservices.azure.com/";
        private static readonly string APIKEY = "c078b918334f43b68874242ed964fbc6";
        public static ComputerVisionClient Vision { get; private set; }

        static ComputerService() { Init(); }

        private static void Init(){
            if (Vision==null) {
                var credenciales = new ApiKeyServiceClientCredentials(APIKEY);
                Vision = new ComputerVisionClient(credenciales) { Endpoint=ENDPOINT};
            }
        }

    }
}
