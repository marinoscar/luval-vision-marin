class LoginCreateController {
  /* @ngInject */
  constructor($log, $state, $stateParams, ngNotify, loginService) {
    this.log = $log;
    this.$state = $state;
    this.$stateParams = $stateParams;
    this.ngNotify = ngNotify;
    this.loginService = loginService;

    const user = this.$stateParams.user;
    this.userName = user.w3.ig;
    this.email = user.w3.U3;
  }

  confirmAccount() {
    this.loginService.createUserAccount({
      name: this.userName,
      email: this.email
    })
      .then(res => {
        const userAccount = res.data;
        this.log.log(userAccount);
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

export default LoginCreateController;
