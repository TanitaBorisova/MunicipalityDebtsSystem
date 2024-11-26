// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Municipality;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;
using MunicipalityDebtsSystem.Core.Services;


namespace MunicipalityDebtsSystem.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IMunicipalityService _municipalityService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IMunicipalityService municipalityService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _municipalityService = municipalityService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        //[BindProperty]
        //public string SelectedRegionId { get; set; }

        //public List<SelectListItem> Regions { get; set; }



        [BindProperty]
        public int? MunicipalityId { get; set; }

        public List<SelectListItem> Municipalities { get; set; }



        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = RequiredErrorMessage)]
            [EmailAddress]
            [Display(Name = "Ел. адрес")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = RequiredErrorMessage)]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [StringLength(100, ErrorMessage = StringLengthErrorMessage, MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Парола")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Потвърди парола")]
            [Compare("Password", ErrorMessage = PasswordAndConfirmErrorMessage)]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = RequiredErrorMessage)]
            [Display(Name = "Име")]
            [StringLength(UserFirstNameMaxLength, ErrorMessage = StringLengthErrorMessage, MinimumLength = UserFirstNameMinLength)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = RequiredErrorMessage)]
            [Display(Name = "Фамилия")]
            [StringLength(UserLastNameMaxLength, ErrorMessage = StringLengthErrorMessage, MinimumLength = UserLastNameMinLength)]
            public string LastName { get; set; }

            //[Required(ErrorMessage = RequiredErrorMessage)]
            //[Display(Name = "Област")]
            //[Range(MinSelectedValue, MaxSelectedValue, ErrorMessage = ChooseItemErrorMessage)]
            //public int RegionId { get; set; }

            [Required(ErrorMessage = RequiredErrorMessage)]
            [Display(Name = "Община")]
            //[Range(MinSelectedValue, MaxSelectedValue, ErrorMessage = ChooseItemErrorMessage)]
            public int MunicipalityId { get; set; }

            //public List<RegionViewModel> Regions { get; set; } = new List<RegionViewModel>();

            public List<MunicipalityViewModel> Municipalities { get; set; } = new List<MunicipalityViewModel>();


        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Input = new InputModel();
            await FillMunicipalities();

        }
       

        public async Task<IActionResult> OnGetMunicipalities(string searchTerm)
        {
            // Call your service or database to get municipalities based on the search term
            var municipalities = await _municipalityService.GetMunicipalitiesByNameAsync(searchTerm);

            // Return the filtered list as JSON
            var result = municipalities.Select(m => new { id = m.Id, name = m.Name }).ToList();

            return new JsonResult(result);
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            await SeedRoles();
            await SeedRolesToUsers();
            await FillMunicipalities();

            // var municipalities = await _municipalityService.GetAllMunicipalitiesAsync();
            // ////Populate the Regions dropdown list
            //Municipalities = municipalities
            //    .Select(m => new SelectListItem
            //    {
            //        Value = m.MunicipalityId.ToString(),  // or just m.Id depending on your data type
            //        Text = m.MunicipalityName
            //    }).ToList();


            if (ModelState.IsValid)
            {
                var user = CreateUser();
                await AddUserToRole(user);
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                                
                user.MunicipalityId = MunicipalityId;

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //Add Claims to User
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(UserFullNameClaim, $"{user.FirstName} {user.LastName}"));
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(UserMunicipalityIdClaim, $"{user.MunicipalityId}"));
                    var municipality = await _municipalityService.GetMunicipalityByIdAsync(user.MunicipalityId ?? 0);
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(UserMunicipalityNameClaim, $"{municipality.MunicipalityName}"));
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(UserMunicipalityCodeClaim, $"{municipality.MunicipalityCode}"));

                                    
                    ///////////////////////////////////////////////////////////////////////////
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                // var muns = await _municipalityService.GetAllMunicipalitiesAsync();
                // Municipalities = muns
                //.Select(m => new SelectListItem
                //{
                //    Value = m.MunicipalityId.ToString(),  // or just m.Id depending on your data type
                //    Text = m.MunicipalityName
                //}).ToList();

                await FillMunicipalities();

                //return Page();
            }
            // If we got this far, something failed, redisplay form
            return Page();
  


        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        private async Task SeedRoles()
        {
            bool roleAdminExists = await _roleManager.RoleExistsAsync("Administrator");

            if (roleAdminExists == false)
            {
                var role = new IdentityRole("Administrator");
                await _roleManager.CreateAsync(role);

            }

            bool roleMunicipalExists = await _roleManager.RoleExistsAsync("UserMun");

            if (roleMunicipalExists == false)
            {
                var role = new IdentityRole("UserMun");
                await _roleManager.CreateAsync(role);

            }

        }

        private async Task SeedRolesToUsers()
        {
            var admin = await _userManager.FindByEmailAsync("adminDebt@mail.bg");

            if (admin != null)
            {
                await _userManager.AddToRoleAsync(admin, "Administrator");
            }

            var burgasUser = await _userManager.FindByEmailAsync("burgas_municipal@mail.bg");
            if (burgasUser != null)
            {
                await _userManager.AddToRoleAsync(burgasUser, "UserMun");
            }

            var varnaUser = await _userManager.FindByEmailAsync("VarnaMun@mail.com");
            if (varnaUser != null)
            {
                await _userManager.AddToRoleAsync(varnaUser, "UserMun");
            }
        }

        private async Task FillMunicipalities()
        {
            var municipalities = await _municipalityService.GetAllMunicipalitiesAsync();
            ////Populate the Regions dropdown list
            Municipalities = municipalities
                .Select(m => new SelectListItem
                {
                    Value = m.MunicipalityId.ToString(),  // or just m.Id depending on your data type
                    Text = m.MunicipalityName
                }).ToList();

        }

        private async Task AddUserToRole(ApplicationUser user)
        {
            await _userManager.AddToRoleAsync(user, "UserMun");
        }
    }
}
