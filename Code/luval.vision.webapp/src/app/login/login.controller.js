class LoginController {
  /* @ngInject */
  constructor($log, $state, ngNotify, loginService, sessionService, documentService) {
    this.$state = $state;
    this.log = $log;
    this.ngNotify = ngNotify;
    this.loginService = loginService;
    this.documentService = documentService;
    this.sessionService = sessionService;
  }

  onSignIn() {
    this.loginService.callGoogleSignIn()
      .then(this.signInHandler.bind(this),
      this.signInRejected.bind(this));
  }

  signInHandler(user) {
    this.ngNotify.set('Success Google Sign In', {
      duration: 2000,
      position: 'bottom'
    });
    this.saveSignIn(user);
  }

  signInRejected() {
    this.ngNotify.set('Error Google sign in.', {
      type: 'error',
      duration: 2000
    });
  }

  saveSignIn(user) {
    const tokenId = this.documentService.replaceSpecialCharacters(user.w3.U3);
    this.sessionService.setAuthData(tokenId); // eslint-disable-line no-useless-escape
    this.$state.go('documents');
  }
}

export default LoginController;
