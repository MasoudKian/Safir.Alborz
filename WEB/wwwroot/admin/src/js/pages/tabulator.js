(function () {
    "use strict";

    // Tabulator
    if ($("#tabulator").length) {
        // Setup Tabulator
        const tabulator = new Tabulator("#tabulator", {
            ajaxURL: "https://dummy-data.eltheme.ir",
            paginationMode: "remote",
            filterMode: "remote",
            sortMode: "remote",
            printAsHtml: true,
            printStyled: true,
            pagination: true,
            paginationSize: 10,
            paginationSizeSelector: [10, 20, 30, 40],
            layout: "fitColumns",
            responsiveLayout: "collapse",
            placeholder: "رکوردی یافت نشد",
            locale:true,
            langs: {
              'fa': {
                  placeholder: 'رکوردی یافت نشد',
                  "columns":{
                      "name":"نام محصول", //replace the title of column name with the value "Name"
                      "images": "تصاویر",
                      "remaining_stock": "مانده در انبار",
                      "status": "وضعیت",
                      "actions": "عملیات",
                      "category": "دسته‌بندی",
                  },
                  "data":{
                      "loading":"بارگذاری", //data loader text
                      "error":"خطا", //data error text
                  },
                  "groups":{ //copy for the auto generated item count in group header
                      "item":"آیتم", //the singular  for item
                      "items":"آیتم‌ها", //the plural for items
                  },
                  "pagination":{
                      "page_size":"اندازه صفحه", //label for the page size select element
                      "page_title":"نمایش صفحه",//tooltip text for the numeric page button, appears in front of the page number (eg. "Show Page" will result in a tool tip of "Show Page 1" on the page 1 button)
                      "first":"اولین", //text for the first page button
                      "first_title":"اولین صفحه", //tooltip text for the first page button
                      "last":"آخرین",
                      "last_title":"آخرین صفحه",
                      "prev":"قبلی",
                      "prev_title":"صفحه قبلی",
                      "next":"بعدی",
                      "next_title":"صفحه بعدی",
                      "all":"همه",
                      "counter":{
                          "showing": "درحال نمایش",
                          "of": "از",
                          "rows": "سطور",
                          "pages": "صفحات",
                      }
                  },
                  "headerFilters":{
                      "default":"فیلتر ستون...", //default header filter placeholder text
                      "columns":{
                          "name":"فیلتر نام...", //replace default header filter text for column name
                      }
                  }
              }
            },
            columns: [
                {
                    title: "",
                    formatter: "responsiveCollapse",
                    width: 40,
                    minWidth: 30,
                    hozAlign: "center",
                    resizable: false,
                    headerSort: false,
                },

                // For HTML table
                {
                    title: "PRODUCT NAME",
                    minWidth: 200,
                    responsive: 0,
                    field: "name",
                    vertAlign: "middle",
                    print: false,
                    download: false,
                    formatter(cell) {
                        const response = cell.getData();
                        return `<div>
                        <div class="font-medium whitespace-nowrap">${response.name}</div>
                        <div class="text-xs text-slate-500 whitespace-nowrap">${response.category}</div>
                    </div>`;
                    },
                },
                {
                    title: "IMAGES",
                    minWidth: 200,
                    field: "images",
                    hozAlign: "center",
                    headerHozAlign: "center",
                    vertAlign: "middle",
                    print: false,
                    download: false,
                    formatter(cell) {
                        const response = cell.getData();
                        return `<div class="flex lg:justify-center">
                            <div class="w-10 h-10 intro-x image-fit">
                            <img alt="Tailwise - Admin Dashboard Template" class="rounded-full shadow-[0px_0px_0px_2px_#fff,_1px_1px_5px_rgba(0,0,0,0.32)] dark:shadow-[0px_0px_0px_2px_#3f4865,_1px_1px_5px_rgba(0,0,0,0.32)]" src="https://eltheme.ir/dummy/images/${response.images[0]}">
                            </div>
                            <div class="w-10 h-10 rtl:-mr-5 ltr:-ml-5 intro-x image-fit">
                            <img alt="Tailwise - Admin Dashboard Template" class="rounded-full shadow-[0px_0px_0px_2px_#fff,_1px_1px_5px_rgba(0,0,0,0.32)] dark:shadow-[0px_0px_0px_2px_#3f4865,_1px_1px_5px_rgba(0,0,0,0.32)]" src="https://eltheme.ir/dummy/images/${response.images[1]}">
                            </div>
                            <div class="w-10 h-10 rtl:-mr-5 ltr:-ml-5 intro-x image-fit">
                            <img alt="Tailwise - Admin Dashboard Template" class="rounded-full shadow-[0px_0px_0px_2px_#fff,_1px_1px_5px_rgba(0,0,0,0.32)] dark:shadow-[0px_0px_0px_2px_#3f4865,_1px_1px_5px_rgba(0,0,0,0.32)]" src="https://eltheme.ir/dummy/images/${response.images[2]}">
                            </div>
                        </div>`;
                    },
                },
                {
                    title: "REMAINING STOCK",
                    minWidth: 200,
                    field: "remaining_stock",
                    hozAlign: "center",
                    headerHozAlign: "center",
                    vertAlign: "middle",
                    print: false,
                    download: false,
                },
                {
                    title: "STATUS",
                    minWidth: 200,
                    field: "status",
                    hozAlign: "center",
                    headerHozAlign: "center",
                    vertAlign: "middle",
                    print: false,
                    download: false,
                    formatter(cell) {
                        const response = cell.getData();
                        return `<div class="flex items-center lg:justify-center ${
                            response.status ? "text-success" : "text-danger"
                        }">
                        <i data-lucide="check-square" class="w-4 h-4 rtl:ml-2 ltr:mr-2"></i> ${
                            response.status ? "Active" : "Inactive"
                        }
                    </div>`;
                    },
                },
                {
                    title: "ACTIONS",
                    minWidth: 200,
                    field: "actions",
                    responsive: 1,
                    hozAlign: "center",
                    headerHozAlign: "center",
                    vertAlign: "middle",
                    print: false,
                    download: false,
                    formatter() {
                        let a =
                            $(`<div class="flex items-center lg:justify-center">
                        <a class="flex items-center rtl:ml-3 ltr:mr-3 edit" href="javascript:;">
                            <i data-lucide="check-square" class="w-4 h-4 rtl:ml-1 ltr:mr-1"></i> Edit
                        </a>
                        <a class="flex items-center delete text-danger" href="javascript:;">
                            <i data-lucide="trash-2" class="w-4 h-4 rtl:ml-1 ltr:mr-1"></i> Delete
                        </a>
                        </div>`);
                        $(a)
                            .find(".edit")
                            .on("click", function () {
                                alert("EDIT");
                            });

                        $(a)
                            .find(".delete")
                            .on("click", function () {
                                alert("DELETE");
                            });
                        return a[0];
                    },
                },

                // For print format
                {
                    title: "PRODUCT NAME",
                    field: "name",
                    visible: false,
                    print: true,
                    download: true,
                },
                {
                    title: "CATEGORY",
                    field: "category",
                    visible: false,
                    print: true,
                    download: true,
                },
                {
                    title: "REMAINING STOCK",
                    field: "remaining_stock",
                    visible: false,
                    print: true,
                    download: true,
                },
                {
                    title: "STATUS",
                    field: "status",
                    visible: false,
                    print: true,
                    download: true,
                    formatterPrint(cell) {
                        return cell.getValue() ? "Active" : "Inactive";
                    },
                },
                {
                    title: "IMAGE 1",
                    field: "images",
                    visible: false,
                    print: true,
                    download: true,
                    formatterPrint(cell) {
                        return cell.getValue()[0];
                    },
                },
                {
                    title: "IMAGE 2",
                    field: "images",
                    visible: false,
                    print: true,
                    download: true,
                    formatterPrint(cell) {
                        return cell.getValue()[1];
                    },
                },
                {
                    title: "IMAGE 3",
                    field: "images",
                    visible: false,
                    print: true,
                    download: true,
                    formatterPrint(cell) {
                        return cell.getValue()[2];
                    },
                },
            ],
        });

        tabulator.on("renderComplete", () => {
            createIcons({
                icons,
                attrs: {
                    "stroke-width": 1.5,
                },
                nameAttr: "data-lucide",
            });
            tabulator.setLocale(document.documentElement.lang); //set locale
            switch (document.documentElement.lang) {
                case 'fa':
                    tabulator.options.placeholder = "رکوردی یافت نشد";
                    break;
                case 'en':
                    tabulator.options.placeholder = "No matching records found";
                    break;
            }
        });

        // Redraw table onresize
        window.addEventListener("resize", () => {
            tabulator.redraw();
            createIcons({
                icons,
                "stroke-width": 1.5,
                nameAttr: "data-lucide",
            });
        });

        // Filter function
        function filterHTMLForm() {
            let field = $("#tabulator-html-filter-field").val();
            let type = $("#tabulator-html-filter-type").val();
            let value = $("#tabulator-html-filter-value").val();
            tabulator.setFilter(field, type, value);
        }

        // On submit filter form
        $("#tabulator-html-filter-form")[0].addEventListener(
            "keypress",
            function (event) {
                let keycode = event.keyCode ? event.keyCode : event.which;
                if (keycode == "13") {
                    event.preventDefault();
                    filterHTMLForm();
                }
            }
        );

        // On click go button
        $("#tabulator-html-filter-go").on("click", function (event) {
            filterHTMLForm();
        });

        // On reset filter form
        $("#tabulator-html-filter-reset").on("click", function (event) {
            $("#tabulator-html-filter-field").val("name");
            $("#tabulator-html-filter-type").val("like");
            $("#tabulator-html-filter-value").val("");
            filterHTMLForm();
        });

        // Export
        $("#tabulator-export-csv").on("click", function (event) {
            tabulator.download("csv", "data.csv");
        });

        $("#tabulator-export-json").on("click", function (event) {
            tabulator.download("json", "data.json");
        });

        $("#tabulator-export-xlsx").on("click", function (event) {
            tabulator.download("xlsx", "data.xlsx", {
                sheetName: "Products",
            });
        });

        $("#tabulator-export-html").on("click", function (event) {
            tabulator.download("html", "data.html", {
                style: true,
            });
        });

        // Print
        $("#tabulator-print").on("click", function (event) {
            tabulator.print();
        });
    }
})();
