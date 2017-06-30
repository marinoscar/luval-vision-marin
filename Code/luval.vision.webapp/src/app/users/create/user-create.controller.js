class UserCreateController {
  /* @ngInject */
  constructor($log, $state, $stateParams, ngNotify, sessionService, usersService) {
    this.log = $log;
    this.$state = $state;
    this.$stateParams = $stateParams;
    this.ngNotify = ngNotify;
    this.sessionService = sessionService;
    this.usersService = usersService;

    this.googleUser = this.$stateParams.user;

    const userId = this.sessionService.replaceSpecialCharacters(this.googleUser.w3.U3);
    this.account = {
      Email: this.googleUser.w3.U3,
      Name: this.googleUser.w3.ig,
      UserId: userId,
      ApiToken: this.googleUser.Zi.access_token
    };
  }

  confirmAccount() {
    this.usersService.createUserAccount(this.account)
      .then(res => {
        const userAccount = res.data;
        this.sessionService.setAuthData(this.googleUser, userAccount);
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
