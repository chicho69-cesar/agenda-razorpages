using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Contacts {
    public class DetailModel : PageModel {
        private readonly AppDbContext _context;

        public DetailModel(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task OnGet(int id) {
            Contact = await _context.Contacts
                .Where(c => c.Id == id)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();
        }
    }
}