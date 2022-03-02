using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace ComputerVC.Computer
{
    class ComputerClient
    {
        private static readonly string API_KEY = "c078b918334f43b68874242ed964fbc6";
        private static readonly string ENDPOINT = "https://computerenvf.cognitiveservices.azure.com/";
        public static ComputerVisionClient Computer { get; private set; }

        static ComputerClient() { InitComputer(); }

        private static void InitComputer() {
            if (Computer== null) {
                var credenciales = new ApiKeyServiceClientCredentials(API_KEY);
                Computer = new ComputerVisionClient(credenciales) { Endpoint= ENDPOINT};
            }
        }
    }
}
