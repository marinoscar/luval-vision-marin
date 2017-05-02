class documentService {
  /* @ngInject */
  constructor($window, $log, $http, sessionService, CORE) {
    this.metadata = {};
    this.$window = $window;
    this.$log = $log;
    this.$http = $http;
    this.sessionService = sessionService;
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

  replaceSpecialCharacters(source) {
    return source.replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi, '') // eslint-disable-line
  }

  objectBlobStorage(files, profileName) {
    return {
      profile: profileName,
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
