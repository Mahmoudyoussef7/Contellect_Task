using Microsoft.AspNetCore.SignalR;

namespace App.Hubs;
public class ContactHub : Hub
{
    public async Task ContactLocked(Guid contactId)
    {
        await Clients.Others.SendAsync("ContactLocked", contactId);
    }
    
    public async Task ContactUnlocked(Guid contactId)
    {
        await Clients.Others.SendAsync("ContactUnlocked", contactId);
    }

    public string GetConnectionId() => Context.ConnectionId;
}