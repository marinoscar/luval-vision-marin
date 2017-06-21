class usersService {
  /* @ngInject */
  constructor($log, sessionService, $http, CORE) { // eslint-disable-line max-params
    this.log = $log;
    this.sessionService = sessionService;
    this.$http = $http;
    this.CORE = CORE;
  }

  getUserAccount() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Users/Get',
      headers: {
        'Content-Type': 'application/json'
      },
      params: this.sessionService.buildUserJSON()
    };
    this.log.debug(getRequest);
    // return this.$http(getRequest);
    return this.$http.get('app/users/mocks/user.mock.json');
    // return this.$http.get('app/users/mocks/user.notfound.mock.json');
    // return this.$http.get('app/users/mocks/user.notauthorized.mock.json');
  }

  createUserAccount(user) {
    const postRequest = {
      method: 'POST',
      url: this.CORE.URL + 'Users/Post',
      headers: {
        'Content-Type': 'application/json'
      },
      data: user
    };
    this.log.debug(postRequest);
    return this.$http(postRequest);
    // return this.$http.get('app/users/mocks/user.mock.json');
  }

  updateUserAccount(user) {
    const putRequest = {
      method: 'PUT',
      url: this.CORE.URL + 'Users/Put',
      headers: {
        'Content-Type': 'application/json'
      },
      data: user
    };
    this.log.debug(putRequest);
    // return this.$http(putRequest);
    return this.$http.get('app/users/mocks/user.mock.json');
  }

  getAllUsers() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Users/GetAll',
      headers: {
        'Content-Type': 'application/json'
      },
      params: this.sessionService.buildUserJSON()
    };
    this.log.debug(getRequest);
    // return this.$http(getRequest);
    return this.$http.get('app/users/mocks/users.mock.json');
  }
}

export default usersService;
