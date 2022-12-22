using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EasierApply.Models;
namespace EasierApply.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(bool HasError = false)
    {
        if(HasError == true)
        {
            ViewBag.HasError = true;
        }
        try
        {
            PythonPath? PathBaby = _context.PythonPaths.FirstOrDefault();
            int? PathId = 1;
            if(PathBaby != null)
            {
                ViewBag.ItExists = PathId;
            }
            return View("Index",PathBaby);
        }
        catch (System.Exception)
        {  
            return View("Index");
        }
    }

    [HttpPost("path/create")]
    public IActionResult CreatePath(PythonPath newPath)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newPath);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return Index();
        }
    }

    [HttpPost("path/{PythonPathId}/update")]
    public IActionResult UpdatePath(PythonPath updatedPath, int PythonPathId)
    {
        PythonPath? PathToUpdate = _context.PythonPaths.FirstOrDefault(a => a.PythonPathId == PythonPathId);
        if(ModelState.IsValid)
        {
            PathToUpdate.Path = updatedPath.Path;
            PathToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return Index();
        }
    }

    [HttpGet("apply")]
    public IActionResult ApplyToJobs()
    {
        // C:\Users\Coding Dojo\AppData\Local\Programs\Python\Python310\python.exe
        try
        {
            PythonPath? PathBaby = _context.PythonPaths.FirstOrDefault();
            bool HasError = false;
            string? FilePath = PathBaby.Path;
            ProcessStartInfo pythonInfo = new ProcessStartInfo();
            Process python;
            pythonInfo.FileName = FilePath;
            pythonInfo.Arguments = @"flask_app\\linkedin.py";
            pythonInfo.CreateNoWindow = false;
            pythonInfo.UseShellExecute = true;
            Console.WriteLine("Python Starting");
            python = Process.Start(pythonInfo);
            python.WaitForExit();
            python.Close();
            return RedirectToAction("GetThemJobs");
        }
        catch (System.Exception)
        {
            bool HasError = true;
            return Index(HasError);
        }
    }

    [HttpGet("test")]
    public IActionResult TestImports()
    {
        try
        {
            PythonPath? PathBaby = _context.PythonPaths.FirstOrDefault();
            bool HasError = false;
            string? FilePath = PathBaby.Path;
            ProcessStartInfo pythonInfo = new ProcessStartInfo();
            Process python;
            pythonInfo.FileName = FilePath;
            pythonInfo.Arguments = @"flask_app\\linkedinbottest.py";
            pythonInfo.CreateNoWindow = false;
            pythonInfo.UseShellExecute = true;
            Console.WriteLine("Python Starting");
            python = Process.Start(pythonInfo);
            python.WaitForExit();
            python.Close();
            return RedirectToAction("Index");
        }
        catch (System.Exception)
        {
            bool HasError = true;
            return Index(HasError);
        }
    }

    [HttpGet("getthemjobs")]
    public IActionResult GetThemJobs()
    {
        return View("GetThemJobs");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using EasierApply.Models;
// namespace EasierApply.Controllers;

// public class HomeController : Controller
// {
//     private readonly ILogger<HomeController> _logger;
//     private MyContext _context;
//     public HomeController(ILogger<HomeController> logger, MyContext context)
//     {
//         _logger = logger;
//         _context = context;
//     }

//     public IActionResult Index()
//     {
//         PythonPath? PathBaby = _context.PythonPaths.First();
//         int PathId = PathBaby.PythonPathId;
//         if(PathBaby != null){
//             ViewBag.ItExists = PathId;
//         }
//         return View("Index",PathBaby);
//     }

//     [HttpPost("path/create")]
//     public IActionResult CreatePath(PythonPath newPath)
//     {
//         if(ModelState.IsValid)
//         {
//             _context.Add(newPath);
//             _context.SaveChanges();
//             return RedirectToAction("Index");
//         } else {
//             return Index();
//         }
//     }

//     [HttpPost("path/{PythonPathId}/update")]
//     public IActionResult UpdatePath(PythonPath updatedPath, int PythonPathId)
//     {
//         PythonPath? PathToUpdate = _context.PythonPaths.FirstOrDefault(a => a.PythonPathId == PythonPathId);
//         if(ModelState.IsValid)
//         {
//             PathToUpdate.Path = updatedPath.Path;
//             PathToUpdate.UpdatedAt = DateTime.Now;
//             _context.SaveChanges();
//             return RedirectToAction("Index");
//         } else {
//             return Index();
//         }
//     }


//     public IActionResult ApplyToJobs()
//     {
//         // C:\Users\Coding Dojo\AppData\Local\Programs\Python\Python310\python.exe
//         PythonPath? PathBaby = _context.PythonPaths.First();
//         string? FilePath = PathBaby.Path;
//         ProcessStartInfo pythonInfo = new ProcessStartInfo();
//         Process python;
//         pythonInfo.FileName = FilePath;
//         pythonInfo.Arguments = @"linkedin.py";
//         pythonInfo.CreateNoWindow = false;
//         pythonInfo.UseShellExecute = true;
//         Console.WriteLine("Python Starting");
//         python = Process.Start(pythonInfo);
//         python.WaitForExit();
//         python.Close();
//         return RedirectToAction("GetThemJobs");
//     }

//     [HttpGet("test")]
//     public IActionResult TestImports()
//     {
//         PythonPath? PathBaby = _context.PythonPaths.First();
//         string? FilePath = PathBaby.Path;
//         ProcessStartInfo pythonInfo = new ProcessStartInfo();
//         Process python;
//         pythonInfo.FileName = FilePath;
//         pythonInfo.Arguments = @"linkedinbottest.py";
//         pythonInfo.CreateNoWindow = false;
//         pythonInfo.UseShellExecute = true;
//         Console.WriteLine("Python Starting");
//         try
//         {
//             python = Process.Start(pythonInfo);
//         }
//         catch (System.Exception)
//         {
            
//             return Index();
//         }
//         python.WaitForExit();
//         python.Close();
//         return RedirectToAction("Index");
//     }

//     [HttpGet("getthemjobs")]
//     public IActionResult GetThemJobs()
//     {
//         return View("GetThemJobs");
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }