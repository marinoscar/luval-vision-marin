class LoginController {
  constructor($log, $state, loginService, sessionService) {
    this.$state = $state;
    this.log = $log;
    this.loginService = loginService;
    this.sessionService = sessionService;
  }

  onSignIn() {
    this.loginService.callGoogleSignIn()
      .then(user => {
        this.saveSignIn(user);
      }, function (err) {
        this.log.error(err);
      });
  }

  uploadFile() {
    const $file = this.fileSelected[0];
    const json = {
      userId: this.sessionService.getAuthData().authData.id,
      file: $file
    };
    this.loginService.uploadDocumenToBlobStorage(json)
      .then(item => {
        this.log.info(item);
      });
  }

  onFileSelect($files) {
    this.fileSelected = $files;
  }

  saveSignIn(user) {
    this.loginService.saveOrUpdateUser(user)
      .then(user => {
        this.sessionService.setAuthData(user.data);
        this.$state.go('receipts');
      });
  }
}

export default LoginController;
