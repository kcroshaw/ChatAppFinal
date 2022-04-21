using ChatAppFinal.Data;
using ChatAppFinal.Interfaces;
using ChatAppFinal.Models;
using ChatAppFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatAppFinal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Room> RoomsList { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public string userName = "";

        [BindProperty]
        public HomeViewModel HomeViewModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                RoomsList = _unitOfWork.Room.List();

                userName = User.Identity.Name;
                
                return Page();
            }
            else
                return RedirectToPage("/Account/Login", new { area = "Identity" });
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}