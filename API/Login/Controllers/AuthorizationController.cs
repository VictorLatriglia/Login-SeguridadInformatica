using Login.Models;
using Login.Services;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    [ApiController]
    public class AuthorizationController : Controller
    {
        Decryptor DecryptorService;
        DataAccess DataAccessService;
        public AuthorizationController(DataAccess dataAccessService)
        {
            DecryptorService = new Decryptor();
            DataAccessService = dataAccessService;
        }

        [HttpPost]
        [Route("LogIn")]
        public IActionResult Login(UserData userData)
        {
            var password = DecryptorService.Decrypt(userData.Password);

            return Ok(DataAccessService.CheckIfPasswordIsCorrect(userData.UserName, password));
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserData userData)
        {
            var password = DecryptorService.Decrypt(userData.Password);

            return Ok(DataAccessService.AddUser(
                new UserSavedInformation
                {
                    Email = userData.UserName,
                    Password = password
                }));
        }

    }
}
