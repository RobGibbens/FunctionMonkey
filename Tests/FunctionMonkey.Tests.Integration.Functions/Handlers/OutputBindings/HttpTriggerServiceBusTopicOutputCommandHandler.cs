using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Tests.Integration.Functions.Commands;
using FunctionMonkey.Tests.Integration.Functions.Commands.Model;
using FunctionMonkey.Tests.Integration.Functions.Commands.OutputBindings;

namespace FunctionMonkey.Tests.Integration.Functions.Handlers.OutputBindings
{
    public class HttpTriggerServiceBusTopicOutputCommandHandler : ICommandHandler<HttpTriggerServiceBusTopicOutputCommand, QueuedMarkerIdCommand>
    {
        public Task<QueuedMarkerIdCommand> ExecuteAsync(HttpTriggerServiceBusTopicOutputCommand command, QueuedMarkerIdCommand previousResult)
        {
            return QueuedMarkerIdCommand.Success(command.MarkerId);
        }
    }
}