class errorService {
  /* @ngInject */
  constructor(loginService, ngNotify, $log, $state) {
    this.loginService = loginService;
    this.ngNotify = ngNotify;
    this.$log = $log;
    this.$state = $state;
  }

  handleError(res) {
    if (res.status === 401) {
      this.ngNotify.set('Your account is not authorized.', 'error');
      this.loginService.logOut();
      this.$state.go('login');
    } else if (res.status === -1) {
      this.ngNotify.set('Our server is not available at this moment. Please try again in some minutes.', 'error');
    } else {
      this.ngNotify.set('Something went wrong. Please try again in some minutes.', 'error');
    }
  }
}

export default errorService;
