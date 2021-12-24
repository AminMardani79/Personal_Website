using Application.Interface;
using Domain.Records;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace PersonalWebsite.Hubs
{
    
    public class NotificationHub:Hub
    {
        private readonly IMessagesCountService _messagesCountService;

        public NotificationHub(IMessagesCountService messagesCountService)
        {
            _messagesCountService = messagesCountService;
        }
        public override async Task OnConnectedAsync()
        {
            var number = await _messagesCountService.GetMessagesCount();
            await Clients.All.SendAsync("ShowNewNumber", new MessagesCount(number));
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task AddNewMessage()
        {
            await _messagesCountService.AttachMessagesCount();
            var model = await _messagesCountService.GetMessagesCount();
            await Clients.All.SendAsync("ShowNewNumber",new MessagesCount(model));
        }
    }
}