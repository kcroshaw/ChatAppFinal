using ChatAppFinal.Data;
using ChatAppFinal.Models;
using ChatAppFinal.ViewModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using ChatAppFinal.Pages;

namespace ChatAppFinal.Hubs
{
    public class ChatHub : Hub
    {
        public string? roomCode { get; set; }
        public static List<string> rooms = new List<string>();
        private readonly ApplicationDbContext _context;


        public HomeViewModel HomeViewModel;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
            HomeViewModel = new HomeViewModel();
        }

        public async Task SendMessage(string message)
        {
            var userName = Context.User.Identity.Name;
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public Task SendMessageToGroup(string group, string user, string message)
        {
            return Clients.Group(group).SendAsync("ReceiveMessage", user, message);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task CreateRoom(string name)
        {
            var room = new Room()
            {
                Name = name
                //Admin = (ApplicationUser)user
            };

            _context.Room.Add(room);
            //var currentUser = Context.User.Identity.Name;
            await _context.SaveChangesAsync();
            if (!rooms.Contains(name))
            {
                rooms.Add(name);
                await Clients.All.SendAsync("RoomCreated", name);
            }
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
    }
}
