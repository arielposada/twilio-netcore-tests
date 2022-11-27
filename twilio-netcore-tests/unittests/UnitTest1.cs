using core;
using logic;
using Microsoft.Extensions.Configuration;
using Twilio;

namespace unittests
{
    public class Tests
    {
        private readonly IConfiguration _configuration;
        public Tests()
        {
            _configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(@"appsettings.json", false, false)
               .Build();
        }

        [SetUp]
        public void Setup()
        {

        }

        //Tests a message to be sent
        [Test]
        public void Test1()
        {
            var accountId = _configuration.GetSection("Twilio:AcccountId").Value;
            var accessToken = _configuration.GetSection("Twilio:AuthToken").Value;

            var from = _configuration.GetSection("WhatsappTest:from").Value;
            var to = _configuration.GetSection("WhatsappTest:to").Value;
            var body = _configuration.GetSection("WhatsappTest:body").Value;


            var messageRequest = new MessageRequest(body, from, to);

            var twilioClient = new TwilioClientService(accountId, accessToken);

            var messageId = twilioClient.SendMessageSMS(messageRequest).Result;

            Assert.IsNotNull(messageId);

            Assert.Pass();
        }
    }
}