// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.15.2

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MiPrimerBot.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            /*Obtengo el texto del usuario*/
            var texto = turnContext.Activity.Text.ToLower();

            switch (texto) {
                case "hola": case "whats up!": case "hi":
                    await turnContext.SendActivityAsync(MessageFactory.Text("Hola :)"));
                    break;

                case "que haces?": case "que eres?":
                    await turnContext.SendActivityAsync(MessageFactory.Text("Soy un bot :("));
                    break;

                default:
                    await turnContext.SendActivityAsync(MessageFactory.Text("Soy un bot sencillo, y" +
                        " no entiendo muchas cosas"));
                    break;
            }

        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Bienvenido a mi Bot :)";
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
