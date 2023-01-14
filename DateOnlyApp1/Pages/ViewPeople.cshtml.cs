using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DateOnlyApp1.Models;

namespace DateOnlyApp1.Pages
{
    public class ViewPeopleModel : PageModel
    {
        private readonly Data.Context _context;

        public ViewPeopleModel(Data.Context context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Person != null)
            {
                Person = await _context.Person.ToListAsync();
            }
        }
    }
}
