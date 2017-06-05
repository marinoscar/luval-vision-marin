class sessionService {
  /* @ngInject */
  constructor($log, $state, $window, $base64) {
    this.$log = $log;
    this.$state = $state;
    this.$window = $window;
    this.$base64 = $base64;
  }

  destroy() {
    this.setAuthData(null);
  }

  getAuthData() {
    const session = this.$window.localStorage.getItem('user-session');
    if (session) {
      return angular.fromJson(session).authData;
  	} // eslint-disable-line no-mixed-spaces-and-tabs
  }

  setAuthData(user) {
    const session = angular.toJson({authData: user});
    this.$window.localStorage.setItem('user-session', session);
  }

  getAuthorization() {
    const user = {
      Email: this.getAuthData().w3.U3,
      ApiToken: this.getAuthData().Zi.access_token
    };
    return 'Basic ' + this.$base64.encode(user.Email + ':' + user.ApiToken);
  }

  buildUserJSON() {
    return {
      userId: this.getAuthData().w3.U3
    };
  }
}

export default sessionService;
