using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Company.FunctionApp1;

public class MessageReceiver
{
    // todo:azurite
    [Function("MessageReceiver")]
    public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] 
        HttpRequest req, 
        ILogger log,
        [Queue("message-queue"), StorageAccount("AzureWebJobsStorage")]
        ICollector<string> messageQueue)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        messageQueue.Add(requestBody);
        
        return new OkResult();
        
    }

}