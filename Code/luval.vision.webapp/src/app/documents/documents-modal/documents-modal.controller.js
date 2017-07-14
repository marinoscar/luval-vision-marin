class DocumentsModalController {
  /* @ngInject */
  constructor($log, $state, $uibModalStack, loginService) {
    this.log = $log;
    this.$state = $state;
    this.$uibModalStack = $uibModalStack;
    this.loginService = loginService;
  }

  isAdmin() {
    return this.loginService.isAdmin();
  }

  goToSettings() {
    this.$state.go('profiles-show');
    this.$uibModalStack.dismissAll();
  }

  goToUsage() {
    this.$state.go('metrics');
    this.$uibModalStack.dismissAll();
  }

  goToAdmin() {
    this.$state.go('admin');
    this.$uibModalStack.dismissAll();
  }

  logOut() {
    this.loginService.logOut();
    this.redirectToLogin();
  }

  redirectToLogin() {
    this.$state.go('login');
    this.$uibModalStack.dismissAll();
  }
}

export default DocumentsModalController;
