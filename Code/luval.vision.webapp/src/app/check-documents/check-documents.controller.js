class CheckDocumentsController {
  /* @ngInject */
  constructor($state, $window, $log, documentService) {
    this.$state = $state;
    this.log = $log;
    this.$window = $window;
    this.documentService = documentService;
    this.metadata = this.documentService.getMetadata();
    this.imageSrc = this.documentService.getFileData();
    this.primaryData = this.metadata.Result.TextResults;
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
    const url = this.$state.href('view-json', {tokenId: this.metadata.Id});
    const documentParsed = this.documentService.setDocumentParsed(this.metadata);
    this.$window.localStorage.setItem('document-json', documentParsed);
    this.$window.open(url);
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default CheckDocumentsController;
