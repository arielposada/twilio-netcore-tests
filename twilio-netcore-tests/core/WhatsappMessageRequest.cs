using System.Security.Principal;

namespace core
{
    /// <summary>
    /// Model for the whatsapp message to be sent.
    /// Based on the example of https://www.twilio.com/docs/whatsapp/quickstart/csharp
    /// </summary>
    public class WhatsappMessageRequest
    {
        public string body { get; set; }

        public string from { get; set; }
        public string to { get; set; }

        public WhatsappMessageRequest(string body, string from, string to)
        {
            if (!(from.IsTelephoneNumber() && to.IsTelephoneNumber()))
                throw new ArgumentException("Not a telephone number");
            this.body = body;
            this.from = from;
            this.to = to;
        }

    }
}