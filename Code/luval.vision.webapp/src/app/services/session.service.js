class sessionService {
  constructor($log, $state, $window) {
    this.log = $log;
    this.$state = $state;
    this.$window = $window;
  }

  destroy() {
    this.setAuthData(null);
  }

  getAuthData() {
    const session = this.$window.localStorage.getItem('user-session');
    if (session) {
      return angular.fromJson(session);
  	} // eslint-disable-line no-mixed-spaces-and-tabs
  }

  setAuthData(user) {
    const session = angular.toJson({authData: user});
    this.$window.localStorage.setItem('user-session', session);
  }
}

export default sessionService;
