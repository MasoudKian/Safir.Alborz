(function () {
    "use strict";

    // Chart
    const chartEl = $(".report-bar-chart-4");

    if (chartEl.length) {
        chartEl.each(function () {
            const ctx = $(this)[0].getContext("2d");

            const reportBarChart4 = new Chart(ctx, {
                type: "bar",
                data: {
                    labels: ["د.ش", "س.ش", "چ.ش", "پ.ش", "ج", "ش", "ی.ش"],
                    datasets: [
                        {
                            barPercentage: 0.38,
                            borderRadius: 2,
                            data: [4, 7, 5, 4, 9, 7, 5],
                            borderWidth: 1,
                            borderColor: getColor("theme.1", 0.7),
                            backgroundColor: getColor("theme.1", 0.3),
                        },
                    ],
                },
                options: {
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            display: false,
                        },
                    },
                    scales: {
                        x: {
                            ticks: {
                                color: getColor("slate.500", 0.8),
                            },
                            grid: {
                                display: false,
                            },
                            border: {
                                display: false,
                            },
                        },
                        y: {
                            ticks: {
                                display: false,
                                beginAtZero: true,
                            },
                            grid: {
                                display: false,
                            },
                            border: {
                                display: false,
                            },
                        },
                    },
                },
            });

            // Watch CSS variable color changes
            helper.watchCssVariables("html", ["color-theme-1"], (newValues) => {
                reportBarChart4.data.datasets[0].borderColor = getColor(
                    "theme.1",
                    0.7
                );
                reportBarChart4.data.datasets[0].backgroundColor = getColor(
                    "theme.1",
                    0.3
                );
                reportBarChart4.update();
            });
        });
    }
})();
