class DocumentsModalController {
  /* @ngInject */
  constructor($log, $state, $uibModalStack, loginService, documentsService, sessionService) {
    this.log = $log;
    this.$state = $state;
    this.$uibModalStack = $uibModalStack;
    this.sessionService = sessionService;
    this.documentsService = documentsService;
    this.loginService = loginService;
  }

  goToSettings() {
    this.$state.go('settings');
    this.$uibModalStack.dismissAll();
    this.documentsService.resetDocumentsList();
  }

  logOut() {
    this.loginService.logOut()
      .then(this.redirectToLogin.bind(this));
  }

  redirectToLogin() {
    this.$state.go('login');
    this.sessionService.destroy();
    this.documentsService.resetDocumentsList();
    this.$uibModalStack.dismissAll();
  }
}

export default DocumentsModalController;
