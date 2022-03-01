using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;

namespace Modulo5LuisApp.luis
{
    /*Esta clase se conecta al servicio de LUIS*/
    class LuisClient
    {
        /*APIKEY & ENDPOINT se extraen de la plataforma de LUIS*/
        private static readonly string APIKEY = "d3f0398a82644c3686d16a79c630b196";
        private static readonly string ENDPOINT = "https://westus.api.cognitive.microsoft.com/";

        /*Variable necesaria para poder usar a LUIS en cualquier
         parte de nuestro proyecto*/
        public static LUISRuntimeClient Luis { get; private set; }

        static LuisClient() { Init(); }

        private static void Init() {
            if (Luis==null) {
                var credenciales = new ApiKeyServiceClientCredentials(APIKEY);
                Luis = new LUISRuntimeClient(credenciales) {Endpoint=ENDPOINT};

            }
        }


    }
}
