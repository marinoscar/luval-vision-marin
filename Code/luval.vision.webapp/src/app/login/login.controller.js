class LoginController {
  /* @ngInject */
  constructor($log, $state, ngNotify, errorService, usersService, loginService, sessionService, documentService) {
    this.$state = $state;
    this.$log = $log;
    this.ngNotify = ngNotify;
    this.errorService = errorService;
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
    this.usersService
      .getUserAccount(this.sessionService.getAuthData().account.Email)
      .then(res => {
        this.accountAlreadyExists(googleUser, res.data);
      })
      .catch(res => {
        this.$log.debug(res);
        this.createUserAccount(googleUser);
      });
  }

  signInRejected() {
    this.ngNotify.set('Google Sign In Error ', {
      type: 'error',
      duration: 2000
    });
  }

  accountAlreadyExists(googleUser, userAccount) {
    if (userAccount.Id) {
      this.saveSignIn(googleUser, userAccount);
      userAccount.ApiToken = googleUser.Zi.access_token;
      this.usersService.updateUserAccount(userAccount)
        .then(res => {
          this.saveSignIn(googleUser, res.data);
          this.ngNotify.set('Google Sign In Success', {
            duration: 2000,
            position: 'bottom'
          });
          this.$state.go('documents');
        })
        .catch(res => this.errorService.handleError(res));
    } else {
      this.createUserAccount(googleUser);
    }
  }

  saveSignIn(googleUser, userAccount) {
    this.sessionService.setAuthData(googleUser, userAccount);
  }

  createUserAccount(user) {
    this.$state.go('user-create', {user});
  }
}

export default LoginController;
