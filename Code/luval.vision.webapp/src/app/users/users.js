import usersService from './users.service';

export default
  angular
    .module('luval-vision.users', [])
    .service('usersService', usersService)
    .name;
