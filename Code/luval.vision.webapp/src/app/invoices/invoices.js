import InvoicesController from './invoices.controller';
import InvoicesModalController from './invoices-modal/invoices-modal.controller';
import invoicesService from './invoices.service';
import sessionService from '../services/session.service';
import documentService from '../services/document.service';
import routes from './invoices.routes';

export default
  angular
    .module('luval-vision.invoices', [])
    .config(routes)
    .controller('InvoicesController', InvoicesController)
    .controller('InvoicesModalController', InvoicesModalController)
    .service('invoicesService', invoicesService)
    .service('sessionService', sessionService)
    .service('documentService', documentService)
    .name;
