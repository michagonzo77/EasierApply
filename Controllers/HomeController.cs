using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EasierApply.Models;
namespace EasierApply.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        return View();
    }

    // [HttpPost("path/create")]
    // public IActionResult GetPath()
    // {
    //     string path = newPath
    //     if(ModelState.IsValid)
    //     {
    //         _context.Add(newPath);
    //         _context.SaveChanges();
    //         // return RedirectToAction("OneWedding", new {weddingId = newRSVP.WeddingId});
    //         return RedirectToAction("Messages");
    //     } else {
    //         return Index();
    //     }
    // }

    public ActionResult ApplyToJobs()
    {
        ProcessStartInfo pythonInfo = new ProcessStartInfo();
        Process python;
        pythonInfo.FileName = @"C:\Users\Coding Dojo\AppData\Local\Programs\Python\Python310\python.exe";
        pythonInfo.Arguments = @"linkedin.py";
        pythonInfo.CreateNoWindow = false;
        pythonInfo.UseShellExecute = true;
        Console.WriteLine("Python Starting");
        python = Process.Start(pythonInfo);
        python.WaitForExit();
        python.Close();
        return RedirectToAction("GetThemJobs");
    }

    public ActionResult TestImports()
    {
        ProcessStartInfo pythonInfo = new ProcessStartInfo();
        Process python;
        pythonInfo.FileName = @"C:\Users\Coding Dojo\AppData\Local\Programs\Python\Python310\python.exe";
        pythonInfo.Arguments = @"linkedinbottest.py";
        pythonInfo.CreateNoWindow = false;
        pythonInfo.UseShellExecute = true;
        Console.WriteLine("Python Starting");
        python = Process.Start(pythonInfo);
        python.WaitForExit();
        python.Close();
        return RedirectToAction("Index");
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
