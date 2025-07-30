// Hubs/VideoHub.cs
using Microsoft.AspNetCore.SignalR;

public class VideoHub : Hub
{
    public async Task JoinRoom(string roomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
    }

    public async Task SendOffer(string roomId, string sdp)
    {
        await Clients.OthersInGroup(roomId).SendAsync("ReceiveOffer", sdp);
    }

    public async Task SendAnswer(string roomId, string sdp)
    {
        await Clients.OthersInGroup(roomId).SendAsync("ReceiveAnswer", sdp);
    }

    public async Task SendIceCandidate(string roomId, string candidate)
    {
        await Clients.OthersInGroup(roomId).SendAsync("ReceiveIceCandidate", candidate);
    }
}
