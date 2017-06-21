import LoginController from './login.controller';
import loginService from './login.service';
import sessionService from '../services/session.service';
import routes from './login.routes';

export default
  angular
    .module('luval-vision.login', [])
    .config(routes)
    .controller('LoginController', LoginController)
    .service('loginService', loginService)
    .service('sessionService', sessionService)
    .name;
