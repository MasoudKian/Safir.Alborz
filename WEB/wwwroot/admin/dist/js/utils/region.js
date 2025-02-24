
debugger;
// add region
document.addEventListener("click", async function (event) {
    if (event.target && event.target.id === "submitBtnRegion") {
        event.preventDefault();

        //دریافت مقادیر درست از فیلدها
        // دریافت مقادیر فیلدها
        let province = document.getElementById("province")?.value.trim();
        let city = document.getElementById("city")?.value.trim();
        let name = document.getElementById("validation-form-1")?.value.trim();

        // بررسی مقدار نال یا خالی بودن فیلدها
        if (!province || !city || !name) {
            window.location.reload();
        }

        debugger;
        // ارسال اطلاعات با استفاده از FormData
        let formData = new FormData();
        formData.append("ProvinceId", province);
        formData.append("CityId", city);
        formData.append("Name", name);


        fetch("/add-region", {
            method: "POST",
            body: formData,
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    window.location.reload();
                } else {
                    window.location.reload();
                }
            })
            .catch(error => {
                console.error("Error:", error);
            });
    };

});
// add region

// get cities
document.addEventListener("DOMContentLoaded", function () {
    var provinceDropdown = document.getElementById("province");
    var cityDropdown = document.getElementById("city");

    provinceDropdown.addEventListener("change", function () {
        var provinceId = provinceDropdown.value;

        if (provinceId) {
            fetch(`/get-cities/${provinceId}`)
                .then(response => response.json())
                .then(data => {
                    cityDropdown.innerHTML = '<option value="">انتخاب شهر</option>';

                    data.forEach(city => {
                        console.log("شهر دریافت شده:", city); // ✅ بررسی مقدار `Id`

                        var option = document.createElement("option");
                        option.value = city.id;  // ✅ مقدار `id` را بررسی کن
                        option.textContent = city.name;
                        cityDropdown.appendChild(option);
                    });
                })
                .catch(error => console.error('خطا در دریافت اطلاعات:', error));
        } else {
            cityDropdown.innerHTML = '<option value="">انتخاب شهر</option>';
        }
    });
});
// get cities


//  Get Regions
document.addEventListener("DOMContentLoaded", function () {
    const provinceDropdown = document.getElementById("province");
    const cityDropdown = document.getElementById("city");
    const regionDropdown = document.getElementById("region");

    function loadRegions() {
        const provinceId = provinceDropdown.value;
        const cityId = cityDropdown.value;

        if (provinceId && cityId) {
            fetch(`/get-regions/${provinceId}/${cityId}`)
                .then(response => response.json())
                .then(data => {
                    regionDropdown.innerHTML = '<option value="">انتخاب منطقه</option>';
                    data.forEach(region => {
                        const option = document.createElement("option");
                        option.value = region.id;
                        option.textContent = region.name;
                        regionDropdown.appendChild(option);
                    });
                })
                .catch(error => console.error("Error fetching regions:", error));
        }
    }

    provinceDropdown.addEventListener("change", loadRegions);
    cityDropdown.addEventListener("change", loadRegions);
});
//  Get Regions 

// Add Marketer
document.addEventListener("click", async function (event) {
    if (event.target && event.target.id === "submitMarketer") {
        event.preventDefault();

        let employee = document.getElementById("employee")?.value;
        let province = document.getElementById("province")?.value;
        let city = document.getElementById("city")?.value;
        let region = document.getElementById("region")?.value;

        // ارسال اطلاعات به سرور
        let formData = {
            EmployeeId: employee,
            ProvinceId: province,
            CityId: city,
            RegionId: region
        };

        fetch("/add-marketer", {
            method: "POST",
            body: JSON.stringify(formData),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // صفحه را رفرش کن تا پیام TempData نمایش داده شود
                    window.location.reload();
                } else {
                    window.location.reload();
                }
            })
            .catch(error => {
                console.error("Error:", error);
            });
    };

});



// add marketer


