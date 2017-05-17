import DocumentsController from './documents.controller';
import DocumentsModalController from './documents-modal/documents-modal.controller';
import documentsService from './documents.service';
import sessionService from '../services/session.service';
import documentService from '../services/document.service';
import routes from './documents.routes';

export default
  angular
    .module('luval-vision.documents', [])
    .config(routes)
    .controller('DocumentsController', DocumentsController)
    .controller('DocumentsModalController', DocumentsModalController)
    .service('documentsService', documentsService)
    .service('sessionService', sessionService)
    .service('documentService', documentService)
    .name;
