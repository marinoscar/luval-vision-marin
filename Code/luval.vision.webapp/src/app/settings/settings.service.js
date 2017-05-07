class settingsService {
  constructor($log, $http, sessionService, Upload, CORE) {
    this.$log = $log;
    this.$http = $http;
    this.CORE = CORE;
    this.upload = Upload;
    this.sessionService = sessionService;
  }

  uploadAttributeMappingConfig(blob) {
    const upload = this.upload.upload({
      url: this.CORE.URL + 'Settings',
      method: 'POST',
      data: blob,
      file: blob.file
    });
    return upload;
  }

  getDefaultSettings() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Settings/GetProfiles',
      headers: {
        'Content-Type': 'application/json'
      },
      params: this.sessionService.buildUserJSON()
    };
    return this.$http(getRequest);
  }
}

export default settingsService;
