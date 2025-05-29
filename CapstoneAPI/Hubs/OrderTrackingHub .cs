using CapstoneAPI.Entities;
using Microsoft.AspNetCore.SignalR;

namespace CapstoneAPI.Hubs
{
    public class OrderTrackingHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendUpdateToClient(int orderId, object trackingData)
        {
            await Clients.All.SendAsync("ReceiveTrackingUpdate", orderId, trackingData);
        }
    }
}
