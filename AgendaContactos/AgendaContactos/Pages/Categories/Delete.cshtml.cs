using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Categories {
    public class DeleteModel : PageModel {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task OnGet(int id) {
            Category = await _context.Categories
                .FindAsync(id);
        }

        public async Task<IActionResult> OnPost() {
            var searchedCategory = await _context.Categories
                .Where(c => c.Id == Category.Id)
                .FirstAsync();

            if (searchedCategory is null) {
                return NotFound();
            }

            _context.Categories.Remove(searchedCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}