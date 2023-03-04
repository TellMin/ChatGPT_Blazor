using ChatGPT_Blazor.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using System;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace ChatGPT_Blazor.Services;

public class ChatService : IChatService
{
    private readonly IOpenAIService openAIService;

    public ChatService(IOpenAIService openAIService)
    {
        this.openAIService = openAIService;
    }


    public async Task<ChatCompletionCreateResponse> Chat(List<ChatMessage> chatMessages)
    {
        var completionResult = await openAIService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest()
        {
            Messages = chatMessages,
            Model = Models.ChatGpt3_5Turbo
        });

        if (completionResult.Successful) return completionResult;

        if (completionResult.Error is not null) Console.WriteLine(completionResult.Error);

        throw new InvalidOperationException();
    }
}
