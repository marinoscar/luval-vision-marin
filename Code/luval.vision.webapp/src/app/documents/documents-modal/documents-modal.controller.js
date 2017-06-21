class DocumentsModalController {
  /* @ngInject */
  constructor($log, $state, $uibModalStack, loginService, documentsService) {
    this.log = $log;
    this.$state = $state;
    this.$uibModalStack = $uibModalStack;
    this.documentsService = documentsService;
    this.loginService = loginService;
  }

  isAdmin() {
    return this.loginService.isAdmin();
  }

  goToSettings() {
    this.$state.go('profiles-show');
    this.$uibModalStack.dismissAll();
  }

  goToAdmin() {
    this.$state.go('admin');
    this.$uibModalStack.dismissAll();
  }

  logOut() {
    this.loginService.logOut()
      .then(this.redirectToLogin.bind(this));
  }

  redirectToLogin() {
    this.$state.go('login');
    this.sessionService.destroy();
    this.$uibModalStack.dismissAll();
  }
}

export default DocumentsModalController;
