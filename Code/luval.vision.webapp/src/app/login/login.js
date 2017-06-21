import LoginController from './login.controller';
import LoginCreateController from './create/login-create.controller';
import loginService from './login.service';
import sessionService from '../services/session.service';
import authorizationInjectorService from '../services/authorization-injector.service';
import routes from './login.routes';
import 'ng-google-signin/dist/ng-google-signin';

export default
  angular
    .module('luval-vision.login', [])
    .config(routes)
    .config(GoogleSignInConfig)
    .controller('LoginController', LoginController)
    .controller('LoginCreateController', LoginCreateController)
    .service('loginService', loginService)
    .service('sessionService', sessionService)
    .service('authorizationInjectorService', authorizationInjectorService)
    .name;

/* @ngInject */
function GoogleSignInConfig(GoogleSigninProvider) {
  GoogleSigninProvider.init({
    client_id: '387533728662-ovqlpu27rait2m5idsa6aadqf7qa00e4.apps.googleusercontent.com' // eslint-disable-line camelcase
  });
}
