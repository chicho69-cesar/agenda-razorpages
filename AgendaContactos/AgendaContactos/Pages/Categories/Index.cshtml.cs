using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Categories {
    public class IndexModel : PageModel {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Category> Categories { get; set; }

        public async Task OnGet() {
            Categories = await _context.Categories
                .ToListAsync();
        }
    }
}