let chart = {};

export function setupChart(chartId, config) {
    const ctx = document.getElementById(chartId).getContext('2d');

    chart = new Chart(ctx, config);
    console.log("LFS - chart is: ", chart);
    return chart;
}

export function updateChartData(_chartObjectReference, data) {
    chart.data.datasets.forEach((dataset) => {
        dataset.data = data;
    });
    console.log("LFS - _chartObjectReference is: ", _chartObjectReference);
    chart.update();
}

export function removeChartData() {
    chart.data.datasets.forEach((dataset) => {
        dataset.data = [];
    });

    chart.update();
}
