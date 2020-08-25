using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class MessageHub : Hub<IClient>
{   
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.ReceiveMessage(user, message);
    }
}