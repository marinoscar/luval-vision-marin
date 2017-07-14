class usersService {
  /* @ngInject */
  constructor($log, $http, CORE, sessionService) { // eslint-disable-line max-params
    this.log = $log;
    this.$http = $http;
    this.CORE = CORE;
    this.sessionService = sessionService;
  }

  getUserAccount(email) {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Users',
      params: {
        userEmail: email
      }
    };
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
    return this.$http(putRequest);
  }

  getAllUsers() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Users/GetAll'
    };
    return this.$http(getRequest);
  }
}

export default usersService;
