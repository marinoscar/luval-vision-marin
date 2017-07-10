class MetricsController {
  /* @ngInject */
  constructor($state, $window, $log, ngNotify, MetricsService) {
    this.$state = $state;
    this.$log = $log;
    this.$window = $window;
    this.ngNotify = ngNotify;
    this.MetricsService = MetricsService;

    this.loadStatistics();
    this.chart = {};
    this.chart.type = 'ColumnChart';
    this.chart.displayed = true;
    this.chart.options = {
      title: 'Celeris Processed Documents',
      isStacked: true,
      fill: '20',
      vAxis: {
        title: 'Documents',
        gridlines: {
          count: 10
        }
      },
      hAxis: {
        title: 'Date'
      },
      tooltip: {
        isHtml: true
      },
      formatters: {},
      view: {}
    };
  }

  loadStatistics() {
    this.MetricsService.getStatistics()
      .then(
        this.formatStatistics.bind(this),
        this.errorLoadingStatistics.bind(this)
      );
  }

  formatStatistics(statistics) {
    this.chart.data = statistics.data;
  }

  errorLoadingStatistics() {
    this.ngNotify.set('Error Loading Usage Statistics', {
      type: 'error',
      duration: 2000
    });
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default MetricsController;
