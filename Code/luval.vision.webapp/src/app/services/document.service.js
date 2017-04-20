class documentService {
  /* @ngInject */
  constructor($window, $log, sessionService) {
    this.metadata = {};
    this.$window = $window;
    this.$log = $log;
    this.sessionService = sessionService;
  }

  setDocumentParsed(json) {
    this.file = angular.toJson(json.Result, true);
    return this.file;
  }

  getMetadata() {
    return this.metadata;
  }

  setMetadata(metadata) {
    this.metadata = metadata;
  }

  setFileData(fileData) {
    this.fileData = fileData;
  }

  getFileData() {
    return this.fileData;
  }

  replaceSpecialCharacters(source) {
    return source.replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi, '') // eslint-disable-line
  }

  objectBlobStorage(files) {
    return {
      userId: this.sessionService.buildUserJSON().userId,
      file: files[0]
    };
  }

  base64ToArrayBuffer(base64) {
    const binaryString = this.$window.atob(base64);
    const len = binaryString.length;
    const bytes = new Uint8Array(len);
    for (let i = 0; i < len; i++) {
      bytes[i] = binaryString.charCodeAt(i);
    }
    return bytes.buffer;
  }
}

export default documentService;
