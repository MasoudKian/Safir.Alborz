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

debugger;
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("submit-department").addEventListener("click", async function (e) {
        e.preventDefault();

        let departmentName = document.getElementById("validation-form-1").value;
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
    });
});
