
class LoginController {
  constructor($log, $state, loginService, sessionService, documentService) {
    this.$state = $state;
    this.log = $log;
    this.loginService = loginService;
    this.documentService = documentService;
    this.sessionService = sessionService;
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
    const tokenId = this.documentService.replaceSpecialCharacters(user.w3.U3);
    this.sessionService.setAuthData(tokenId); // eslint-disable-line no-useless-escape
    this.loginService.saveOrUpdateUser(user)
      .then(function () {
        this.$state.go('invoices');
      });
  }
}

export default LoginController;
