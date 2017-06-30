class LoginController {
  /* @ngInject */
  constructor($log, $state, ngNotify, usersService, loginService, sessionService, documentService) {
    this.$state = $state;
    this.$log = $log;
    this.ngNotify = ngNotify;
    this.usersService = usersService;
    this.loginService = loginService;
    this.sessionService = sessionService;
    this.documentService = documentService;
  }

  onSignIn() {
    this.loginService.callGoogleSignIn()
      .then(this.signInHandler.bind(this),
      this.signInRejected.bind(this));
  }

  signInHandler(googleUser) {
    this.saveSignIn(googleUser, null);
    this.usersService.getUserAccount()
      .then(res => {
        const userAccount = res.data;
        if (userAccount.Id) {
          this.saveSignIn(googleUser, userAccount);
          this.ngNotify.set('Google Sign In Success', {
            duration: 2000,
            position: 'bottom'
          });
          // HERE WE NEED TO UPDATE ACCOUNT WITH TOKEN
          this.$state.go('documents');
        } else {
          this.createUserAccount(googleUser);
        }
      })
      .catch(res => {
        this.log.debug(res);
        this.createUserAccount(googleUser);
      });
  }

  signInRejected() {
    this.ngNotify.set('Google Sign In Error ', {
      type: 'error',
      duration: 2000
    });
  }

  saveSignIn(googleUser, userAccount) {
    this.sessionService.setAuthData(googleUser, userAccount);
  }

  createUserAccount(user) {
    this.$state.go('user-create', {user});
  }
}

export default LoginController;
