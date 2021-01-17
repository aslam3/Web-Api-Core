using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using JobPortalApp.Model;
using JobPortalApp.Model.db_models;
using JobPortalApp.Repository;
using JobPortalApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;



namespace JobPortalApp.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly jobdbcontext _context;
        // Jwt
        private IOptionsSnapshot<jwt_vm> jwtSetting;
        private jwtRepo jRepo;

        public AccountController(UserManager<User> _userManager, RoleManager<Role> _roleManager, IOptionsSnapshot<jwt_vm> options, jobdbcontext context)
        {
            this.userManager = _userManager;
            this.roleManager = _roleManager;
            this._context = context;
            jwtSetting = options;
        }

        // -- api/account
        [HttpPost]
        public async Task<ActionResult> SignUp(UserVM userVM, int userType)
        {
            
            if (!ModelState.IsValid)
            {
                    var error = new List<string>();
                    foreach (var state in ModelState)
                    {
                        foreach (var err in state.Value.Errors)
                        {
                            error.Add(err.ToString());
                        }
                    }
                    return BadRequest(error);
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    User user = new User
                    {                       
                        UserName = userVM.UserName,
                        Email = userVM.Email
                    };

                    var result = await userManager.CreateAsync(user, userVM.Password);

                    if (result.Succeeded)
                    {
                        // UserType: 0==jobseeker, 1==employer
                        //IdentityResult roleResult = null;
                        if (userType == 0)
                        {
                            //roleResult = 
                            await userManager.AddToRoleAsync(user, "jobseeker");

                        }
                        else if (userType == 1)
                        {
                            //roleResult = 
                            await userManager.AddToRoleAsync(user, "employer");
                        }
                        //if (roleResult.Succeeded)
                        //{
                        await transaction.CommitAsync();

                        return Created("", user);
                        //}


                    }



                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }




            }


            return Problem();
        }

        // api/account/login
        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserVM userVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user = userManager.Users.Where(u => u.Email == userVM.Email).FirstOrDefault();

                    if (user == null)
                    {
                        return NoContent();
                    }

                    var result = await userManager.CheckPasswordAsync(user, userVM.Password);
                    if (result)
                    {
                        var roleList = await userManager.GetRolesAsync(user);
                        jRepo = new jwtRepo(this.jwtSetting);

                        return Ok(jRepo.GenerateJWT(user, roleList));
                    }

                }
                else
                {
                    return BadRequest();
                }
            }
                catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }

        // api/account/CreateRoles
        [HttpPost("CreateRoles")]
        public async Task<ActionResult> CreateRoles(string role)
        {
            try
            {
                if (role==null)
                {
                    return BadRequest();
                }
                var roles = new Role
                {
                    Name = role
                };
               var result = await roleManager.CreateAsync(roles);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Problem();
        }


        // api/account/AddToRole
        [HttpPost("AddToRole")]
        public async Task<ActionResult> AddToRole(string userEmail, string roleName)
        {
            try
            {
                if (userEmail!=null && roleName!=null)
                {
                    var user = userManager.Users.Where(u => u.Email == userEmail).SingleOrDefault();
                    var result = await userManager.AddToRoleAsync(user, roleName);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Problem();
        }



    }
}