using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Categories {
    public class EditModel : PageModel {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task OnGet(int id) {
            Category = await _context.Categories
                .FindAsync(id);
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "Hay un error en la informacion que proporcionaste");
                return Page();
            }

            var searchedCategory = await _context.Categories
                .Where(c => c.Id == Category.Id)
                .FirstAsync();

            searchedCategory.Name = Category.Name;
            searchedCategory.CreationDate = Category.CreationDate;

            _context.Entry(searchedCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}