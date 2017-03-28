class LoginController {
  constructor(LoginService, AuthService, $state, ngNotify, $log, $location) {
    this.$state = $state;
    this.LoginService = LoginService;
    this.auth = AuthService;
    this.notify = ngNotify;
    this.log = $log;
    this.location = $location;
  }

  authenticateUser() {
    return null;
  }
}