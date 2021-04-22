
using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Utility.CoreHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting.Internal;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
using Microsoft.AspNetCore.WebUtilities;

namespace EasyBanking.Utility.CoreHelpers
{
    public static class LogicHelper
    {
        [Obsolete]
        public static IHostingEnvironment Path;
        private static IWebHostEnvironment _hostEnvironment;
        public const string EmpSuffix = "Emp";
        public const string FirstUser = "Employee";
        public const string ColorGrey = "#808080";
        public static ApplicationDbContext context;
        //private readonly ApplicationDbContext _context;

        public static string imagepath(IFormFile model)
        {
            var imageupload = new Imageupload(_hostEnvironment);
            var temppath = imageupload.imageurl(model);
            return temppath;
        }
        public static string ImageUpload(IFormFile model, string foldername, string webRootPath)
        {

            var imageupload = new Imageupload(_hostEnvironment);
            var result = imageupload.uploadimage(model, foldername, webRootPath);
            return result;
        }

        //public static decimal CashPayment(TransactionTypeDescription transactionType, decimal cashPanel , decimal balance, decimal charge)
        //{
        //    if (transactionType.Equals(TransactionTypeDescription.Credit))
        //        return balance = (balance + cashPanel) - charge;
        //    if(transactionType.Equals(TransactionTypeDescription.Debit))
        //        {
        //        transactionType.Equals(TransactionTypeDescription.Credit);
        //    }
        //    return ba

        //}
        public static bool TimeExpire(string startTime)
        {
            var t1 = DateTime.Parse(startTime);
            var t2 = DateTime.Now;

            var timeDifference = t2.Subtract(t1).Minutes;

            return timeDifference > 1 ? true : false;

        }
        public static string StringEncoder(string value)
        {
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(value));
            return code;
        }
        public static string StringDecoder(string value)
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(value));
            return code;
        }
        public static long AccountNumberGenerator()
        {
            var random = new Random(System.DateTime.Now.Millisecond);
            int generatedRandNum = random.Next(1, 505020040);

            var generatedRandNumToString = String.Format("{0:D9}", generatedRandNum);
            const int MaxLength = 8;

            if (generatedRandNumToString.Length > MaxLength)
                generatedRandNumToString = generatedRandNumToString.Substring(1, MaxLength);

            var stringConcat = "5" + generatedRandNumToString + "6";
            long accountNumber = long.Parse(stringConcat);

            return accountNumber;
        }
        public static long GetRandomNumb()
        {
            long randNumber = 0;
            var rand = new Random();
            var bytes = new byte[1];
            rand.NextBytes(bytes);
            for (int i = 1; i <= 9; i++)
            {
                randNumber = +(rand.Next(1, 9) + (DateTime.Now.Ticks / 1000000000000));
            }

            return randNumber;

        }

        public static string GetAdminRandomPass(int length)
        {

            string randomPass = new string(Enumerable.Repeat(Universe.Adminchars, length)
              .Select(s => s[Universe.AdminRandom.Next(s.Length)]).ToArray());

            return randomPass;
        }
        public static string GetAdminPass()
        {

            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day + 3;
            var dayToString = day < 9 ? "0" + day.ToString() : day.ToString();
            var MonthTostring = day < 9 ? "0" + month.ToString() : month.ToString();
            var Admin = "CoreAdmin" + MonthTostring + dayToString;

            return Admin;
        }
        public static string GetTransactionId()
        {
            var year = DateTime.Now.Month.ToString();
            var day = DateTime.Now.Day.ToString();
            return DateTime.Now.Year.ToString() + year + day + DateTime.Now.ToString("ddmmyyhhmmss");
        }

        public static async Task Emailgrid(string password)
        {
            var key = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(Universe.ApiKey);
            var from = new EmailAddress("ozougwu2016@gmail.com", "EasyBanking");
            var to = new EmailAddress("ozougwu2016@gmail.com", "EasyBanking");
            var subject = "testing email sender";
            var plaintextcontext = "your password is " + password + "";
            var htmlcontext = "<strong> AccountNumberGenerator easy way to go</strong>";
            var msg = MailHelper.CreateSingleEmail(

                from,
                to,
                subject,
                plaintextcontext,
                htmlcontext
                );
            var response = await client.SendEmailAsync(msg);
        }
        public static void MailSender(string name, string email, string messagebody)
        {
            MailMessage msg = new MailMessage
            {
                From = new MailAddress("ozougwu2016@gmail.com"),
            };
            msg.To.Add(email);

            msg.Subject = "Account Activation";
            msg.Body = "Hello " + name + ", \n " + messagebody;

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com"
            };
            NetworkCredential credential = new NetworkCredential
            {  // Server Email credential
                UserName = "ozougwu2016@gmail.com",
                Password = "principal160"
            };
            client.Credentials = credential;
            client.EnableSsl = true;
            client.Port = 587;
            client.Send(msg);

        }



    }

    public interface ISequencenumbe
    {
        string GetNumberSequence(string module);
    }


    public class Imageupload
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Imageupload(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string imageurl(IFormFile model)
        {
            var uploadDir = "images";
            var fileName = Path.GetFileNameWithoutExtension(model.FileName);
            var imageUrlpath = "/" + uploadDir + "/" + fileName;
            return imageUrlpath;
        }
        public string uploadimage(IFormFile model, string foldername, string webRootPath)
        {
            var uploadDir = "images";
            var fileName = Path.GetFileNameWithoutExtension(model.FileName);
            var extension = Path.GetExtension(model.FileName);
            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
            var path = Path.Combine(webRootPath, uploadDir, fileName);
            model.CopyToAsync(new FileStream(path, FileMode.Create));
            string imageUrl = "/" + uploadDir + "/" + fileName;

            return imageUrl;
        }



    }


    public class SequenceNumber : ISequencenumbe
    {
        private readonly ApplicationDbContext _context;


        public SequenceNumber(ApplicationDbContext context)
        {
            _context = context;
        }
        public string GetNumberSequence(string module)
        {
            string result = "";
            try
            {
                int counter = 1;


                var numberSequence = _context.NumberSequences
                    .Where(x => x.Module.Equals(module))
                    .FirstOrDefault();

                if (numberSequence == null)
                {
                    numberSequence = new NumberSequence();
                    numberSequence.Module = module;
                    Interlocked.Increment(ref counter);
                    numberSequence.LastNumber = counter;
                    numberSequence.NumberSequenceName = module;
                    numberSequence.Prefix = module;

                    _context.Add(numberSequence);
                    _context.SaveChanges();
                }
                else
                {
                    counter = numberSequence.LastNumber;

                    Interlocked.Increment(ref counter);
                    numberSequence.LastNumber = counter;

                    _context.Update(numberSequence);
                    _context.SaveChanges();
                }

                result = numberSequence.Prefix + counter.ToString().PadLeft(3, '0');
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

    }


    public static class ValidationHelper
    {
        public class ValidationResult
        {
            public  Token Token { get; set; }
            public string Status { get; set; }
        }
        


        public static ValidationResult OTP()
        {
            const string identity = "user@example.com";
            var grant = new ChatGrant
            {
                ServiceSid = "serviceSid"
            };

            var grants = new HashSet<IGrant> {
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

            var result = new ValidationResult
            {
                Token = tokene,
                Status = message.Status.ToString()
            };

            return result;
        }


    }


}
