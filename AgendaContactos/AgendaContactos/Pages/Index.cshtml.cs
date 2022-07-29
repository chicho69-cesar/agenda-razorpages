/*Esta es la pagina modelo para la vista Index, todas las vistas
razor tienen su propia pagina modelo para controlar la logica
que se necesite en la pagina*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaContactos.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public void OnGet() {

        }
    }
}