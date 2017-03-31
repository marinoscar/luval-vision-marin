class LoginController {
  constructor($log, $state, loginService) {
    this.$state = $state;
    this.log = $log;
    this.loginService = loginService;
  }

  onSignIn() {
    this.loginService.callGoogleSignIn()
      .then(user => {
        this.log.info(user);
      }, function (err) {
        this.log.info(err);
      });
  }
}

export default LoginController;
