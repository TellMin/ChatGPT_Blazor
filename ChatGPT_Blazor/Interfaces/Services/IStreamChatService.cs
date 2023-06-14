namespace ChatGPT_Blazor.Interfaces;

public interface IStreamChatService
{
    public IAsyncEnumerable<string> StreamChat(string prompt);
}
