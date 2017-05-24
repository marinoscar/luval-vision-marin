class CheckDocumentsController {
  /* @ngInject */
  constructor($state, $window, $log, ngNotify, documentService) {
    this.$state = $state;
    this.$log = $log;
    this.$window = $window;
    this.ngNotify = ngNotify;
    this.documentService = documentService;
    this.setCheckDocumentProperties();
    this.downloadImage = documentService.downloadImage.bind(documentService);
    this.viewJSON = documentService.openDocumentViewer.bind(documentService);
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

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default CheckDocumentsController;
