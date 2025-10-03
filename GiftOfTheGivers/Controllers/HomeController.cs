using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly GiftOfTheGiversDbContext _context;

    public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, GiftOfTheGiversDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Phone };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
        }
        return View(model);
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Donate()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Donate(Donation model)
    {
        if (ModelState.IsValid)
        {
            // Save donation logic here
            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult RegisterVolunteer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterVolunteer(Volunteer model)
    {
        if (ModelState.IsValid)
        {
            _context.Volunteers.Add(model);
            _context.SaveChanges();
            return RedirectToAction("VolunteerDashboard");
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Register", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        var model = new ProfileModel
        {
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        var model = new ProfileModel
        {
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(ProfileModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Profile");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Profile");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }
    [HttpGet]
    public IActionResult SubmitIncidentReport()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitIncidentReport(IncidentReport model)
    {
        if (ModelState.IsValid)
        {
            _context.IncidentReports.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult VolunteerDashboard()
    {
        var volunteers = _context.Volunteers.ToList();
        return View(volunteers);
    }

    public IActionResult AssignTask(int id)
    {
        var volunteer = _context.Volunteers.Find(id);
        return View(volunteer);
    }

    [HttpPost]
    public IActionResult AssignTask(Volunteer model)
    {
        var volunteer = _context.Volunteers.Find(model.Id);
        if (volunteer != null)
        {
            volunteer.TaskAssigned = model.TaskAssigned;
            _context.SaveChanges();
        }
        return RedirectToAction("VolunteerDashboard");
    }

    public IActionResult VolunteerSchedule()
    {
        var volunteers = _context.Volunteers.ToList();
        return View(volunteers);
    }

    public IActionResult SendMessage(int id)
    {
        var model = new Message { VolunteerId = id };
        return View(model);
    }
    /*public IActionResult SendMessage(int id)
    {
        var volunteer = _context.Volunteers.Find(id);
        return View(volunteer);
    }*/

    [HttpPost]
    public IActionResult SendMessage(Message model)
    {
        if (ModelState.IsValid)
        {
            _context.Messages.Add(model);
            _context.SaveChanges();
            return RedirectToAction("VolunteerDashboard");
        }
        return View(model);
    }
}

