class MetricsService {
  /* @ngInject */
  constructor($log, $http, $window, CORE, sessionService) {
    this.log = $log;
    this.$http = $http;
    this.$window = $window;
    this.CORE = CORE;
    this.sessionService = sessionService;
  }

  getStatistics(year, month) {
    const theJson = this.sessionService.buildUserJSON();
    theJson.year = year;
    theJson.month = month;
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Storage/GetStatistics',
      params: theJson
    };
    return this.$http(getRequest);
  }
}

export default MetricsService;
