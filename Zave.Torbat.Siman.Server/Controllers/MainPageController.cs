using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zave.Torbat.Siman.Model.Models1.Factory;
using Zave.Torbat.Siman.Model.Repositories;
using Zave.Torbat.Siman.Server.DTO;
using Zave.Torbat.Siman.Server.Model;
using Zave.Torbat.Siman.Server.Services;

namespace Zave.Torbat.Siman.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private readonly DriversRepository _driverRepository;
        private readonly TruckRepository _truckRepository;
        private readonly TruckTurnRepository _truckTurnRepository;
        private readonly BarRepository _barRepository;
        private readonly TruckTypeRepository _truckTypeRepository;
        private readonly TerminalRepository _terminalRepository;
        private readonly InputBarRepository _inputBarRepository;
        private readonly ITakeLoadTimeoutService _takeLoadTimeoutService;
        private readonly IFarazSendSms _smsService;
        private static int positionCounter = 4;

        public MainPageController(DriversRepository driverRepository, TruckRepository truckRepository,
            TruckTurnRepository truckTurnRepository, BarRepository barRepository,
            TruckTypeRepository truckTypeRepository, TerminalRepository terminalRepository,
            InputBarRepository inputBarRepository, ITakeLoadTimeoutService takeLoadTimeoutService,IFarazSendSms smsService)
        {
            _driverRepository = driverRepository;
            _truckRepository = truckRepository;
            _truckTurnRepository = truckTurnRepository;
            _barRepository = barRepository;
            _truckTypeRepository = truckTypeRepository;
            _terminalRepository = terminalRepository;
            _inputBarRepository = inputBarRepository;
            _takeLoadTimeoutService = takeLoadTimeoutService;
            _smsService = smsService;
        }

        // GET api/mainpage
        [HttpGet]
        [CustomAuthorize]
        public async Task<ActionResult<GetMainPageResponseModel>> Get()
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = _truckRepository.FirstOrDefault(t => t.Card.Equals(cardNumber));//.FindById(userId);
            var response = new GetMainPageResponseModel()
            {
                HtmlResult = BadRequest().StatusCode,
                IsSuccessful = false
            };
            if (truck == null)
            {
                response.Description = ResponseDescriptions.TruckNotFound;
                return response;
            }

            var driver = _driverRepository.FirstOrDefault(t => t.Row.Equals(truck.RowDriver));
            if (driver == null)
            {
                response.Description = ResponseDescriptions.UserNotFound;
                response.HtmlResult = NotFound().StatusCode;
                return response;
            }

            TInputBarNew inputBar = null;
            try
            {
                inputBar = await _inputBarRepository.FirstOrDefaultAsync(ib => ib.Out == false && ib.Pelak.Equals(truck.Pelak));
            }
            catch (Exception e)
            {
                //ignored
            }

            TTruckTurn truckTurn = null;
            try
            {
                truckTurn = await _truckTurnRepository.FirstOrDefaultAsync(
                    tt => tt.RowTruck.Equals(truck.Row) && tt.Deleted == false && tt.Enable == true
                );
            }
            catch (Exception e)
            {
                //ignored
            }

            var mainPageData = new MainPageDataModel
            {
                BeforeYouCount = "140",
                //_driverRepository.Trucks.Count(t => t.PositionNumber < truck.PositionNumber).ToString(),
                PositionNumber =
                    truckTurn == null
                        ? "-1"
                        : CurrentTurn(truck, truckTurn).ToString(), //truckTurn?.Turn.GetValueOrDefault(-1).ToString(),
                DriverNegativePoints = driver.Mistake.ToString(),
                DrivingLicenseDate = driver.CertificateDate.ToString(),
                HealthCardDate = driver.SalamatDate.ToString(),
                LastName = truck.DriverName,
                LoadingCardNumber = truck.Card,
                Name = "",
                PermittedLoadCount =
                    (await _barRepository.CountAsync(bar => bar.TruckType.Equals(truck.Truck))).ToString(),
                PositionSetDate = truckTurn?.TurnDate.ToString(),
                SmartCardDate = driver.HooshmandDate.ToString(),
                TerminalName = truck.Terminal,
                TruckInsuranceDate = truck.InsureDate.ToString(),
                TruckNegativePoints = truck.TruckMistake.ToString(),
                TruckTechnicalVisitDate = truck.TechDate.ToString(),
                TakeLoadAccess = GetAvailableTerminal(truck) != null,
                IsLoadPreSelected = inputBar != null
            };

            response.MainPageData = mainPageData;
            response.HtmlResult = Ok().StatusCode;
            response.IsSuccessful = true;
            return response;
        }

        [HttpGet("currentPosition")]
        [CustomAuthorize]
        public async Task<IActionResult> GetCurrentPosition()
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));//.FindById(userId);

            if (truck == null)
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }

            TTruckTurn truckTurn = null;
            try
            {
                truckTurn = await _truckTurnRepository.FirstOrDefaultAsync(tt =>
                    tt.RowTruck.Equals(truck.Row) && !tt.Deleted.GetValueOrDefault(false) && tt.Enable.GetValueOrDefault(false));
            }
            catch (Exception e)
            {
                //ignored
            }

            if (truckTurn == null)
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckTurnDeleted };
            }

            var currentTurn = CurrentTurn(truck, truckTurn);


            return Ok(currentTurn); //truck.PositionNumber);
        }



        [HttpPost("takeTurn")]
        [CustomAuthorize]
        public async Task<IActionResult> TakeTurn()
        {

            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));

            //var userId = HttpContext.User.Claims.SingleOrDefault(claim => claim.Value != null)?.Value;
            var user = await _driverRepository.FirstOrDefaultAsync(u => u.Row.Equals(truck.RowDriver));
            if (user == null || !user.Enable.GetValueOrDefault(false))
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.UserNotFound };
            }

            if (user.CertificateDate.GetValueOrDefault(DateTime.MaxValue) < DateTime.Now)
            {
                return new ZaveServerResultModel(BadRequest().StatusCode) { ErrorResult = ErrorResult.CertificateDateExpired };
            }

            if (user.HooshmandDate.GetValueOrDefault(DateTime.MaxValue) < DateTime.Now)
            {
                return new ZaveServerResultModel(BadRequest().StatusCode) { ErrorResult = ErrorResult.SmartCardDateExpired };
            }

            if (user.SalamatDate.GetValueOrDefault(DateTime.MaxValue) < DateTime.Now)
            {
                return new ZaveServerResultModel(BadRequest().StatusCode) { ErrorResult = ErrorResult.HealthCardDateExpired };
            }

            //var truck = await _truckRepository.FirstOrDefaultAsync(t =>
            //    t.RowDriver.Equals(user.Row)); //SingleOrDefault(t => t.UserId.Equals(userId));

            if (truck == null || truck.Delete.GetValueOrDefault(false) || !truck.Enable.GetValueOrDefault(false))
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }

            var relatedProducts = GetRelatedProducts(truck);

            TTruckTurn truckTurn;
            try
            {
                truckTurn = await _truckTurnRepository.FirstOrDefaultAsync(tt =>
                    tt.RowTruck.Equals(truck.Row) && !tt.Deleted.GetValueOrDefault(false) && tt.Enable.GetValueOrDefault(false));
                if (!truckTurn.Equals(default(TTruckTurn)))
                {
                    return Ok(truckTurn.Turn);
                }
            }
            catch (Exception e)
            {
                //ignored
            }



            //Get all trucks that have the same product of the asked truck
            var trucks = new List<TTruck>();
            foreach (var truck1 in _truckRepository.All())
            {
                var products = GetRelatedProducts(truck1);
                if (products.Any(rp => relatedProducts.Contains(rp)))
                {
                    trucks.Add(truck1);
                }
            }
            var truckRows = trucks//_truckRepository.Where(t => GetRelatedProducts(t).Any(rp => relatedProducts.AsQueryable().Contains(rp)))
                .Select(t => t.Row).ToList();
            int? lastTurn = 0;
            try
            {
                lastTurn = await _truckTurnRepository.Where(tt =>
                   tt.TurnDate.GetValueOrDefault(DateTime.MinValue).Date.Equals(DateTime.Now.Date) && truckRows.Contains(tt.RowTruck.GetValueOrDefault(-1))
                   ).MaxAsync(tt => tt.Turn);
            }
            catch (Exception e)
            {
                //ignored
            }


            var turn = lastTurn.GetValueOrDefault(0) + 1;

            truckTurn = new TTruckTurn
            {
                Turn = turn,
                InsertDateNobat = DateTime.Now,
                Deleted = false,
                TurnDate = DateTime.Now,
                P = false,//plake irani
                RowTruck = truck.Row,
                Terminal = truck.Terminal,
                Enable = true,
                Android = true,
                InsertMan = "Android",
            };
            _truckTurnRepository.Add(truckTurn);
            await _truckTurnRepository.SaveChangesAsync();

            if (relatedProducts.Count>1)
            {
                var smsResult = await _smsService.SendTurnSms(truck.Mobile, truck.Pelak, DateTime.Now.Date.ToString(), truck.Terminal, relatedProducts[0] +" "+relatedProducts[1],
                    turn.ToString());
            }
            else
            {
                var smsResult = await _smsService.SendTurnSms(truck.Mobile, truck.Pelak, DateTime.Now.Date.ToString(), truck.Terminal, relatedProducts[0],
                    turn.ToString());
            }
            return Ok(turn);
        }

        [HttpGet("takeLoadPermitted")]
        [CustomAuthorize]
        public async Task<IActionResult> TakeLoadPermitted(int positionNumber)
        {
            if (positionNumber > 1)
            {
                return new ZaveServerResultModel(BadRequest().StatusCode) { ErrorResult = ErrorResult.TakeLoadIsNotPermitted };
            }

            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));

            if (truck == null || truck.Delete.GetValueOrDefault(false) || !truck.Enable.GetValueOrDefault(false))
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }

            var selectedTerminal = GetAvailableTerminal(truck);
            if (selectedTerminal == null)
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TakeLoadIsNotPermitted };
            }

            //_takeLoadTimeoutService.Start(Constant.TakeLoadTimeOut);
            return Ok(Constant.TakeLoadTimeOut);
        }

        [HttpPost("cancelTurn")]
        [CustomAuthorize]
        public async Task<IActionResult> CancelTurn()
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));

            if (truck == null || truck.Delete.GetValueOrDefault(false) || !truck.Enable.GetValueOrDefault(false))
            {
                return new ZaveServerResultModel(BadRequest().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }

            var truckTurn = await _truckTurnRepository.FirstOrDefaultAsync(tt => tt.RowTruck.Equals(truck.Row) && !tt.Deleted.GetValueOrDefault(false) && tt.Enable.GetValueOrDefault(false));

            if (!truckTurn.Call1.GetValueOrDefault(false))
            {
                truckTurn.Call1 = true;
                truckTurn.DateCall1 = DateTime.Now;
                truckTurn.DeletedCall1 = truck.DriverName;
            }
            else
            {
                if (!truckTurn.Call2.GetValueOrDefault(false))
                {
                    truckTurn.Call2 = true;
                    truckTurn.DateCall2 = DateTime.Now;
                    truckTurn.DeletedCall2 = truck.DriverName;
                }
                else
                {
                    if (!truckTurn.Call3.GetValueOrDefault(false))
                    {
                        truckTurn.Call3 = true;
                        truckTurn.DateCall3 = DateTime.Now;
                        truckTurn.DeletedCall3 = truck.DriverName;
                    }
                    else
                    {
                        truckTurn.Deleted = true;
                    }
                }
            }

            truckTurn.Android = true;
            _truckTurnRepository.Attach(truckTurn);
            await _truckTurnRepository.SaveChangesAsync();
            return Ok();
        }

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

        private TNewTerminals GetAvailableTerminal(TTruck truck)
        {
            var relatedProducts = GetRelatedProducts(truck);

            var terminals = _terminalRepository.Where(t =>
                t.Enable.GetValueOrDefault(false) && t.StartTime.GetValueOrDefault(DateTime.MinValue) < DateTime.Now &&
                t.AndroidEnable.GetValueOrDefault(false) && !t.Delete.GetValueOrDefault(false) &&
                (t.NoeFale.GetValueOrDefault(0) != 0 || t.NoePakati.GetValueOrDefault(0) != 0 ||
                 t.NoeBigbag.GetValueOrDefault(0) != 0 || t.NoeClinker.GetValueOrDefault(0) != 0)).ToList();

            TNewTerminals selectedTerminal = null;
            foreach (var terminal in terminals)
            {
                if (relatedProducts.Contains("فله") && terminal.NoeFale.GetValueOrDefault(0) != 0)
                {
                    selectedTerminal = terminal;
                }
                else if (relatedProducts.Contains("پاکتی") && terminal.NoePakati.GetValueOrDefault(0) != 0)
                {
                    selectedTerminal = terminal;
                }
                else if (relatedProducts.Contains("بیگ بگ") && terminal.NoeBigbag.GetValueOrDefault(0) != 0)
                {
                    selectedTerminal = terminal;
                }
                else if (relatedProducts.Contains("کلینکر") && terminal.NoeClinker.GetValueOrDefault(0) != 0)
                {
                    selectedTerminal = terminal;
                }
            }

            return selectedTerminal;
        }

        private int CurrentTurn(TTruck truck, TTruckTurn truckTurn)
        {
            //Get all trucks that have the same product of the asked truck
            var relatedProducts = GetRelatedProducts(truck);
            var list = _truckRepository.All().ToList();

            var truckRows =
                (from truck1 in list
                 let relatedProducts1 = GetRelatedProducts(truck1)
                 where relatedProducts1.Any(rp => relatedProducts.Contains(rp))
                 select truck1).ToList();

            //var truckRows = _truckRepository.Where(t => GetRelatedProducts(t).Any(rp => relatedProducts.Contains(rp))).ToList();
            var truckRows1 = truckRows.Select(t => t.Row).ToList();

            var turns = _truckTurnRepository.Where(tt =>
                !tt.Deleted.GetValueOrDefault(false) && truckRows1.Contains(tt.RowTruck.GetValueOrDefault(-1)) &&
                (!tt.Call1.GetValueOrDefault(false) ||
                 !tt.Call2.GetValueOrDefault(false) ||
                 !tt.Call3.GetValueOrDefault(false)) && tt.Row <= truckTurn.Row).ToList();
            //var isContains = truckRows.Where(tt.RowTruck.GetValueOrDefault(-1));
            var currentTurn = turns.Count;
            return currentTurn;
        }
    }
}