class AdminController {
  /* @ngInject */
  constructor($state, $log, ngNotify, usersService, loginService, errorService) {
    this.$state = $state;
    this.$log = $log;
    this.ngNotify = ngNotify;
    this.usersService = usersService;
    this.loginService = loginService;
    this.errorService = errorService;
    this.users = [];

    this.init();
  }

  isAdmin() {
    return this.loginService.isAdmin();
  }

  init() {
    this.usersService.getAllUsers()
      .then(res => {
        this.users = res.data;
      })
      .catch(res => this.errorService.handleError(res));
  }

  updateUser(user) {
    this.usersService.updateUserAccount(user)
      .then(res => {
        this.$log.debug(res.data);
        this.ngNotify.set('User Updated!', {
          duration: 2000,
          position: 'bottom'
        });
      })
      .catch(res => this.errorService.handleError(res));
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default AdminController;
