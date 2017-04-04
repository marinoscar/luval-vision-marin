class LoginController {
  constructor($log, $state, loginService) {
    this.$state = $state;
    this.log = $log;
    this.loginService = loginService;
  }

  onSignIn() {
    this.loginService.callGoogleSignIn()
      .then(user => {
        this.saveSignIn(user);
      }, function (err) {
        this.log.error(err);
      });
  }

  saveSignIn(user) {
    this.loginService.saveOrUpdateUser(user)
      .then(user => {
        this.log.info(user);
        this.$state.go('receipts');
      });
  }
}

export default LoginController;
