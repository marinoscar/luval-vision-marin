class CheckDocumentsController {
  /* @ngInject */
  constructor($state, $window, $log, ngNotify, documentService) {
    this.$state = $state;
    this.$log = $log;
    this.$window = $window;
    this.ngNotify = ngNotify;
    this.documentService = documentService;
    this.setCheckDocumentProperties();
  }

  setCheckDocumentProperties() {
    this.metadata = this.documentService.getMetadata();
    if (Object.keys(this.metadata).length !== 0) { // eslint-disable-line no-negated-condition
      this.imageSrc = this.documentService.getFileData();
      this.primaryData = this.metadata.Result.TextResults;
    } else {
      this.ngNotify.set('Please select or upload some document!', {
        type: 'error',
        duration: 3000
      });
    }
  }

  downloadImage(imageBuffer) {
    const anchor = angular.element('<a/>');
    const blob = new Blob([this.documentService.base64ToArrayBuffer(imageBuffer)]);
    anchor.attr({
      href: this.$window.URL.createObjectURL(blob),
      target: '_blank',
      download: 'document.jpg'
    })[0].click();
  }

  openDocumentViewer() {
    const url = this.$state.href('view-json', {tokenId: this.$state.params.tokenId});
    this.$window.open(url, '_blank');
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default CheckDocumentsController;
