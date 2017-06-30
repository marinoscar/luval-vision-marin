class authorizationInjectorService {
  /* @ngInject */
  constructor($log, sessionService) {
    this.$log = $log;
    this.sessionService = sessionService;
    this.request = this.request.bind(this);
  }

  request(config) {
    config.headers.Authorization = this.sessionService.getAuthorization();
    if (!config.file) {
      config.headers['Content-Type'] = 'application/json';
    }
    return config;
  }

}

export default authorizationInjectorService;
