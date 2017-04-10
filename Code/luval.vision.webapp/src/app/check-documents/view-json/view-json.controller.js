class ViewJsonController {
  /* @ngInject */
  constructor($window, $state, documentService) {
    this.$state = $state;
    this.$window = $window;
    this.documentService = documentService;
    this.documentJSON = this.$window.localStorage.getItem('document-json');
  }
}

export default ViewJsonController;
