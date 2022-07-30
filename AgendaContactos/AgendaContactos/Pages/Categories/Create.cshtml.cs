using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaContactos.Pages.Categories {
    public class CreateModel : PageModel {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet() {

        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "Hay un error en los datos que proporcionaste");
                return Page();
            }

            await _context.Categories.AddAsync(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}