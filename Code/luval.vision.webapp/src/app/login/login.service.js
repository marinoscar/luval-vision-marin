class loginService {
  constructor($log, GoogleSignin) {
    this.log = $log;
    this.GoogleSignin = GoogleSignin;
  }

  callGoogleSignIn() {
    return this.GoogleSignin.signIn();
  }
}

export default loginService;
