class sessionService {
  /* @ngInject */
  constructor($log, $state, $window, $base64) {
    this.$log = $log;
    this.$state = $state;
    this.$window = $window;
    this.$base64 = $base64;
    this.currentUser = {};
  }

  destroy() {
    this.currentUser = {
      IsEnabled: false,
      IsApproved: false,
      Role: 'User'
    };
    this.$window.localStorage.removeItem('user-session');
  }

  getCurrentUser() {
    return this.currentUser;
  }

  getAuthData() {
    const session = this.$window.localStorage.getItem('user-session');
    if (session) {
      return angular.fromJson(session).authData;
  	} // eslint-disable-line no-mixed-spaces-and-tabs
  }

  setAuthData(googleUser, userAccount) {
    const authToken = googleUser;
    if (userAccount) {
      this.currentUser = userAccount;

      authToken.account = this.currentUser;
    } else {
      this.currentUser = {
        Email: authToken.w3.U3,
        Name: authToken.w3.ig,
        IsEnabled: false,
        IsApproved: false,
        UserId: this.replaceSpecialCharacters(authToken.w3.U3),
        Role: 'User'
      };

      authToken.account = this.currentUser;
    }
    const session = angular.toJson({authData: authToken});
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
    const id = (this.getAuthData() && this.getAuthData().account) ? this.getAuthData().account.UserId : '';
    return {
      userId: id
    };
  }

  replaceSpecialCharacters(source) {
    return source.replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi, '') // eslint-disable-line
  }
}

export default sessionService;
