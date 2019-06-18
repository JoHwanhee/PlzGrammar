using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace PlzGrammarCore.Model
{
    internal class Gmail
    {
        private static readonly string[] Scopes = { GmailService.Scope.GmailSend };
        private static string ApplicationName = "Gmail API .NET Quickstart";

        public void SendEmail(Mail email)
        {
            var service = CreateService();
            var gmailMessage = CreateMessage(email);

            UsersResource.MessagesResource.SendRequest request = service.Users.Messages.Send(gmailMessage, email.Properties.From);
            request.Execute();
        }

        public IList<Label> ReadLabels()
        {
            GmailService service = CreateService();
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            return request.Execute().Labels;
        }

        private string Encode(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            return Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        private GmailService CreateService()
        {
            UserCredential credential;

            using (FileStream stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            GmailService service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }

        private Message CreateMessage(Mail email)
        {
            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress(email.Properties.From);
            mailMessage.To.Add(email.Properties.To);
            mailMessage.ReplyToList.Add(email.Properties.From);
            mailMessage.Subject = email.Properties.Subject;
            mailMessage.Body = email.Properties.Contents;
            var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mailMessage);
            var gmailMessage = new Message
            {
                Raw = Encode(mimeMessage.ToString())
            };
            return gmailMessage;
        }
    }
}