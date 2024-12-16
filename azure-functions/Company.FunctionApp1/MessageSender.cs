using System;
using System.Text;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.FunctionApp1;

public class MessageSender
{
    [Function("MessageSender")]
    public void Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer,
        ILogger log)
    {
        var message = $"C# Timer trigger function executed at: {DateTime.Now}";
        HttpClient client = new();
        HttpRequestMessage requestMessage = new(HttpMethod.Post, "https://localhost:7071/api/MessageReceiver");
        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

        client.Send(requestMessage);
        log.LogInformation(message);
    }
}