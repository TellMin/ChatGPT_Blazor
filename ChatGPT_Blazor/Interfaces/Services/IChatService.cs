using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;

namespace ChatGPT_Blazor.Interfaces.Services;

public interface IChatService
{
    Task<ChatCompletionCreateResponse> Chat(List<ChatMessage> chatMessages);
}
