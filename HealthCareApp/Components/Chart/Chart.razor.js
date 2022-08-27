let chart = {};

export function setupChart(chartId, config) {
    const ctx = document.getElementById(chartId).getContext('2d');

    chart = new Chart(ctx, config);
}

export function updateChartData(data) {
    chart.data.datasets.forEach((dataset) => {
        dataset.data = data;
    });

    chart.update();
}

export function removeChartData() {
    chart.data.datasets.forEach((dataset) => {
        dataset.data = [];
    });

    chart.update();
}
