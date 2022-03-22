using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Zave.Torbat.Siman.Model.Repositories;
using Zave.Torbat.Siman.Server.Model;

namespace Zave.Torbat.Siman.Server.Services
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute:AuthorizeAttribute,IAuthorizationFilter
    {
        private readonly TruckRepository _truckRepository;

        public CustomAuthorizeAttribute()//TruckRepository truckRepository)
        {
            //_truckRepository = truckRepository;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _truckRepository =(TruckRepository) context.HttpContext.RequestServices.GetService(typeof(TruckRepository));
            var token=context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var tokenResult=new JwtSecurityTokenHandler().ReadJwtToken(token);
            var cardNumber = tokenResult.Claims.SingleOrDefault(c => c.Type.Equals(Constant.CardNumberClaimTypeString))?.Value;//JwtRegisteredClaimNames.Sub))?.Value;
            if (string.IsNullOrEmpty(cardNumber))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var truck = _truckRepository.FirstOrDefault(t => t.Token.Equals(token) && t.Card.Equals(cardNumber));
            if (truck==null)
            {
                context.Result=new UnauthorizedResult();
                return;
            }

            if (!truck.IsLoggedIn)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
