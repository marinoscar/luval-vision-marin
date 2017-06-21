class AdminController {
  /* @ngInject */
  constructor($state, $log, ngNotify, usersService) {
    this.$state = $state;
    this.$log = $log;
    this.ngNotify = ngNotify;
    this.usersService = usersService;
    this.users = [];

    this.init();
  }

  init() {
    this.usersService.getAllUsers()
      .then(res => {
        this.users = res.data;
      })
      .catch(res => {
        this.$log.debug(res);
      });
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
      .catch(res => {
        this.$log.debug(res);
        this.ngNotify.set('Something went wrong!', {
          type: 'error',
          duration: 2000
        });
      });
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default AdminController;
