using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Data;

namespace Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;
        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Package> Packages;
        public IEnumerable<Pipe> Pipes;
        public void OnGet()
        {
            
            Pipes = _context.Pipes;
            Packages = _context.Packages;
        }

        public IActionResult OnPost(int Number, string PackageId, string Quality,
                                    string SteelGrade, double Weight, double Dy, double Dh, double S)
        {
            if(Number == null)
            {
                Pipes = _context.Pipes;
                Packages = _context.Packages;
                return Page();
            }
            int? PackageIntId;
            if (PackageId == "Null")
            {
                PackageIntId = null;
            }
            else
                PackageIntId = Int32.Parse(PackageId);
            Pipe pipe = new Pipe()
            {
                Number = Number,
                Quality = Quality,
                SteelGrade = SteelGrade,
                Weight = Weight,
                Dy = Dy,
                Dh = Dh,
                S = S,
                PackageId = PackageIntId
            };
            _context.Pipes.Add(pipe);
            _context.SaveChanges();
            Pipes = _context.Pipes;
            Packages = _context.Packages;
            return Page();
        }
    }
}