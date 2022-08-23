window.setup = (chartId, config) => {
    var ctx = document.getElementById(chartId).getContext('2d');
    new Chart(ctx, config);
}
