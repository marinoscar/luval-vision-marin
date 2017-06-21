class sessionService {
  /* @ngInject */
  constructor($log, $state, $window, $base64) {
    this.$log = $log;
    this.$state = $state;
    this.$window = $window;
    this.$base64 = $base64;
  }

  destroy() {
    this.$window.localStorage.removeItem('user-session');
  }

  getAuthData() {
    const session = this.$window.localStorage.getItem('user-session');
    if (session) {
      return angular.fromJson(session).authData;
  	} // eslint-disable-line no-mixed-spaces-and-tabs
  }

  setAuthData(user) { // .w3.U3
    const authToken = user;
    authToken.w3.U3 = this.replaceSpecialCharacters(authToken.w3.U3);
    const session = angular.toJson({authData: user});
    this.$window.localStorage.setItem('user-session', session);
  }

  getAuthorization() {
    const email = (this.getAuthData() && this.getAuthData().account) ? this.getAuthData().account.Email : '';
    const token = (this.getAuthData() && this.getAuthData().account) ? this.getAuthData().account.ApiToken : '';
    const user = {
      Email: email,
      ApiToken: token
    };
    return 'Basic ' + this.$base64.encode(user.Email + ':' + user.ApiToken);
  }

  buildUserJSON() {
    return {
      userId: this.getAuthData().w3.U3
    };
  }

  replaceSpecialCharacters(source) {
    return source.replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi, '') // eslint-disable-line
  }
}

export default sessionService;
