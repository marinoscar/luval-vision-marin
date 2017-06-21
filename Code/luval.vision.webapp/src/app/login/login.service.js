class loginService {
  /* @ngInject */
  constructor($log, $location, GData, GAuth, documentService, sessionService, $http, CORE) { // eslint-disable-line max-params
    this.log = $log;
    this.$location = $location;
    this.GData = GData;
    this.GAuth = GAuth;
    this.documentService = documentService;
    this.sessionService = sessionService;
    this.$http = $http;
    this.CORE = CORE;
  }

  checkAuth() {
    return this.GAuth.checkAuth();
  }

  logOut() {
    return this.GAuth.logout();
  }

  callGoogleSignIn() {
    return this.GAuth.login();
  }

  buildUserJSON(user) {
    return {
      token_id: this.documentService.replaceSpecialCharacters(user.w3.U3) // eslint-disable-line camelcase
    };
  }
}

export default loginService;
