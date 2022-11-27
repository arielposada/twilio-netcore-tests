using core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace logic
{
    /// <summary>
    /// Twilio client
    /// </summary>
    public class TwilioClientService : IDisposable
    {
        public TwilioClientService(string accountSid, string authToken)
        {
            TwilioClient.Init(accountSid, authToken);
        }

        /// <summary>
        /// Send a message with Twilio
        /// </summary>
        /// <param name="messageRequest">Message request</param>
        /// <returns>Message Id as String</returns>
        public async Task<string> SendMessage(MessageRequest messageRequest) 
        {
            //Taken from the example in: https://www.twilio.com/docs/libraries/csharp-dotnet/details
            var message = await MessageResource.CreateAsync(
                body: messageRequest.body,
                from: new Twilio.Types.PhoneNumber("whatsapp:"+messageRequest.from),
                to: new Twilio.Types.PhoneNumber("whatsapp:"+messageRequest.to)
            );

            return message.Sid;
        }

        /// <summary>
        /// Send a message with Twilio
        /// </summary>
        /// <param name="messageRequest">Message request</param>
        /// <returns>Message Id as String</returns>
        public async Task<string> SendMessageSMS(MessageRequest messageRequest)
        {
            //Taken from the example in: https://www.twilio.com/docs/libraries/csharp-dotnet/details
            var message = await MessageResource.CreateAsync(
                body: messageRequest.body,
                from: new Twilio.Types.PhoneNumber(messageRequest.from),
                to: new Twilio.Types.PhoneNumber(messageRequest.to)
            );

            return message.Sid;
        }

        public void Dispose() { }
    }
}
