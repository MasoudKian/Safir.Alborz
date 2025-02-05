document.addEventListener("DOMContentLoaded", function () {
    const menuLinks = document.querySelectorAll(".side-menu__link");

    // بررسی آیا آیتمی قبلاً کلیک شده و در localStorage ذخیره شده است؟
    const activeLink = localStorage.getItem("activeMenuLink");

    if (activeLink) {
        menuLinks.forEach(link => {
            const icon = link.querySelector("i"); // آیکون داخل لینک

            if (link.getAttribute("href") === activeLink) {
                link.classList.add("side-menu__link--active");
                if (icon) icon.classList.add("active-icon"); // رنگ آیکون تغییر کند
            } else {
                link.classList.remove("side-menu__link--active");
                if (icon) icon.classList.remove("active-icon");
            }
        });
    }

    menuLinks.forEach(link => {
        link.addEventListener("click", function (event) {
            // ذخیره لینک در localStorage
            localStorage.setItem("activeMenuLink", this.getAttribute("href"));

            // حذف کلاس active از همه لینک‌ها و آیکون‌ها
            menuLinks.forEach(item => {
                item.classList.remove("side-menu__link--active");
                const icon = item.querySelector("i");
                if (icon) icon.classList.remove("active-icon");
            });

            // اضافه کردن کلاس active به لینک و آیکون کلیک شده
            this.classList.add("side-menu__link--active");
            const icon = this.querySelector("i");
            if (icon) icon.classList.add("active-icon");
        });
    });
});
