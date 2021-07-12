using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdvancedImobiliaria.Interfaces;
using AdvancedImobiliaria.Models.Entities;
using AdvancedImobiliaria.Services.Hasher;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedImobiliaria.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordHasher _hasher;

        public UsersController(IUnitOfWork unitOfWork, PasswordHasher hasher)
        {
            _unitOfWork = unitOfWork;
            hasher = _hasher;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]ApplicationUser _user)
        {
            if(ModelState.IsValid)
            {
                var user = await _unitOfWork.PhysicalPerson.GetByEmail(_user.Email);

                if(user != null)
                {
                    var salt = _hasher.CreateSalt();
                    var result = _hasher.VerifyHash(_user.ProvidedPassword, salt, user.PasswordHash);

                    if(result)
                    {
                        var userClaims = new List<Claim>()
                        {
                            //define o cookie
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Email, user.Email),
                        };
                        var minhaIdentity = new ClaimsIdentity(userClaims, "Usuario");
                        var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
                        //cria o cookie
                        await HttpContext.SignInAsync(userPrincipal);
                        return RedirectToAction("Index", "Home");
                    }
                    
                    ViewBag.Message = "Senha incorreta";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Usuário não encontrado";
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ApplicationUser _user)
        {
            if(ModelState.IsValid)
            {
                var salt = _hasher.CreateSalt();
                _user.PasswordHash = _hasher.HashPassword(_user.ProvidedPassword, salt);

                //await _unitOfWork.PhysicalPerson.Add();
                await _unitOfWork.Complete();
            }

            return View();
        }
    }
}