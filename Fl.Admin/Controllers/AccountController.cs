﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Fl.Admin.Models;
using Fl.Data.Core.Identity;
using Fl.Data.DB;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Fl.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = null;

        private FlSignInManager _signInManager;
        private FlUserManager _userManager;

        public FlSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<FlSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public FlUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<FlUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AccountController(IUnitOfWork unitOfWork, FlSignInManager signInManager, FlUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}