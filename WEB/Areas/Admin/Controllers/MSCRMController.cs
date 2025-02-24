using Application.Contracts.InterfaceServices.Address;
using Application.Contracts.InterfaceServices.MSCRM;
using Application.DTOs.Address.CRUD;
using Application.DTOs.MSCRMdto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB.Areas.Admin.Controllers
{
    public class MSCRMController : AdminBaseController
    {
        #region ctor DI

        private readonly IAddressService _addressService;
        private readonly IMSCRMService _mscrmService;

        public MSCRMController(IAddressService addressService, IMSCRMService mSCRMService)
        {
            _addressService = addressService;
            _mscrmService = mSCRMService;
        }

        #endregion

        #region Marketer

        [HttpGet("add-marketer")]
        public async Task<IActionResult> AddMarketer()
        {
            var list = await _mscrmService.GetListEmployeesCRM();
            ViewBag.Employees = list; // ارسال لیست به ویو

            var provinces = await _addressService.GetAllProvincesAsync();
            ViewBag.Provinces = new SelectList(provinces, "Id", "Name");

            return View();
        }

        [HttpPost("add-marketer")]
        public async Task<IActionResult> AddMarketer([FromBody] AddMarketerDTO addMarketer)
        {
            if (addMarketer == null || addMarketer.EmployeeId == 0 || addMarketer.ProvinceId == 0 ||
                addMarketer.CityId == 0 || addMarketer.RegionId == 0)
            {
                return Json(new { success = false, message = "تمام فیلدها را پر کنید!" });
            }

           // try
            //{
                await _mscrmService.AddMarketer(addMarketer) ;
                return Json(new { success = true });
            //}
            //catch (Exception ex)
            //{
                //return Json(new { success = false, message = "خطا در ذخیره‌سازی اطلاعات!" });
            //}
        }



        #endregion


        #region Region

        [HttpGet("get-regions/{provinceId}/{cityId}")]
        public async Task<IActionResult> GetRegions(int provinceId, int cityId)
        {
            var regions = await _addressService.GetListRegionsByProvincesAndCity(provinceId, cityId);

            return Json(regions);
        }



        [HttpGet("add-region")]
        public async Task<IActionResult> AddRegion()
        {
            var provinces = await _addressService.GetAllProvincesAsync();
            ViewBag.Provinces = new SelectList(provinces, "Id", "Name");
            return View();
        }

        [HttpPost("add-region")]
        public async Task<IActionResult> AddRegion(CreateRegionDto dto)
        {
            if (string.IsNullOrEmpty(dto.CityId.ToString()))
            {
                TempData[WarningMessage] = $"{dto.CityId}, لطفاً یک شهر انتخاب کنید.";
            }

            if (!ModelState.IsValid)
                return View(dto);

            // بررسی تکراری بودن نام منطقه
            bool isDuplicate = await _addressService.CheckDuplicateRegionName(dto);
            if (isDuplicate)
            {
                TempData[ErrorMessage] = "نام منطقه قبلاً برای این استان و شهر ثبت شده است.";
                return RedirectToAction("AddRegion");
            }

            // ایجاد منطقه
            await _addressService.CreateRegionAsync(dto);

            // ارسال پیام موفقیت
            TempData[SuccessMessage] = "منطقه با موفقیت ثبت شد.";

            return RedirectToAction("AddRegion");
        }


        [HttpGet("get-cities/{provinceId}")]
        public async Task<IActionResult> GetCities(int provinceId)
        {
            var cities = await _addressService.GetCitiesByProvinceIdAsync(provinceId);

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(cities)); // ✅ بررسی مقدار `Id`

            return Json(cities);
        }

        #endregion

    }
}
