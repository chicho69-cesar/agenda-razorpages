using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaContactos.Pages.Categories {
    public class DetailModel : PageModel {
        private readonly AppDbContext _context;

        public DetailModel(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task OnGet(int id) {
            Category = await _context.Categories
                .FindAsync(id);
        }
    }
}