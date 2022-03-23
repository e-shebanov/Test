using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Data;

namespace Test.Pages
{
    public class TableModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;
        public TableModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Package> Packages;
        public IEnumerable<Pipe> Pipes;
        public IEnumerable<Pipe> pipesNullPackage;

        public IActionResult OnPostDeletePipe(int pipeId)
        {
            if(pipeId == null )
            {
                return Page();
            }
            var pipe = _context.Pipes.Where(p => p.Id == pipeId).FirstOrDefault();
            if(pipe == null)
            {
                Pipes = _context.Pipes;
                Packages = _context.Packages;
                pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
                return Page();
            }
            _context.Pipes.Remove(pipe);
            _context.SaveChanges();
            Pipes = _context.Pipes;
            Packages = _context.Packages;
            pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
            return Page();
        }

        public IActionResult OnPostEditPipe(int pipeId)
        {
            return Redirect("/EditPipe?id=" + pipeId);
        }
        public IActionResult OnPostDeletePackage(int packageId)
        {
            if (packageId == null)
            {
                Pipes = _context.Pipes;
                Packages = _context.Packages;
                pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
                return Page();
            }
            var pipes = _context.Pipes.Where(p => p.PackageId == packageId);
            foreach(var pipe in pipes)
            {
                pipe.PackageId = null;
                //pipe.Package = null;
            }
            
            var pack = _context.Packages.Where(p => p.PackageId == packageId).FirstOrDefault();
            if(pack == null)
            {
                Pipes = _context.Pipes;
                Packages = _context.Packages;
                pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
                return Page();
            }
            _context.Packages.Remove(pack);
            _context.SaveChanges();
            Pipes = _context.Pipes;
            Packages = _context.Packages;
            pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
            return Page();
        }

        public void OnGet()
        {
            Pipes = _context.Pipes;
            Packages = _context.Packages;
            pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
        }
        public IActionResult OnPost(string datetime, int number)
        {
            if (number == null)
            {
                Pipes = _context.Pipes;
                Packages = _context.Packages;
                pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
                return Page();
            }
            Package pack = new Package()
            {
                Number = number,
                Created = DateTime.Parse(datetime),
            };
            _context.Packages.Add(pack);
            _context.SaveChanges();
            Pipes = _context.Pipes;
            Packages = _context.Packages;
            pipesNullPackage = _context.Pipes.Where(c => c.PackageId == null);
            return Page();
        }

    }
}
