using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OnlineMarks.Interfaces.Services;
using System;

[Authorize]
public class MessageHub : Hub<IClient>
{   

    private IMessageService _messageService;

    public MessageHub(IMessageService messageService){
        _messageService = messageService ?? throw new ArgumentNullException($"{nameof(IMessageService)} cannot be null!");
    }

    public async Task SendMessage(string receiverName, string content)
    {  
        var senderName = Context.User.Identity.Name;
        _messageService.Add(senderName, receiverName, content);

        await Clients.All.ReceiveMessage(senderName, content);
    }

    public Task JoinRoom(string roomName)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
    }

    public Task LeaveRoom(string roomName)
    {
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
    }
}