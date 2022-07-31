using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Contacts {
    public class IndexModel : PageModel {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Contact> Contacts { get; set; }

        public async Task OnGet() {
            Contacts = await _context.Contacts
                .Include(c => c.Category)
                .ToListAsync();
        }
    }
}