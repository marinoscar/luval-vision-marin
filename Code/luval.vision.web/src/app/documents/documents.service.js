class documentsService {
  /* @ngInject */
  constructor($log, $http, $window, Upload, CORE, sessionService) {
    this.documents = [];
    this.log = $log;
    this.$http = $http;
    this.$window = $window;
    this.upload = Upload;
    this.CORE = CORE;
    this.sessionService = sessionService;
  }

  addDocument(document) {
    this.documents.push(document);
  }

  getDocumentsList() {
    return this.documents;
  }

  resetDocumentsList() {
    this.documents = [];
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

  getProfiles() {
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

  getDocumentsStored() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Storage',
      headers: {
        'Content-Type': 'application/json'
      },
      params: this.sessionService.buildUserJSON()
    };
    return this.$http(getRequest);
  }
}

export default documentsService;
