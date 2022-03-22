using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Model.DbContexts;
using Zave.Torbat.Siman.Model.Models1.Factory;
//using Zave.Torbat.Siman.Model.Models.Factory;
using Zave.Torbat.Siman.Model.Repositories;
using Zave.Torbat.Siman.Server.Model;
using Zave.Torbat.Siman.Server.Services;

namespace Zave.Torbat.Siman.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly UserManager<TTruck> _userManager;
        //private readonly SignInManager<TTruck> _signInManager;
        private readonly DriversRepository _driversRepository;
        private readonly IConfirmationService _confirmationService;
        private readonly TruckRepository _truckRepository;
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly TerminalRepository _terminalRepository;

        public AccountController(DriversRepository driverRepository,IConfirmationService confirmationService,TruckRepository truckRepository,ApplicationSignInManager applicationSignInManager,TerminalRepository terminalRepository)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            _driversRepository = driverRepository;
            _confirmationService = confirmationService;
            _truckRepository = truckRepository;
            _applicationSignInManager = applicationSignInManager;
            _terminalRepository = terminalRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            //var user = new TTruck() { Card = credentials.CardNumber, NationalCode = credentials.NationalId };

            //var result = await _userManager.CreateAsync(user, credentials.NationalId);
            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}

            //await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            var truck = await _truckRepository.FirstOrDefaultAsync(t =>
                t.Card.Equals(credentials.CardNumber) && t.NationalCode.Equals(credentials.NationalId));
            if (truck==null)
            {
                return BadRequest();
            }

            //truck.UserName = credentials.CardNumber;
            //truck.PasswordHash = _userManager.PasswordHasher.HashPassword(truck, credentials.NationalId);
            //truck.Email = "new@gmail.com";
            //truck.Id=truck.GetHashCode().ToString();
            //truck.ConcurrencyStamp = HashCode.Combine(DateTime.Now, truck).GetHashCode().ToString();
            //truck.SecurityStamp = truck.ConcurrencyStamp;
            //truck.NormalizedEmail = truck.Email.Normalize();
            //truck.NormalizedUserName = truck.UserName.Normalize();
            //_truckRepository.Attach(truck);
            //await _truckRepository.SaveChangesAsync();

            var result =
                await _applicationSignInManager.SignInUserAsync(credentials.CardNumber, credentials.NationalId);//_signInManager.PasswordSignInAsync(credentials.CardNumber,credentials.NationalId,false, false));
            if (!result)
                return BadRequest();

            //var user = await _userManager.FindByIdAsync(credentials.CardNumber);
            //var token = CreateToken(user);
            //user.AccessToken = token;
            //_userDbContext.Attach(user);
            // await _userDbContext.SaveChangesAsync();
            truck = await _truckRepository.FirstOrDefaultAsync(t =>
                t.Card.Equals(credentials.CardNumber) && t.NationalCode.Equals(credentials.NationalId));
            return Ok(truck.Token);
        }

        [HttpPost("logout")]
        //[CustomAuthorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _applicationSignInManager.SignOutUser();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
        [HttpGet("userData")]
        [CustomAuthorize]
        public async Task<IActionResult> GetUserData()
        {

            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type.Equals(Constant.CardNumberClaimTypeString))?.Value;
            var truck =await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));

            if (truck == null)
                return BadRequest();

            TruckViewModel truckViewModel = new TruckViewModel
            {
                DriverName = truck.DriverName,
                CardNumber = cardNumber,
                PhoneNumber = truck.Mobile,
                //PhoneNumberConfirmed = truck.PhoneNumberConfirmed
            };

            return Ok(truckViewModel);
        }

        
        //[HttpGet("confirmPhone")]
        //[Authorize]
        //public async Task<IActionResult> ConfirmPhoneNumber()
        //{
        //    var userId = HttpContext.User.Claims.SingleOrDefault(claim => claim.Value != null)?.Value;
        //    var user = _userDbContext.Users.SingleOrDefault(user1 => user1.Id.Equals(userId));
        //    if (user == null)
        //        return BadRequest();
        //    var confirmationResult = await _confirmationService.ConfirmPhoneNumberBySmsAsync(user.PhoneNumber);
        //    if (confirmationResult!=null)
        //    {
        //        return ValidationProblem(new ValidationProblemDetails() {Detail = "Phone Confirmation Failed"});
        //    }

        //    user.PhoneNumberConfirmed = true;
        //    _userDbContext.Attach(user);
        //    await _userDbContext.SaveChangesAsync();

        //    return Ok();
        //}
        //string CreateToken(TTruck user)
        //{
        //    var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, user.Card) };
        //    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is a secret phrase"));
        //    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        //    var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);
        //    return new JwtSecurityTokenHandler().WriteToken(jwt);//.CreateEncodedJwt(new SecurityTokenDescriptor(){EncryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vahid")),EncryptionAlgorithm.AES_128_CBC.ToString() )});//.WriteToken(jwt);
        //}
        private List<string> GetRelatedProducts(TTruck truck)
        {
            var products = new List<string>();
            var truckType = truck.Truck;
            if (truckType.Equals("بونکر تریلی") || truckType.Equals("بونکر ده چرخ"))
            {
                products.Add("فله");
            }
            else if (truckType.Equals("تک باری") || truckType.Equals("ده چرخ باری") || truckType.Equals("تریلی کفی"))
            {
                products.Add("پاکتی");
                products.Add("بیگ بگ");
            }
            else
            {
                products.Add("کلینکر");
            }

            return products;
        }
    }
}