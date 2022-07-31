using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Contacts {
    public class CreateModel : PageModel {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public CreateOrEditContactViewModel ViewModel { get; set; }

        public async Task<IActionResult> OnGet() {
            ViewModel = new CreateOrEditContactViewModel {
                Categories = await _context.Categories
                    .ToListAsync(),
                Contact = new Contact()
            };

            return Page();
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "Hay un error en la informacion que proporcionaste");
                return Page();
            }

            await _context.Contacts.AddAsync(ViewModel.Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}