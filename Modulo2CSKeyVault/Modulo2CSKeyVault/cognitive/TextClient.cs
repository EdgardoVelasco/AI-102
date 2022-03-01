using System;
using System.Collections.Generic;
using System.Text;
using Azure;
using Azure.AI.TextAnalytics;
namespace Modulo2CSKeyVault.cognitive
{
    /*Esta clase es usada
     para conectarnos a nuestro servicio cognitivo*/
    class TextClient
    {
        /*ENDPOINT: lo extraigo del overview de el servicio cognitivo*/
        private static readonly string ENDPOINT = "https://cognitivenvfne.cognitiveservices.azure.com/";

        /*Vairable usada para usar a TextAnalytics en cualquier parte de nuestro código*/
        public static TextAnalyticsClient Text { get; private set; }

        /*Constructor: Usado para inicializar nuestro Text Analytics*/
        static TextClient() { Init(); }

        /*Método usado para obtener el api key de Key Vault y realizar
         la conexión a TextAnalytics*/

        private static void Init() {
            if (Text==null) {
                var credencial = new AzureKeyCredential(keyvault.KeyClient.Secret
                    .GetSecret("cognitivek1").Value.Value);
                Text = new TextAnalyticsClient(new Uri(ENDPOINT), credencial);
            }
        }


        

    }
}
