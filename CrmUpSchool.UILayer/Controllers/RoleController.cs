using Crm.UpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }

        public IActionResult Index()
        {

            var values = _roleManager.Roles.ToList();
            return View(values);

        }

        public IActionResult AddRole()
        {

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddRole(RoleVM p)
        {

            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = p.RoleName,
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();

        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppRole appRole)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == appRole.Id);
            values.Name = appRole.Name;
            //values.NormalizedName = appRole.NormalizedName;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        
        
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id) 
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["UserID"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();

            foreach (var item in roles)
            {
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.Name = item.Name;
                roleAssignViewModel.RoleID = item.Id;
                roleAssignViewModel.Exists = userRoles.Contains(item.Name);
                models.Add(roleAssignViewModel);
                
            }

            return View(models);
        }

        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model) 
        {
            var userid = (int)TempData["UserID"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);

            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);

                }
            }

            return RedirectToAction("UserList");
        }

    }
}
