class MetricsController {
  /* @ngInject */
  constructor($state, $window, $log, ngNotify, MetricsService) {
    this.$state = $state;
    this.$log = $log;
    this.$window = $window;
    this.ngNotify = ngNotify;
    this.MetricsService = MetricsService;

    this.dateIsSet = false;
    this.months = [
      {
        id: 1,
        name: 'January'
      },
      {
        id: 2,
        name: 'February'
      },
      {
        id: 3,
        name: 'March'
      },
      {
        id: 4,
        name: 'April'
      },
      {
        id: 5,
        name: 'May'
      },
      {
        id: 6,
        name: 'June'
      },
      {
        id: 7,
        name: 'July'
      },
      {
        id: 8,
        name: 'August'
      },
      {
        id: 9,
        name: 'September'
      },
      {
        id: 10,
        name: 'October'
      },
      {
        id: 11,
        name: 'November'
      },
      {
        id: 12,
        name: 'December'
      }
    ];
    this.month = -1;
    this.year = 2017;

    this.renderChart();
  }

  setDate() {
    this.dateIsSet = this.isDateValid();

    this.renderChart();
  }

  isDateValid() {
    return this.isValidYear() && this.isValidMonth();
  }

  isValidYear() {
    return this.year >= 2017;
  }

  isValidMonth() {
    return this.month > 0 && this.month < 13;
  }

  renderChart() {
    if (this.dateIsSet) {
      this.loadChartData();
    } else {
      this.ngNotify.set('Please set the Date', {
        duration: 2000
      });
    }
  }

  loadChartData() {
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
    this.MetricsService.getStatistics(this.formatYear(this.year),
                                      this.formatMonth(this.month))
      .then(
        this.formatStatistics.bind(this),
        this.errorLoadingStatistics.bind(this)
      );
  }

  formatYear(year) {
    return String(year);
  }

  formatMonth(month) {
    return (month < 10) ? '0' + String(month) : String(month);
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
