using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers;

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

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid && IsValidUser(model.UserName, model.Password))
        {
            SetUserCookies(model.UserName);
            return RedirectToAction("Index", "Contact");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt");
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        DeleteUserCookies();
        return RedirectToAction("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    private bool IsValidUser(string username, string password)
    {
        return (username == "user1" && password == "user1") ||
               (username == "user2" && password == "user2");
    }

    private void SetUserCookies(string username)
    {
        // Create the cookie options
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.UtcNow.AddDays(1),
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
        };

        // Set the UserName cookie
        Response.Cookies.Append("UserName", username, cookieOptions);
    }

    private void DeleteUserCookies()
    {
        // Remove the UserName cookie
        Response.Cookies.Delete("UserName");
    }
}