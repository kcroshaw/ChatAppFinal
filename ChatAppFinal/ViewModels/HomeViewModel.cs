using ChatAppFinal.Models;

namespace ChatAppFinal.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public Room Room { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Message Message { get; set; }
    }
}
