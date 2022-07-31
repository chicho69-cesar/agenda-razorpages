using AgendaContactos.Data;
using AgendaContactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Pages.Contacts {
    public class DeleteModel : PageModel {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context) {
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

        public async Task<IActionResult> OnPost() {
            var searchedContact = await _context.Contacts
                .Where(c => c.Id == Contact.Id)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();

            if (searchedContact is null) {
                return NotFound();
            }

            _context.Contacts.Remove(searchedContact);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}