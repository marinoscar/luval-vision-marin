class loginService {
  /* @ngInject */
  constructor($log, $location, GoogleSignin, documentService, sessionService, $http, CORE) { // eslint-disable-line max-params
    this.log = $log;
    this.$location = $location;
    this.GoogleSignin = GoogleSignin;
    this.documentService = documentService;
    this.sessionService = sessionService;
    this.$http = $http;
    this.CORE = CORE;
  }

  isLoggedIn() {
    const authData = this.sessionService.getAuthData().w3.U3;
    const sessionDefined = typeof authData !== 'undefined'; // eslint-disable-line
    const authDataDefined = authData !== null;
    return sessionDefined && authDataDefined;
  }

  logOut() {
    return this.GoogleSignin.signOut();
  }

  callGoogleSignIn() {
    return this.GoogleSignin.signIn();
  }

  buildUserJSON(user) {
    return {
      token_id: this.documentService.replaceSpecialCharacters(user.w3.U3) // eslint-disable-line camelcase
    };
  }
}

export default loginService;
