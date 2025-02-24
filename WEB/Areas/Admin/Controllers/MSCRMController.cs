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
                TempData[WarningMessage] = "تمامی موارد باید انتخاب شوند!";
                return Json(new { success = false });
            }

            // بررسی تکراری نبودن بازاریاب
            bool exists = await _mscrmService.CheckMarketerExists(addMarketer.EmployeeId);
            if (exists)
            {
                TempData[ErrorMessage] = "این بازاریاب قبلاً ثبت شده است!";
                return Json(new { success = false});
            }

            try
            {
                await _mscrmService.AddMarketer(addMarketer);
                TempData[SuccessMessage] = "بازاریاب با موفقیت ثبت شد!";
                return Json(new { success = true });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "خطا در ذخیره‌سازی اطلاعات!";
                return Json(new { success = false });
            }
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
            if (string.IsNullOrEmpty(dto.Name) || 
                string.IsNullOrEmpty(dto.ProvinceId.ToString())
                || string.IsNullOrEmpty(dto.CityId.ToString()))
            {
                TempData[ErrorMessage] = "لطفاً همه فیلدها را پر کنید.";
                return Json(new { success = false });
            }

            bool isDuplicate = await _addressService.CheckDuplicateRegionName(dto);
            if (isDuplicate)
            {
                TempData[WarningMessage] = "نام منطقه قبلاً ثبت شده است.";
                return Json(new { success = false });
            }

            try
            {
                await _addressService.CreateRegionAsync(dto);
                TempData[SuccessMessage] = "منطقه با موفقیت ثبت شد.";
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "خطایی رخ داد! لطفاً مجدداً تلاش کنید.";
                return Json(new { success = false });
            }
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
