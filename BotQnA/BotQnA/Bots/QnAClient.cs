using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.AI.QnA;

namespace BotQnA.Bots
{
    /*Esta clase se conecta al servicio de 
     * QnAMaker de Azure
     */
    public class QnAClient
    {
        /*ENDPOINTKEY, KBID y HOST: Se obtiene del portal de QnAMaker*/
        private static string ENDPOINTKEY = "e0276009-5318-49fb-981a-7b78448c9529";
        private static string KBID = "6e617c8a-95a1-45ec-84af-c705ae13d476";
        private static string HOST = "https://qnamakerenvf.azurewebsites.net/qnamaker";

        /*Variable usada para poder obtener el servicio de QnA en cualquier
         parte de nuestro proyecto*/
        public static QnAMaker QnA { get; private set; }

        static QnAClient() { Init(); }

        private static void Init() {
            if (QnA==null) {
                var credencial = new QnAMakerEndpoint { 
                   EndpointKey=ENDPOINTKEY,
                   KnowledgeBaseId=KBID,
                   Host=HOST
                };
                QnA = new QnAMaker(credencial);
            }
        }

    }
}
