using ChatGPT_Blazor.Interfaces;
using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;

namespace ChatGPT_Blazor.Services;

public class StreamChatService : IStreamChatService
{
    private readonly IOpenAIService openAIService;

    public StreamChatService(IOpenAIService openAIService)
    {
        this.openAIService = openAIService;
    }

    public async IAsyncEnumerable<string> StreamChat(string prompt)
    {

        var messages = new List<ChatMessage>()
        {
            ChatMessage.FromSystem("The following is a conversation with an AI assistant. The assistant is helpful, creative, clever, and very friendly."),
            ChatMessage.FromUser(prompt)
        };

        var completionResult = openAIService.ChatCompletion.CreateCompletionAsStream(
            new ChatCompletionCreateRequest()
            {
                Messages = messages,
                Model = Models.ChatGpt3_5Turbo
            });

        await foreach (var completion in completionResult)
        {
            if (completion.Successful)
            {
                Console.WriteLine(completion.Choices.FirstOrDefault()?.Message.Content ?? string.Empty);
                yield return completion.Choices.FirstOrDefault()?.Message.Content ?? string.Empty;
            }
            else
            {
                if (completion.Error == null)
                {
                    throw new Exception("Unknown Error");
                }

                Console.WriteLine($"{completion.Error.Code}: {completion.Error.Message}");
            }
        }
        Console.WriteLine("Complete");
    }
}
