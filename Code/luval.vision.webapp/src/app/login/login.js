import loginController from './login.controller';
import loginService from './login.service';
import routes from './login.routes';

export default
  angular
    .module('luval-vision.login', [])
    .config(routes)
    .controller('LoginController', loginController)
    .service('LoginService', loginService)
    .name;
