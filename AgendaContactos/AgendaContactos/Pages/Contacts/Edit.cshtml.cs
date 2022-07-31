using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Contacts {
    public class EditModel : PageModel {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public CreateOrEditContactViewModel ViewModel { get; set; }

        public async Task<IActionResult> OnGet(int id) {
            ViewModel = new CreateOrEditContactViewModel {
                Categories = await _context.Categories
                    .ToListAsync(),
                Contact = await _context.Contacts
                    .FindAsync(id)
            };

            return Page();
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "Hay un error en la informacion que proporcionaste");
                return Page();
            }

            var searchedContact = await _context.Contacts
                .Where(c => c.Id == ViewModel.Contact.Id)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();

            searchedContact.Name = ViewModel.Contact.Name;
            searchedContact.Email = ViewModel.Contact.Email;
            searchedContact.PhoneNumber = ViewModel.Contact.PhoneNumber;
            searchedContact.Category = ViewModel.Contact.Category;
            searchedContact.CreationDate = ViewModel.Contact.CreationDate;

            _context.Entry(searchedContact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}