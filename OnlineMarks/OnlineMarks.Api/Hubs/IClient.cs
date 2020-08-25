using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public interface IClient
{   
    Task ReceiveMessage(string user, string message);
}