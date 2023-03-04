using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace ChatGPT_Blazor.Interfaces.Services;

public interface IChatService
{
    Task<ChatCompletionCreateResponse> Chat(List<ChatMessage> chatMessages);
}
