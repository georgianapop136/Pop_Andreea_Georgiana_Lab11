﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;



namespace Pop_Andreea_Georgiana_Lab2.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }

    }
}