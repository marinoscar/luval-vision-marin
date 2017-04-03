class loginService {
  constructor($log, GoogleSignin, $http, CORE) {
    this.log = $log;
    this.GoogleSignin = GoogleSignin;
    this.$http = $http;
    this.CORE = CORE;
  }

  callGoogleSignIn() {
    return this.GoogleSignin.signIn();
  }

  saveOrUpdateUser(user) {
    const post = {
      method: 'POST',
      url: this.CORE.URL + 'User',
      headers: {
        'Content-Type': 'application/json'
      },
      data: this.buildUserJSON(user)
    };
    return this.$http(post);
  }

  buildUserJSON(user) {
    return {
      token_id: user.Zi.id_token // eslint-disable-line camelcase
    };
  }
}

export default loginService;
