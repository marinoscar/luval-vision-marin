class MetricsService {
  /* @ngInject */
  constructor($log, $http, $window, CORE, sessionService) {
    this.log = $log;
    this.$http = $http;
    this.$window = $window;
    this.CORE = CORE;
    this.sessionService = sessionService;
  }

  getStatistics() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Storage/GetStatistics',
      headers: {
        'Content-Type': 'application/json'
      },
      params: this.sessionService.buildUserJSON()
    };
    return this.$http(getRequest);
  }
}

export default MetricsService;
