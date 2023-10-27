using System;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;

public class NotificationService
{
    private string GatewayApiUrl = "https://gatewayapi.com/rest/";
    private string GatewayApiToken = "";
    private string SendGridApiKey = "";

    public async Task SendSMSAsync(string message, string phoneNumber)
    {
        var client = new RestClient(new RestClientOptions
        {
            BaseUrl = new Uri(GatewayApiUrl),
            Authenticator = new HttpBasicAuthenticator(GatewayApiToken, "")
        });

        var request = new RestRequest("mtsms", Method.Post);
        request.AddJsonBody(new
        {
            sender = "Seasony",
            message = message,
            recipients = new[] { new { msisdn = phoneNumber } }
        });

        var response = await client.ExecuteAsync(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            if (response.Content != null)
            {
                var res = JObject.Parse(response.Content);
                Console.WriteLine("SMS send OK to:");
                foreach (var i in res["ids"])
                {
                    Console.WriteLine(i);
                }
            }
        }
        else if (response.ResponseStatus == ResponseStatus.Completed)
        {
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine(response.ErrorMessage);
        }
    }

    public async Task SendEmailAsync(string email, string name, string emailsubject, string emailmessage)
    {
        var client = new SendGridClient(SendGridApiKey);

        var from = new EmailAddress("jag@seasony.dk", "Jacob Gervin");
        var to = new EmailAddress(email, name);
        var subject = emailsubject;
        var plainTextContent = emailmessage;
        var htmlContent = emailmessage;

        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);

        Console.WriteLine(response.StatusCode);
    }


}
