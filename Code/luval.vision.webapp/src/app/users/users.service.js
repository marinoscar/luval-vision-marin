class usersService {
  /* @ngInject */
  constructor($log, $http, CORE) { // eslint-disable-line max-params
    this.log = $log;
    this.$http = $http;
    this.CORE = CORE;
  }

  createUserAccount(user) {
    const postRequest = {
      method: 'POST',
      url: this.CORE.URL + 'Users',
      data: user
    };
    return this.$http(postRequest);
  }
}

export default usersService;
