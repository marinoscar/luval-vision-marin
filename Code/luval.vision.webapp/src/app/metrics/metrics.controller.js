class MetricsController {
  /* @ngInject */
  constructor($state, $window, $log, ngNotify, MetricsService) {
    this.$state = $state;
    this.$log = $log;
    this.$window = $window;
    this.ngNotify = ngNotify;
    this.MetricsService = MetricsService;

    this.chart = {};
    this.chart.type = 'ColumnChart';
    this.chart.displayed = true;
    this.chart.options = {
      title: 'Celeris Processed Documents',
      isStacked: true,
      fill: '20',
      vAxis: {
        title: '# Docs',
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
    this.loadStatistics();
  }

  loadStatistics() {
    this.MetricsService.getStatistics()
      .then(
        this.formatStatistics.bind(this),
        this.errorLoadingStatistics(this)
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
