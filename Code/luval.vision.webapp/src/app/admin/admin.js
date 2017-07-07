import AdminController from './admin.controller';
import routes from './admin.routes';

export default
  angular
    .module('luval-vision.admin', [])
    .config(routes)
    .controller('AdminController', AdminController)
    .name;
