// ✅ Sidebar - هایلایت کردن لینک فعال در سایدبار
document.addEventListener("DOMContentLoaded", function () {
    const menuLinks = document.querySelectorAll(".side-menu__link");
    const currentPath = window.location.pathname; // آدرس صفحه‌ی فعلی

    menuLinks.forEach(link => {
        const linkPath = link.getAttribute("href");

        if (linkPath === currentPath) {
            link.classList.add("side-menu__link--active");
        } else {
            link.classList.remove("side-menu__link--active");
        }

        link.addEventListener("click", function () {
            menuLinks.forEach(item => item.classList.remove("side-menu__link--active"));
            this.classList.add("side-menu__link--active");
        });
    });
});

// ✅ مدیریت ارسال موقعیت شغلی (سمت)
document.addEventListener("click", async function (event) {
    if (event.target && event.target.id === "submit-position") {
        event.preventDefault();

        // دریافت مقدارهای ورودی
        const positionTitle = document.getElementById("position-name")?.value.trim();
        const departmentId = document.getElementById("position-department")?.value.trim();

        if (!positionTitle || !departmentId) {
            showAlertModal("لطفاً نام سمت و دپارتمان را وارد کنید.");
            return;
        }

        const data = {
            title: positionTitle,
            departmentId: parseInt(departmentId) // مقدار را به عدد تبدیل می‌کنیم
        };

        try {
            const response = await fetch("https://localhost:7156/api/v1/HumanResources/Create-Position", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data)
            });

            const result = await response.json();
            if (response.ok) {
                alert(result.message);
                location.reload(); // صفحه را مجدداً بارگذاری می‌کنیم
            } else {
                showAlertModal(result.message || "خطایی رخ داده است.");
            }
        } catch (error) {
            console.error("خطا در ارسال درخواست:", error);
            showAlertModal("خطایی در ارسال اطلاعات به سرور رخ داده است.");
        }
    }
});

// تابع برای نمایش مودال هشدار
function showAlertModal(message) {
    const alertModal = document.getElementById("alert-modal");
    const alertMessage = document.getElementById("alert-message");
    alertMessage.textContent = message;
    alertModal.classList.remove("hidden");
}

// مدیریت دکمه بستن مودال
document.getElementById("close-alert").addEventListener("click", function () {
    document.getElementById("alert-modal").classList.add("hidden");
});


// ✅ HumanResources - مدیریت ارسال دپارتمان
document.addEventListener("click", async function (event) {
    if (event.target && event.target.id === "submit-department") {
        event.preventDefault();

        let departmentName = document.getElementById("validation-form-1")?.value;
        let modal = document.getElementById("next-overlapping-modal-preview");
        let modalMessage = document.getElementById("modal-message");

        if (!departmentName) {
            modalMessage.textContent = "لطفاً نام دپارتمان را وارد کنید!";
            modalMessage.classList.remove("text-success");
            modalMessage.classList.add("text-danger");
            modal.classList.add("show");
            return;
        }

        let data = { name: departmentName };

        try {
            let response = await fetch("https://localhost:7156/api/v1/HumanResources/Create-Department", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(data)
            });

            let result = await response.json();

            if (response.ok) {
                modalMessage.textContent = "ثبت دپارتمان با موفقیت انجام شد.";
                modalMessage.classList.remove("text-red-500");
                modalMessage.classList.add("text-success");
            } else {
                modalMessage.textContent = "دپارتمان با این نام قبلاً ثبت شده است.";
                modalMessage.classList.remove("text-success");
                modalMessage.classList.add("text-danger");
            }

            modal.classList.add("show");

            setTimeout(() => {
                modal.classList.remove("show");
            }, 3000);
        } catch (error) {
            console.error("خطا در ارسال درخواست:", error);
            modalMessage.textContent = "مشکلی در ارتباط با سرور رخ داده است.";
            modalMessage.classList.remove("text-success");
            modalMessage.classList.add("text-red-500");
            modal.classList.add("show");

            setTimeout(() => {
                modal.classList.remove("show");
            }, 3000);
        }
    }
});

// ✅ دریافت لیست دپارتمان‌ها هنگام باز شدن مودال
document.addEventListener("click", function (event) {
    if (event.target.matches('[data-tw-toggle="modal"]')) {
        console.log("مودال کلیک شد!"); // بررسی کلیک روی مودال

        fetch("/GetDepartments")
            .then(response => {
                console.log("Response received:", response); // لاگ کردن پاسخ
                if (!response.ok) throw new Error("خطای دریافت داده!");
                return response.json();
            })
            .then(data => {
                console.log("داده‌های دریافتی:", data); // نمایش داده‌های دریافتی
                let select = document.getElementById("position-department");
                if (!select) {
                    console.error("عنصر select پیدا نشد!");
                    return;
                }

                select.innerHTML = ""; // حذف گزینه‌های قبلی
                select.appendChild(new Option("انتخاب کنید", "")); // گزینه پیش‌فرض

                data.forEach(department => {
                    let option = new Option(department.text, department.value);
                    select.appendChild(option);
                });
            })
            .catch(error => {
                alert("خطا در دریافت لیست دپارتمان‌ها!");
                console.error("Error:", error);
            });
    }
});

