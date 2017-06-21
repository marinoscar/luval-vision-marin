import UserCreateController from './create/user-create.controller';
import routes from './users.routes';
import usersService from './users.service';

export default
  angular
    .module('luval-vision.users', [])
    .config(routes)
    .controller('UserCreateController', UserCreateController)
    .service('usersService', usersService)
    .name;
