using Application.Contracts.InterfaceServices.Address;
using Application.DTOs.Address.CRUD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB.Areas.Admin.Controllers
{
    public class MSCRMController : AdminBaseController
    {
        #region ctor DI

        private readonly IAddressService _addressService;

        public MSCRMController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        #endregion

        #region Marketer



        #endregion


        #region Region

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
            Console.WriteLine($"CityId: {dto.CityId}");

            if (string.IsNullOrEmpty(dto.CityId.ToString()))
            {
                ModelState.AddModelError("CityId", "لطفاً یک شهر انتخاب کنید.");
            }

            if (!ModelState.IsValid)
                return View(dto);

            // ایجاد منطقه
            await _addressService.CreateRegionAsync(dto);

            // استفاده از TempData برای ارسال پیام به ویو
            TempData["SuccessMessage"] = "منطقه با موفقیت ثبت شد.";

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
