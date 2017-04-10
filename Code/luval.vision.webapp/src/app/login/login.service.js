class loginService {
  constructor($log, $rootScope, $location, GoogleSignin, documentService, $http, CORE) { // eslint-disable-line max-params
    this.log = $log;
    this.$rootScope = $rootScope;
    this.$location = $location;
    this.GoogleSignin = GoogleSignin;
    this.documentService = documentService;
    this.$http = $http;
    this.CORE = CORE;
  }

  isLoggedIn() {
    const authData = this.sessionService.getAuthData();
    const sessionDefined = angular.isDefined(authData);
    const authDataDefined = authData !== null;
    return sessionDefined && authDataDefined;
  }

  verifyAccess() {
    this.$rootScope.$on('$stateChangeStart', toState => {
      if (!this.isLoggedIn() && toState.name !== 'login') {
        this.$location.path('login');
      }
    });
  }

  logOut() {
  //  this.log.info(this.GoogleSignin.getBasicProfile());
    return this.GoogleSignin.signOut();
  }

  callGoogleSignIn() {
    this.log.info(this.GoogleSignin.getBasicProfile());
    return this.GoogleSignin.signIn();
  }

  buildUserJSON(user) {
    return {
      token_id: this.documentService.replaceSpecialCharacters(user.w3.U3) // eslint-disable-line camelcase
    };
  }
}

export default loginService;
