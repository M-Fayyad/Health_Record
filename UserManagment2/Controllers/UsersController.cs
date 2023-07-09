using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagment2.Data;
using UserManagment2.Models;
using UserManagment2.ViewModels;

namespace UserManagment2.Controllers
{
	[Authorize(Roles = RolesName.AdminRole)]
	public class UsersController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ApplicationDbContext _context;
		 
		public UsersController(UserManager<ApplicationUser> userManager , ApplicationDbContext context)
		{
			_userManager = userManager;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var users = await  _context.Users
				.Select(user=> new UserViewModel()
				{
                    Id = user.Id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					UserName = user.UserName,
					Email = user.Email,
					Roles =   _userManager.GetRolesAsync(user).Result
				})
				.ToListAsync();


			return View(users);
		}
	}
}
