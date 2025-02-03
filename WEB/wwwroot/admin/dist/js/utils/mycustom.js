document.addEventListener("DOMContentLoaded", function () {
    // گرفتن تمام لینک‌های داخل منو
    const menuLinks = document.querySelectorAll(".side-menu__link");

    menuLinks.forEach(link => {
        link.addEventListener("click", function (event) {
            event.preventDefault(); // جلوگیری از اجرای پیش‌فرض لینک

            // حذف کلاس active از تمام لینک‌ها
            menuLinks.forEach(item => item.classList.remove("side-menu__link--active"));

            // اضافه کردن کلاس active به لینک کلیک شده
            this.classList.add("side-menu__link--active");

            // در صورت نیاز به جابه‌جایی صفحه به لینک، می‌توان `window.location.href` را تنظیم کرد
            window.location.href = this.getAttribute("href");
        });
    });
});

