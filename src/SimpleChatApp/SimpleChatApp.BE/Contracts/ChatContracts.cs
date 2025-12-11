using SimpleChatApp.BE.Hubs;
using SimpleChatApp.Contracts;
using SendJoinModel = SimpleChatApp.Contracts.SendJoinModel;

namespace SimpleChatApp.BE.Contracts;

public class ChatContracts : IClientChatContracts, IChatContracts
{
    private readonly Dictionary<string, Action<SendContractModel>> _registry = new();

    public void SendMessage(SendMessageModel model)
    {
        var key = nameof(SendMessage);
        var exists = _registry.TryGetValue(key, out var func);
        if (exists is false || func is null)
        {
            Console.WriteLine($"Not found {key} in registry");
            return;
        }

        func(model);
    }

    public void SendJoin(SendJoinModel model)
    {
        var key = nameof(SendJoin);
        var exists = _registry.TryGetValue(key, out var func);
        if (exists is false || func is null)
        {
            Console.WriteLine($"Not found {key} in registry");
            return;
        }

        func(model);
    }

    public void RegisterSendMessage(Action<SendContractModel> func)
    {
        _registry.Add(nameof(SendMessage), func);
    }

    public void RegisterSendJoin(Action<SendContractModel> func)
    {
        _registry.Add(nameof(SendJoin), func);
    }
}