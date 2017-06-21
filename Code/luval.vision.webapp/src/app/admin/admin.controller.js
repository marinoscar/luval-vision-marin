class AdminController {
  /* @ngInject */
  constructor($state, $log, ngNotify) {
    this.$state = $state;
    this.$log = $log;
    this.ngNotify = ngNotify;
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default AdminController;
