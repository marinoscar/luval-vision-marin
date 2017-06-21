class documentService {
  /* @ngInject */
  constructor($state, $window, $log, $http, sessionService, CORE) {
    this.metadata = {};
    this.$window = $window;
    this.$log = $log;
    this.$http = $http;
    this.$state = $state;
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

  downloadImage(imageBuffer) {
    const anchor = angular.element('<a/>');
    const blob = new Blob([this.base64ToArrayBuffer(imageBuffer)]);
    anchor.attr({
      href: this.$window.URL.createObjectURL(blob),
      target: '_blank',
      download: 'document.jpg'
    })[0].click();
  }

  openDocumentViewer(fileId) {
    const url = this.$state.href('view-json', {tokenId: fileId});
    this.$window.open(url, '_blank');
  }

}

export default documentService;
