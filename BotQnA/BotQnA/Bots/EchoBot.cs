// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.15.2

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BotQnA.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            /*Conexión a Servicio de QnAMaker*/
            var qna = QnAClient.QnA;

            /*Enviar a QnAMaker la pregunta del usuario*/
            var respuesta = await qna.GetAnswersAsync(turnContext);

            /*Validando respuesta de QnAMaker*/
            if (respuesta!=null && respuesta.Length>0) {
                await turnContext.SendActivityAsync(MessageFactory
                    .Text(respuesta[0].Answer));
            
            }

           
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Bienvenido a mi Bot QnA";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
