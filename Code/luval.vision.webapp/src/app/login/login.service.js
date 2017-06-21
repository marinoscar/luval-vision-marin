class loginService {
  /* @ngInject */
  constructor($log, GoogleSignin, sessionService) { // eslint-disable-line max-params
    this.log = $log;
    this.GoogleSignin = GoogleSignin;
    this.sessionService = sessionService;
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

  logOut() {
    this.sessionService.destroy();
    // return this.GoogleSignin.signOut();
  }

  callGoogleSignIn() {
    return this.GoogleSignin.signIn();
  }
}

export default loginService;
