using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zave.Torbat.Siman.Model.Models1.Factory;
using Zave.Torbat.Siman.Model.Repositories;
using Zave.Torbat.Siman.Server.DTO;
using Zave.Torbat.Siman.Server.Model;
using Zave.Torbat.Siman.Server.Services;

namespace Zave.Torbat.Siman.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeLoadController : ControllerBase
    {
        private readonly DriversRepository _driversRepository;
        private readonly TruckRepository _truckRepository;
        private readonly ITakeLoadTimeoutService _takeLoadTimeoutService;
        private readonly BarRepository _barRepository;
        private readonly InputBarRepository _inputBarRepository;
        private readonly TruckTypeRepository _truckTypeRepository;
        private readonly TruckTurnRepository _truckTurnRepository;
        private readonly IFarazSendSms _smsService;
        private readonly NewTerminalRepository _newTerminalRepository;

        public TakeLoadController(DriversRepository driversRepository, TruckRepository truckRepository,
            ITakeLoadTimeoutService takeLoadTimeoutService,
            BarRepository barRepository, InputBarRepository inputBarRepository, TruckTypeRepository truckTypeRepository,
            TruckTurnRepository truckTurnRepository, IFarazSendSms smsService,
            NewTerminalRepository newTerminalRepository)
        {
            _driversRepository = driversRepository;
            _truckRepository = truckRepository;
            _takeLoadTimeoutService = takeLoadTimeoutService;
            _barRepository = barRepository;
            _inputBarRepository = inputBarRepository;
            _truckTypeRepository = truckTypeRepository;
            _truckTurnRepository = truckTurnRepository;
            _smsService = smsService;
            _newTerminalRepository = newTerminalRepository;
        }


        [HttpGet("getTowns")]
        [CustomAuthorize]
        public async Task<IActionResult> GetTowns()
        {

            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));//.FindById(userId);

            if (truck == null)
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }

            if (truck.Delete.GetValueOrDefault(false) || !truck.Enable.GetValueOrDefault(false))
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }

            var availableTowns = _barRepository.All().ToList().Where(bar =>
                bar.Terminal.Equals(truck.Terminal) &&
                bar.Date.GetValueOrDefault(DateTime.MinValue).Date.Equals(DateTime.Now.Date) &&
                GetTruckTypes(bar.TruckType).Contains(truck.Truck) && bar.SelectTruck == false &&
                bar.Deletedd == false &&
                bar.Free == false && bar.Back == false).ToList();
            var townNames=availableTowns.Select(bar=>bar.CityName).ToList();
            return Ok(townNames);
        }

        [HttpGet]
        [CustomAuthorize]
        public async Task<IActionResult> GetLoadsData(string townName)
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));//.FindById(userId);

            if (truck == null)
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }
            var availableLoads=_barRepository.All().ToList().Where(bar =>
                bar.Terminal.Equals(truck.Terminal) &&
                bar.Date.GetValueOrDefault(DateTime.MinValue).Date.Equals(DateTime.Now.Date) &&
                GetTruckTypes(bar.TruckType).Contains(truck.Truck) && bar.SelectTruck == false &&
                bar.Deletedd == false &&
                bar.Free == false && bar.Back == false && bar.CityName == townName).ToList();
            //var availableLoads = _barRepository.Where(bar =>
            //    bar.Terminal.Equals(truck.Terminal) && bar.Date.Value.Date.Equals(DateTime.Now.Date) &&
            //    GetTruckTypes(bar.TruckType).Contains(truck.Truck)&& bar.SelectTruck == false && bar.Deletedd == false &&
            //    bar.Free == false && bar.Back == false && bar.CityName == townName);

            var takeLoadModel = new List<Load>();
            foreach (var availableLoad in availableLoads)
            {
                var load = new Load
                {
                    BossName = availableLoad.NameBoss,
                    Amount = availableLoad.Ton ?? 0,
                    CustomerName = availableLoad.Name,
                    Product = availableLoad.Product,
                    HandOverAddress = availableLoad.Destination,
                    TransportationType = availableLoad.Haml,
                    HandOverTime = availableLoad.TimeTakhlie,
                    LoadId = availableLoad.Row
                };
                takeLoadModel.Add(load);
            }
            //{
            //    new Load()
            //    {
            //        Amount = 10, CustomerName = "حسن کریمی", HandOverAddress = "خ مصلا، پلاک 33، جاده قدیم",
            //        Object = "تیر آهن", Street = "یگانه", Town = "مشهد", Type = "پاکت"
            //    },
            //    new Load()
            //    {
            //        Amount = 30, CustomerName = "کرمعلی حسینی", HandOverAddress = "جاده نیشابور، سنگبری حسینی",
            //        Object = "سنگ", Street = "شهید مددی", Town = "مشهد", Type = "بیگ بگ"
            //    },
            //    new Load()
            //    {
            //        Amount = 35, CustomerName = "عماد عنایتی",
            //        HandOverAddress = "اتوبان شهید بابایی، جاده ارتش، تالار فرمانداری",
            //        Object = "سیمان", Street = "ارتش", Town = "تهران", Type = "کلینکر"
            //    },
            //    new Load()
            //    {
            //        Amount = 40, CustomerName = "حسین محمودی",
            //        HandOverAddress = "خ مصلا، پلاک 33، جاده سوزنبان، راه آهن",
            //        Object = "تیر آهن", Street = "یگانه", Town = "مشهد", Type = "پاکت"
            //    },
            //    new Load()
            //    {
            //        Amount = 10, CustomerName = "حسن کریمی", HandOverAddress = "خ مصلا، پلاک 33، جاده قدیم",
            //        Object = "تیر آهن", Street = "یگانه", Town = "مشهد", Type = "بیگ بگ"
            //    },
            //    new Load()
            //    {
            //        Amount = 30, CustomerName = "کرمعلی حسینی", HandOverAddress = "جاده نیشابور، سنگبری حسینی",
            //        Object = "سنگ", Street = "شهید مددی", Town = "مشهد", Type = "پاکت"
            //    },
            //    new Load()
            //    {
            //        Amount = 35, CustomerName = "عماد عنایتی",
            //        HandOverAddress = "اتوبان شهید بابایی، جاده ارتش، تالار فرمانداری",
            //        Object = "سیمان", Street = "ارتش", Town = "تهران", Type = "کلینکر"
            //    },
            //    new Load()
            //    {
            //        Amount = 40, CustomerName = "حسین محمودی",
            //        HandOverAddress = "خ مصلا، پلاک 33، جاده سوزنبان، راه آهن",
            //        Object = "تیر آهن", Street = "یگانه", Town = "مشهد", Type = "بیگ بگ"
            //    },
            //    new Load()
            //    {
            //        Amount = 10, CustomerName = "حسن کریمی", HandOverAddress = "خ مصلا، پلاک 33، جاده قدیم",
            //        Object = "تیر آهن", Street = "یگانه", Town = "مشهد", Type = "بیگ بگ"
            //    },
            //    new Load()
            //    {
            //        Amount = 30, CustomerName = "کرمعلی حسینی", HandOverAddress = "جاده نیشابور، سنگبری حسینی",
            //        Object = "سنگ", Street = "شهید مددی", Town = "مشهد", Type = "پاکت"
            //    },
            //    new Load()
            //    {
            //        Amount = 35, CustomerName = "عماد عنایتی",
            //        HandOverAddress = "اتوبان شهید بابایی، جاده ارتش، تالار فرمانداری",
            //        Object = "سیمان", Street = "ارتش", Town = "تهران", Type = "کلینکر"
            //    },
            //    new Load()
            //    {
            //        Amount = 40, CustomerName = "حسین محمودی",
            //        HandOverAddress = "خ مصلا، پلاک 33، جاده سوزنبان، راه آهن",
            //        Object = "تیر آهن", Street = "یگانه", Town = "مشهد", Type = "پاکت"
            //    },
            //};
            
            //var user = await _userMana{ger.FindByEmailAsync(credentials.CardNumber);
            return Ok(takeLoadModel);
        }

        [HttpPost("selectLoad")]
        [CustomAuthorize]
        public async Task<IActionResult> SelectLoad([FromBody] Load load)
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));//.FindById(userId);

            if (truck == null || truck.Delete.GetValueOrDefault(false) || !truck.Enable.GetValueOrDefault(false))
            {
                return new ZaveServerResultModel(NotFound().StatusCode) {ErrorResult = ErrorResult.TruckNotFound};
            }

            var driver = await _driversRepository.FirstOrDefaultAsync(drv => drv.Row.Equals(truck.RowDriver));
            var truckType = await _truckTypeRepository.FirstOrDefaultAsync(tt => tt.Truck.Equals(truck.Truck));
            var dataLoad = await _barRepository.FirstOrDefaultAsync(b => b.Row.Equals(load.LoadId));
            var truckTurn = await _truckTurnRepository.FirstOrDefaultAsync(tt => tt.Pelak.Equals(truck.Pelak));

            var inputBar = new TInputBarNew
            {
                CarType = dataLoad.TruckType,
                Pelak = truck.Pelak,
                Driver = truck.DriverName,
                NumCertificates = driver.CertificateNum,
                Capacity = 0,
                Mobail = driver.Mobile,
                Product = load.Product,
                Havale = "*",
                NameBoss = load.BossName,
                Name = dataLoad.Name,
                Ton = dataLoad.Ton,
                Destination = load.HandOverAddress,
                Haml = dataLoad.Haml,
                TimeTakhlie = dataLoad.TimeTakhlie,
                Tozihat = dataLoad.Description,
                Date = DateTime.Now,
                Time = DateTime.Now.ToString(),
                Terminal = dataLoad.Terminal,
                Cansel = false,
                In = false,
                RowSale = long.Parse(dataLoad.RowSale),
                DateHavale = dataLoad.DateHavale,
                CarCode = truck.Card,
                Barbari = dataLoad.Barbari,
                Out = false,
                CountryCode = dataLoad.CountryCode,
                ProvinceCode = dataLoad.ProvinceCode,
                CityCode = dataLoad.CityCode,
                Status = dataLoad.Status,
                Zarfiat = truckType.Ton,
                Nobat = truckTurn.Turn,
                CustomMobail = dataLoad.Mobail,
                Loading = false,
                Saderat = dataLoad.Saderat,
                PS = false,
                UserEdit = null,
                DateEdit = null,
                DisEdit = null,
                Description = dataLoad.Description,
                Bakhsh = dataLoad.Bakhsh,
                Takhlieh = dataLoad.Takhlieh,
                CrmCodeB = dataLoad.CrmCodeB,
                CrmCodeC = dataLoad.CrmCodeC
            };

            _inputBarRepository.Add(inputBar);
            await _inputBarRepository.SaveChangesAsync();

            return Ok(load);
        }

        [HttpGet("selectedLoadInfo")]
        [CustomAuthorize]
        public async Task<IActionResult> GetSelectedLoadInfo()
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = _truckRepository.FirstOrDefault(t => t.Card.Equals(cardNumber));//.FindById(userId);
            var loadInfo = new LoadInfoDataModel();

            if (truck == null)
            {
                return new ZaveServerResultModel(NotFound().StatusCode){ErrorResult = ErrorResult.TruckNotFound};
            }
            var inputBar = await _inputBarRepository.FirstOrDefaultAsync(ib => ib.Out == false && ib.Pelak.Equals(truck.Pelak));

            loadInfo.Product = inputBar.Product;
            loadInfo.BossName = inputBar.NameBoss;
            loadInfo.CustomerName = inputBar.Name;
            loadInfo.DestinationAddress = inputBar.Destination;
            loadInfo.HandoverTime = inputBar.TimeTakhlie;
            loadInfo.LoadingType = inputBar.Haml;
            loadInfo.Weight = inputBar.Ton.GetValueOrDefault(0).ToString();
            
            return Ok(loadInfo);
        }

        [HttpPost("loadSelected")]
        [CustomAuthorize]
        public async Task<IActionResult> PostLoadSelected([FromBody] Load selectedLoad)
        {
            var cardNumber = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == Constant.CardNumberClaimTypeString)?.Value;
            var truck = await _truckRepository.FirstOrDefaultAsync(t => t.Card.Equals(cardNumber));
            if (truck == null)
            {
                return new ZaveServerResultModel(NotFound().StatusCode) { ErrorResult = ErrorResult.TruckNotFound };
            }

            var newTerminal = await _newTerminalRepository.FirstOrDefaultAsync(t => t.Name.Equals(truck.Terminal));
            if (newTerminal!=null && (DateTime.Now-DateTime.Parse(selectedLoad.EnableTime)).TotalSeconds > newTerminal.DeleteNobat.GetValueOrDefault(10000))// _takeLoadTimeoutService.IsTimeOut())
            {
                return new ZaveServerResultModel(406) { ErrorResult = ErrorResult.LoadSelectTimeout };
            }
            var load = await _barRepository.FirstOrDefaultAsync(l => l.Row.Equals(selectedLoad.LoadId));

            var currentRow = await _inputBarRepository.CountAsync();
            var inputLoad = new TInputBarNew
            {
                Pelak = truck.Pelak,
                Haml = selectedLoad.TransportationType,
                TimeTakhlie = selectedLoad.HandOverTime,
                Date = DateTime.Now,
                Out = false,
                Description = load.Description,
                Product = load.Product,
                NameBoss = selectedLoad.BossName,
                Name = selectedLoad.CustomerName,
                Ton = selectedLoad.Amount,
                Bakhsh = load.Bakhsh,
                Barbari = load.Barbari,
                Cansel = false,
                Capacity = (int?) selectedLoad.Amount,
                CarCode = truck.Card,
                CarType = truck.Truck,
                CityCode = load.CityCode,
                CountryCode = load.CountryCode,
                CrmCodeB = load.CrmCodeB,
                CrmCodeC = load.CrmCodeC,
                CustomMobail = load.Mobail,
                Destination = load.Destination,
                Driver = truck.DriverName,
                Loading = false,
                ProvinceCode = load.ProvinceCode,
                Terminal = load.Terminal,
                //Row = currentRow++
            };
            load.SelectTruck = true;
            _barRepository.Attach(load);
            await _barRepository.SaveChangesAsync();

            _inputBarRepository.Add(inputLoad);
            await _inputBarRepository.SaveChangesAsync();
            var result = await _smsService.SendLoadSms(truck.Mobile, Constant.TakeLoadTimeOut.ToString());
            return Ok();
            //inputLoad.Takhlieh = 
            //inputLoad.Nobat=
        }

        private List<string> GetTruckTypes(string truckType)
        {
            List<string> truckTypes=new List<string>();
            if (truckType.Equals("1"))
            {
                truckTypes.Add("تک باری");
                truckTypes.Add("تک کمپرس");
            }
            else if (truckType.Equals("2"))
            {
                truckTypes.Add("ده چرخ باری");
                truckTypes.Add("ده چرخ کمپرس");
            }
            else if (truckType.Equals("3"))
            {
                truckTypes.Add("تریلی کمپرس");
                truckTypes.Add("تریلی کفی");
            }
            else
            {
                truckTypes.Add(truckType);
            }

            return truckTypes;
        }
    }
}