using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RealtimedataToGraphics.Hubs
{
    public class SpeedHub : Hub
    {
        public async Task SendSpeed(string speed)
        {
            System.Console.WriteLine("Received Speed");
            System.Console.WriteLine(speed);
            await Clients.All.SendAsync("ReceiveSpeed", speed);
        }
    }
}
