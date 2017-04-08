class invoicesService {
  constructor($log, $http, $window, Upload, CORE, sessionService) {
    this.log = $log;
    this.$http = $http;
    this.$window = $window;
    this.upload = Upload;
    this.CORE = CORE;
    this.sessionService = sessionService;
  }

  uploadDocumenToBlobStorage(blob) {
    const upload = this.upload.upload({
      url: this.CORE.URL + 'Provider',
      method: 'POST',
      data: blob,
      file: blob.file
    });
    return upload;
  }

  getFilesStored() {
    const getRequest = {
      method: 'POST',
      url: this.CORE.URL + 'Storage',
      headers: {
        'Content-Type': 'application/json'
      },
      data: this.buildUserJSON()
    };
    return this.$http(getRequest);
  }

  buildUserJSON() {
    this.log.info(this.sessionService.getAuthData());
    return {
      id: this.sessionService.getAuthData().authData
    };
  }
}

export default invoicesService;
