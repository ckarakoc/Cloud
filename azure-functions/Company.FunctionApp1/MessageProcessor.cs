using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Company.FunctionApp1;

public class MessageProcessor
{
    private readonly ILogger<MessageProcessor> _logger;

    [Function(nameof(MessageProcessor))]
    public void Run([QueueTrigger("message-queue", Connection = "AzureWebJobsStorage")] 
        QueueMessage message,
        ILogger log)
    {
        // send email, validate or alert someone
        _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
    }
}