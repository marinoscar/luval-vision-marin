class usersService {
  /* @ngInject */
  constructor($log, sessionService, $http, CORE) { // eslint-disable-line max-params
    this.log = $log;
    this.sessionService = sessionService;
    this.$http = $http;
    this.CORE = CORE;
  }

  getUserAccount(email) {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Users',
      params: {
        userEmail: email
      }
    };
    this.log.debug(getRequest);
    return this.$http(getRequest);
  }

  createUserAccount(user) {
    const postRequest = {
      method: 'POST',
      url: this.CORE.URL + 'Users',
      data: user
    };
    return this.$http(postRequest);
  }

  updateUserAccount(user) {
    const putRequest = {
      method: 'PUT',
      url: this.CORE.URL + 'Users',
      data: user
    };
    this.log.debug(putRequest);
    // return this.$http(putRequest);
    return this.$http.get('app/users/mocks/user.mock.json');
  }

  getAllUsers() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Users/GetAll'
    };
    this.log.debug(getRequest);
    // return this.$http(getRequest);
    return this.$http.get('app/users/mocks/users.mock.json');
  }
}

export default usersService;
