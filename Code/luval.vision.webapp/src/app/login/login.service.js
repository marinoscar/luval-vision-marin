class loginService {
  /* @ngInject */
  constructor($log, GoogleSignin, sessionService, usersService) { // eslint-disable-line max-params
    this.log = $log;
    this.GoogleSignin = GoogleSignin;
    this.sessionService = sessionService;
    this.usersService = usersService;

    this.fetchUserAccount();
  }

  fetchUserAccount() {
    this.usersService.getUserAccount()
      .then(res => {
        const userAccount = res.data;
        const authData = this.sessionService.getAuthData();
        this.sessionService.setAuthData(authData, userAccount);
      })
      .catch(res => {
        this.log.debug(res);
      });
  }

  isLoggedIn() {
    const authData = this.sessionService.getAuthData().w3.U3;
    const sessionDefined = typeof authData !== 'undefined'; // eslint-disable-line
    const authDataDefined = authData !== null;
    return sessionDefined && authDataDefined && authData.w3 && authData.w3.U3;
  }

  isAuthorized() {
    const authData = this.sessionService.getAuthData();
    const sessionDefined = typeof authData !== 'undefined'; // eslint-disable-line
    const authDataDefined = authData !== null;
    return sessionDefined && authDataDefined && authData.isAuthorized;
  }

  isAdmin() {
    const role = this.sessionService.getCurrentUser().role ?
      this.sessionService.getCurrentUser().role : this.sessionService.getAuthData().role;
    return role === 'Admin';
  }

  logOut() {
    this.sessionService.destroy();
    // return this.GoogleSignin.signOut();
  }

  callGoogleSignIn() {
    return this.GoogleSignin.signIn();
  }
}

export default loginService;
