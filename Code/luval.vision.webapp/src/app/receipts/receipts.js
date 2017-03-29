import ReceiptsController from './receipts.controller';
import ReceiptsService from './receipts.service';
import routes from './receipts.routes';

export default
  angular
    .module('luval-vision.receipt', [])
    .config(routes)
    .controller('ReceiptsController', ReceiptsController)
    .service('ReceiptsService', ReceiptsService)
    .name;
