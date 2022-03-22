using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zave.Torbat.Siman.Model.Repositories;
using Zave.Torbat.Siman.Server.Model;
using Zave.Torbat.Siman.Server.Services;

namespace Zave.Torbat.Siman.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneVerificationController : ControllerBase
    {
        public IConfirmationService VerificationService;
        private readonly DriversRepository _driversRepository;
        private readonly TruckRepository _truckRepository;

        public PhoneVerificationController(
            IConfirmationService verificationService, DriversRepository driversRepository,TruckRepository truckRepository)
        {
            this.VerificationService = verificationService;
            _driversRepository = driversRepository;
            _truckRepository = truckRepository;
        }

        [HttpPost("start")]
        [CustomAuthorize]
        public async Task<PhoneVerificationResponseModel> Start([FromBody] PhoneVerificationRequestModel verificationRequest)
        {
            var cardNumber =HttpContext.User.Claims.SingleOrDefault(claim => claim.Type.Equals(Constant.CardNumberClaimTypeString))?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));

            var response = new PhoneVerificationResponseModel
            {
                IsSuccessful = false,
                HtmlResult = BadRequest().StatusCode
            };
            if (truck == null)
            {
                response.Description = ResponseDescriptions.UserNotFound;
                return response;
            }
            if (ModelState.IsValid)
            {
                
                var verifyToken = GenerateConfirmationCode();
                var result = await VerificationService.ConfirmPhoneNumberBySmsAsync(
                    verificationRequest.PhoneNumber,
                    verifyToken

                );
                //sms sent successfully
                if (result.Result.Equals(""))//!string.IsNullOrEmpty(result.ReferenceCode) && result.Result.Equals("")))
                {
                    truck.PhoneVerificationToken = verifyToken;
                    _truckRepository.Attach(truck);
                    await _truckRepository.SaveChangesAsync();
                    response.IssueDateTime=DateTime.Now;
                    response.TimeOutSeconds = 120;
                    response.HtmlResult = Ok().StatusCode;
                    response.IsSuccessful = true;
                    response.Description = ResponseDescriptions.TokenGenerated;
                    return response;
                }
                else
                {
                    response.HtmlResult = 503;
                    response.Description = ResponseDescriptions.SmsSendFailed;
                    return response;
                }

            }
            else
            {
                response.Description = ResponseDescriptions.InvalidModelState;
                return response;
            }
        }

        [HttpPost("verify")]
        [CustomAuthorize]
        public async Task<TokenPhoneVerificationResponseModel> Verify([FromBody] TokenVerificationModel tokenVerification)
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));
            var response=new TokenPhoneVerificationResponseModel()
            {
                HtmlResult = BadRequest().StatusCode ,
                IsSuccessful = false
            };
            if (truck == null)
            {
                response.Description = ResponseDescriptions.UserNotFound;
                return response;
            }
            if (ModelState.IsValid)
            {
                if (tokenVerification.VerifyToken.Equals(null))//user.PhoneVerificationToken))
                {
                    response.Description = ResponseDescriptions.InvalidVerificationToken;
                    response.RequestCount = tokenVerification.RequestCount + 1;
                    return response;
                }

                if (tokenVerification.ExpirationTime<DateTime.Now)
                {
                    response.Description = ResponseDescriptions.VerificationTokenExpired;
                    response.RequestCount = tokenVerification.RequestCount + 1;
                    return response;
                }

                if (tokenVerification.RequestCount>5)
                {
                    response.Description = ResponseDescriptions.MaxRequestExceed;
                    response.RequestCount = tokenVerification.RequestCount + 1;
                    return response;
                }

                truck.PhoneNumberConfirmed = true;
                //user.PhoneNumberConfirmed = true;
                _truckRepository.Attach(truck);
                await _truckRepository.SaveChangesAsync();
                response.RequestCount = 0;
                response.HtmlResult = Ok().StatusCode;
                response.Description = ResponseDescriptions.VerifiedSuccessfully;
                response.IsSuccessful = true;
                return response;

            }
            else
            {
                response.Description = ResponseDescriptions.InvalidModelState;
                return response;
            }
        }
        private string GenerateConfirmationCode()
        {
            var confirmationCode = new StringBuilder();
            var random = new Random(DateTime.Now.Second);
            for (int i = 0; i < 5; i++)
            {
                confirmationCode.Append(random.Next(0, 10));
            }

            return confirmationCode.ToString();
        }
    }

}


