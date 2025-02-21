// add region
document.addEventListener("DOMContentLoaded", function () {
    let submitBtn = document.getElementById("submitBtn");
    if (submitBtn) {
        submitBtn.addEventListener("click", function (event) {
            event.preventDefault();

            // دریافت مقادیر درست از فیلدها
            let province = document.getElementById("province")?.value;
            let city = document.getElementById("city")?.value;
            let name = document.getElementById("validation-form-1")?.value;
            

            // اعتبارسنجی مقدار استان
            if (!province || province.trim() === "" || province === "0") {
                Swal.fire({
                    icon: 'error',
                    title: 'خطا!',
                    text: 'لطفاً یک استان را انتخاب کنید.',
                    confirmButtonText: 'باشه'
                });
                return;
            }

            // اعتبارسنجی مقدار شهر
            if (!city || city.trim() === "" || city === "0") {
                Swal.fire({
                    icon: 'warning',
                    title: 'خطا!',
                    text: 'لطفاً یک شهر را انتخاب کنید.',
                    confirmButtonText: 'متوجه شدم'
                });
                return;
            }

            // اعتبارسنجی مقدار نام منطقه
            if (!name || name.trim() === "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'خطا!',
                    text: 'لطفاً نام منطقه را وارد کنید.',
                    confirmButtonText: 'متوجه شدم'
                });
                return;
            }

           

            // اگر همه فیلدها پر باشند، فرم ارسال شود
            document.getElementById("regionForm").submit();
        });
    } else {
        console.error("دکمه ارسال فرم (submitBtn) یافت نشد!");
    }
});
// add region



// تابعی برای حذف پیام بعد از 5 ثانیه
setTimeout(function () {
    var messageDiv = document.getElementById("successMessage");
    if (messageDiv) {
        messageDiv.style.display = 'none'; // مخفی کردن پیام
    }
}, 3000); // 5000 میلی‌ثانیه = 5 ثانیه

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


// add marketer

document.addEventListener("DOMContentLoaded", function () {
    let submitBtn = document.getElementById("submitBtn");

    if (submitBtn) {
        submitBtn.addEventListener("click", function (event) {
            event.preventDefault();

            let employee = document.getElementById("employee")?.value;
            let province = document.getElementById("province")?.value;
            let city = document.getElementById("city")?.value;
            debugger;
            let region = document.getElementById("region").value;

       

            console.log("Region ID at submit:", region);


        

            
             //ارسال اطلاعات به سرور
            let formData = {
                EmployeeId: employee,
                ProvinceId: province,
                CityId: city,
                RegionId: region
            };
            alert(formData);

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
                        Swal.fire({
                            icon: 'success',
                            title: 'موفق!',
                            text: 'بازاریاب با موفقیت ثبت شد!',
                            confirmButtonText: 'باشه'
                        }).then(() => {
                            document.getElementById("marketerForm").reset();
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'خطا!',
                            text: 'مشکلی در ثبت اطلاعات پیش آمد!',
                            confirmButtonText: 'متوجه شدم'
                        });
                    }
                })
                .catch(error => {
                    console.error("Error:", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'خطا!',
                        text: 'مشکلی در ارتباط با سرور پیش آمد!',
                        confirmButtonText: 'باشه'
                    });
                });
        });
    } else {
        console.error("دکمه ارسال فرم (submitBtn) یافت نشد!");
    }
});


// add marketer


