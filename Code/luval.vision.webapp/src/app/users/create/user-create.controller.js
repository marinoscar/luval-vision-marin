class UserCreateController {
  /* @ngInject */
  constructor($log, $state, $stateParams, ngNotify, sessionService, usersService) {
    this.log = $log;
    this.$state = $state;
    this.$stateParams = $stateParams;
    this.ngNotify = ngNotify;
    this.sessionService = sessionService;
    this.usersService = usersService;

    this.user = this.$stateParams.user;
    this.userName = this.user.name;
    this.email = this.user.email;
  }

  confirmAccount() {
    this.usersService.createUserAccount({
      name: this.userName,
      email: this.email
    })
      .then(res => {
        const userAccount = res.data;
        this.sessionService.setAuthData(this.user, userAccount);
        this.ngNotify.set('Account created successfully', {
          duration: 2000,
          position: 'bottom'
        });
        this.$state.go('documents');
      })
      .catch(res => {
        this.log.debug(res);
        this.ngNotify.set('Something went wrong', {
          duration: 2000,
          position: 'bottom',
          type: 'error'
        });
        this.$state.go('login');
      });
  }
}

export default UserCreateController;
