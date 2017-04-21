class viewJsonService {
  constructor($state, $log, $http, CORE) {
    this.$state = $state;
    this.$log = $log;
    this.$http = $http;
    this.CORE = CORE;
  }

  getMetaDataFile(fileId) {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Provider',
      params: {id: fileId}
    };
    return this.$http(getRequest);
  }
}

export default viewJsonService;
