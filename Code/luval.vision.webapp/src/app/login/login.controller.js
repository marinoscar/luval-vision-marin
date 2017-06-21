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

  signInHandler(user) {
    this.saveSignIn(user, null);
    this.usersService.getUserAccount()
      .then(res => {
        const userAccount = res.data;
        if (userAccount.id) {
          this.saveSignIn(user, userAccount);
          this.ngNotify.set('Google Sign In Success', {
            duration: 2000,
            position: 'bottom'
          });
          this.$state.go('documents');
        } else {
          this.createUserAccount(user);
        }
      })
      .catch(res => {
        this.log.debug(res);
        this.createUserAccount(user);
      });
  }

  signInRejected() {
    this.ngNotify.set('Google Sign In Error ', {
      type: 'error',
      duration: 2000
    });
  }

  saveSignIn(user, userAccount) { // .w3.U3
    const authToken = user;
    const email = authToken.w3.U3;
    const userId = this.documentService.replaceSpecialCharacters(authToken.w3.U3);
    const account = {
      Email: email,
      Name: authToken.w3.ig,
      UserId: userId,
      ApiToken: authToken.Zi.access_token
    };
    this.usersService.createUserAccount(account)
      .then(res => {
        authToken.w3.U3 = userId;
        authToken.account = res.data;
        this.sessionService.setAuthData(authToken); // eslint-disable-line no-useless-escape
        this.sessionService.setAuthData(googleUser, userAccount);
        this.$state.go('documents');
      });
  }

  createUserAccount(user) {
    this.$state.go('user-create', {user});
  }
}

export default LoginController;
