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
