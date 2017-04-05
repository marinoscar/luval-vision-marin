class loginService {
  constructor($log, GoogleSignin, $http, Upload, CORE) { // eslint-disable-line max-params
    this.log = $log;
    this.GoogleSignin = GoogleSignin;
    this.$http = $http;
    this.upload = Upload;
    this.CORE = CORE;
  }

  callGoogleSignIn() {
    return this.GoogleSignin.signIn();
  }

  uploadDocumenToBlobStorage(blob) {
    const upload = this.upload.upload({
      url: 'http://localhost:55993/api/v1/Provider',
      method: 'POST',
      data: blob,
      file: blob.file
    });
    return upload;
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
