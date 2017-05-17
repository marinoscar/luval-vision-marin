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
    this.documentService.getMetaDataFile(this.$state.params.tokenId)
      .then(this.getMetadataHandler.bind(this));
  }

  getMetadataHandler(metadata) {
    this.metadata = angular.fromJson(metadata.data.Content);
    if (Object.keys(this.metadata).length !== 0) { // eslint-disable-line no-negated-condition
      this.imageSrc = this.metadata.FileData;
      this.primaryData = this.metadata.Result.TextResults;
    } else {
      this.ngNotify.set('Please upload a document!', {
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
