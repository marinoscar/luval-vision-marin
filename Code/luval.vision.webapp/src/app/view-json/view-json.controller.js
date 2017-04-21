class ViewJsonController {
  /* @ngInject */
  constructor($window, $state, $log, documentService, viewJsonService) {
    this.$state = $state;
    this.$window = $window;
    this.$log = $log;
    this.loading = true;
    this.documentService = documentService;
    this.viewJsonService = viewJsonService;
    this.initializeMetadataViewer();
  }

  initializeMetadataViewer() {
    this.viewJsonService.getMetaDataFile(this.$state.params.tokenId)
      .then(this.getMetadataHandler.bind(this),
      this.getMetadataRejected.bind(this));
  }

  getMetadataHandler(file) {
    this.loading = false;
    this.viewer = angular.fromJson(file.data.Content);
  }

  getMetadataRejected() {
    this.loading = false;
    this.$log.error('Failed');
  }
}

export default ViewJsonController;
