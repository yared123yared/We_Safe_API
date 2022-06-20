using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using signalRtc.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WeSafe.Hubs;
using WeSafe.Models;

namespace VueChatApp.Hubs
{
    [Authorize]
    public class NotificationHub :Hub
    {
    
          public async Task NewUser(string username)
        {   
            Console.WriteLine("New User with user name %d",username);
            var userInfo = new UserInfo() { userName = username, connectionId = Context.ConnectionId };
            await Clients.Others.SendAsync("NewUserArrived", JsonSerializer.Serialize(userInfo));
        }

        public async Task HelloUser(string userName, string user)
        {
            var userInfo = new UserInfo() { userName = userName, connectionId = Context.ConnectionId };
            await Clients.Client(user).SendAsync("UserSaidHello", JsonSerializer.Serialize(userInfo));
        }

        public async Task SendSignal(string signal, string user)
        {
            await Clients.Client(user).SendAsync("SendSignal", Context.ConnectionId, signal);
            // await Clients.User(webRtcMessage.To.ToString()).WebRtcSignal(webRtcMessage);
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            await Clients.All.SendAsync("UserDisconnect", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
         public async Task StartCall(WebRtcMessage webRtcMessage)
        {   
             await Clients.Client(webRtcMessage.To.ToString()).SendAsync("SendSignal",webRtcMessage);
        //    await Clients.User(webRtcMessage.To.ToString()).WebRtcSignal(webRtcMessage);
        }
        
    }
}
