import ReceiptController from './receipt.controller';
import ReceiptService from './receipt.service';
import routes from './receipt.routes';

export default
  angular
    .module('luval-vision.receipt', [])
    .config(routes)
    .controller('ReceiptController', ReceiptController)
    .service('ReceiptService', ReceiptService)
    .service('ReceiptService', ReceiptService)
    .name;
