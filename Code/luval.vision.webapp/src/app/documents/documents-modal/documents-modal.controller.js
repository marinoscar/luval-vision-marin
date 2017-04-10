class DocumentsModalController {
  constructor($log, $state, $uibModalStack, loginService, sessionService) {
    this.log = $log;
    this.$state = $state;
    this.$uibModalStack = $uibModalStack;
    this.sessionService = sessionService;
    this.loginService = loginService;
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
