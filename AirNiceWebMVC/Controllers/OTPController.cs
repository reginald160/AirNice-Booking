using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Accounts.V1;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Jwt.AccessToken;


namespace AirNiceWebMVC.Controllers
{
    public class OTPController : Controller
    {
        public IActionResult SendSMS()
        {
            const string identity = "user@example.com";
            var grant = new ChatGrant
            {
                ServiceSid = "serviceSid"
            };

            var grants = new HashSet<IGrant>
        {
            { grant }
        };


            //var token = new Token(
            //twilioAccountSid,
            //twilioApiKey,
            //twilioApiSecret,
            //identity,
            //grants: grants);


            var tokene = new Token(
    "",
    "",
    "",
    "",
    grants: grants);



            var accountId = ConfigurationManager.AppSettings["TwilioId"];
            var token = ConfigurationManager.AppSettings["TwilioToken"];

            TwilioClient.Init(accountId, token);
            var to = new PhoneNumber("");
            var from = new PhoneNumber(ConfigurationManager.AppSettings["SystemPhoneNumber"]);
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: $"Your verification number {to}"
                );

            return (IActionResult)Content(message.Sid);
        }
    }
}
