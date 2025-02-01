import { Calendar } from "@fullcalendar/core";
import dayGridPlugin from "@fullcalendar/daygrid";
import allLocales from '@fullcalendar/core/locales-all';

(function () {
    "use strict";

    $(".full-calendar").each(function () {
        let calendar = new Calendar($(this).children()[0], {
            locales: allLocales,
            locale: document.documentElement.lang,
            plugins: [
                interactionPlugin,
                dayGridPlugin,
                timeGridPlugin,
                listPlugin,
            ],
            droppable: true,
            headerToolbar: {
                left: "prev,next today",
                center: "title",
                right: "dayGridMonth,timeGridWeek,timeGridDay,listWeek",
            },
            initialDate: "2045-01-01",
            navLinks: true,
            editable: true,
            dayMaxEvents: true,
            events: [
                {
                    title: "روز ویو ویکسنس",
                    start: "2045-01-05",
                    end: "2045-01-08",
                },
                {
                    title: "کنفرانس ویو آمریکا",
                    start: "2045-01-11",
                    end: "2045-01-15",
                },
                {
                    title: "ویو جی‌اس آمستردام",
                    start: "2045-01-17",
                    end: "2045-01-21",
                },
                {
                    title: "جشنواره ویو ژاپن ۱۴۲۳",
                    start: "2045-01-21",
                    end: "2045-01-24",
                },
                {
                    title: "لاراکان ۱۴۲۳",
                    start: "2045-01-24",
                    end: "2045-01-27",
                },
            ],
            drop: function (info) {
                if (
                    $("#checkbox-events").length &&
                    $("#checkbox-events")[0].checked
                ) {
                    $(info.draggedEl).parent().remove();

                    if ($("#calendar-events").children().length == 1) {
                        $("#calendar-no-events").removeClass("hidden");
                    }
                }
            },
        });

        calendar.render();
    });
})();
