using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Zave.Torbat.Siman.Model.Models1.Factory;
using Zave.Torbat.Siman.Model.Repositories;
using Zave.Torbat.Siman.Server.Model;

namespace Zave.Torbat.Siman.Server.Services
{
    public class ApplicationSignInManager
    {
        private readonly TruckRepository _truckRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationSignInManager(TruckRepository truckRepository,IHttpContextAccessor httpContextAccessor)
        {
            _truckRepository = truckRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> SignInUserAsync(string cardNumber, string nationalId)
        {
            var truck=await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber) && t.NationalCode.Equals(nationalId));
            if (truck==null)
            {
                return false;//await Task<bool>.Factory.StartNew(() => false);
            }

            if (truck.IsLoggedIn)
            {
                return true;
            }

            var token = CreateToken(truck);
            truck.Token = token;
            truck.IsLoggedIn = true;
            _truckRepository.Attach(truck);
            await _truckRepository.SaveChangesAsync();
            return true;
        }

        public async Task SignOutUser()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            //var tt = _httpContextAccessor.HttpContext.RequestServices.GetService(typeof(TruckRepository));
            var truck =await _truckRepository.FirstOrDefaultAsync(t => t.Token.Equals(token));
            if (truck == null)
            {
                return;
            }

            truck.Token = "";
            truck.IsLoggedIn = false;
            _truckRepository.Attach(truck);
            await _truckRepository.SaveChangesAsync();
        }

       
        string CreateToken(TTruck user)
        {
            var claims = new[]
            {
                new Claim(Constant.CardNumberClaimTypeString, user.Card),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString())
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is a secret phrase"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(jwt);//.CreateEncodedJwt(new SecurityTokenDescriptor(){EncryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vahid")),EncryptionAlgorithm.AES_128_CBC.ToString() )});//.WriteToken(jwt);
        }
    }
}
