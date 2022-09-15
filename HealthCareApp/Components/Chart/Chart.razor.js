export function setupChart(chartId, config) {
    const ctx = document.getElementById(chartId).getContext('2d');
    const chart = new Chart(ctx, config);

    return chart;
}

export function updateChartData(_chartObjectReference, data) {
    _chartObjectReference.data.datasets.forEach((dataset) => {
        dataset.data = data;
    });

    _chartObjectReference.update();
}

export function removeChartData(_chartObjectReference) {
    _chartObjectReference.data.datasets.forEach((dataset) => {
        dataset.data = [];
    });

    _chartObjectReference.update();
}
