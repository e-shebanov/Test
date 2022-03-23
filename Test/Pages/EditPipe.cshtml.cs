using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Data;

namespace Test.Pages
{
    public class EditPipeModel : PageModel
    {
        private readonly AppDbContext _context;
        public EditPipeModel(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Package> Packages;
        public Pipe pipe;
        public void OnGet([FromQuery(Name = "id")] int id)
        {
            
            pipe = _context.Pipes.Where(p => p.Id== id).FirstOrDefault();
        
            Packages = _context.Packages;
        }

        public IActionResult OnPost([FromQuery(Name = "id")] int id, int Number, string PackageId, string Quality,
                                    string SteelGrade, double Weight, double Dy, double Dh, double S)
        {
            int? PackageIntId;
            if (PackageId == "Null")
            {
                PackageIntId = null;
            }
            else
                PackageIntId = Int32.Parse(PackageId);
            var pipe = _context.Pipes.Where(p => p.Id == id).FirstOrDefault();
            pipe.Number = Number;
            pipe.Quality = Quality;
            pipe.PackageId = PackageIntId;
            pipe.S = S;
            pipe.Dy = Dy;
            pipe.Dh = Dh;
            pipe.SteelGrade = SteelGrade;
            pipe.Weight = Weight;
            _context.SaveChanges();
            return Redirect("/table");
        }
    }
}
