class documentsService {
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

  getDocumentsStored() {
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
    return {
      id: this.sessionService.getAuthData().authData
    };
  }
}

export default documentsService;
