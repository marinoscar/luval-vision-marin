import ViewJsonController from './view-json.controller';
import documentService from '../services/document.service';
import routes from './view-json.routes';

export default
  angular
    .module('luval-vision.view-json', [])
    .config(routes)
    .controller('ViewJsonController', ViewJsonController)
    .service('documentService', documentService)
    .name;