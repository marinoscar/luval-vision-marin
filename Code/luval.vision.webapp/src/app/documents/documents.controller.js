class DocumentsController {
  /* @ngInject */
  constructor($q, $log, $state, ngNotify, $uibModal, documentsService, usSpinnerService, documentService) {
    this.$q = $q;
    this.$log = $log;
    this.$state = $state;
    this.$uibModal = $uibModal;
    this.ngNotify = ngNotify;
    this.documentsService = documentsService;
    this.documentService = documentService;
    this.usSpinnerService = usSpinnerService;
    this.loading = true;
    this.documentsService.resetDocumentsList();
    this.documentsService.getDocumentsStored()
      .then(this.documentStoredHandler.bind(this),
      this.documentStoredRejected.bind(this));
  }

  uploadFile($files) {
    this.loading = true;
    this.documentsService.uploadDocumenToBlobStorage(this.documentService.objectBlobStorage($files))
      .then(this.fileUploadedHandler.bind(this), this.fileUploadedRejected.bind(this));
  }

  fileUploadedHandler(documents) {
    this.loading = false;
    this.serializeDocument = angular.fromJson(documents.data);
    this.documentService.setMetadata(this.serializeDocument);
    this.documentService.setFileData(this.serializeDocument.FileData);
    this.$state.go('check-documents', {tokenId: this.serializeDocument.Result.Id});
    this.ngNotify.set('Successful Loaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  fileUploadedRejected() {
    this.ngNotify.set('Falied Load', {
      duration: 2000,
      position: 'bottom',
      type: 'error'
    });
  }

  showDocument(file) {
    this.documentService.setMetadata(file);
    this.documentService.setFileData(file.FileData);
    this.$state.go('check-documents', {tokenId: file.Id});
    this.ngNotify.set('Successful Loaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  documentStoredHandler(documents) {
    this.documents = documents.data;
    this.serializeDocumentsContent(this.documents)
      .then(this.serializeDocumentsHandler.bind(this),
      this.serializeDocumentsRejected.bind(this));
  }

  serializeDocumentsRejected() {
    this.loading = false;
  }

  serializeDocumentsHandler(documents) {
    this.loading = false;
    this.documentService.setMetadata(documents);
  }

  serializeDocumentsContent(documents) {
    this.documentDeferred = this.$q.defer();
    angular.forEach(documents, index => {
      index.Content = angular.fromJson(index.Content);
      const documentsContent = index;
      this.setDocumentContent(documentsContent.Content);
    });
    this.documents = this.documentsService.getDocumentsList();
    this.documentDeferred.resolve(this.documents);
    return this.documentDeferred.promise;
  }

  setDocumentContent(documentContent) {
    this.initilizeDocumentInfo(documentContent);
    angular.forEach(documentContent.Result.TextResults, index => {
      this.documentsInfo.attributes.push(index.Value);
    });
    this.documentsService.addDocument(this.documentsInfo);
  }

  initilizeDocumentInfo(documentContent) {
    this.documentsInfo = {};
    this.documentsInfo.attributes = [];
    this.documentsInfo.Id = documentContent.Result.Id;
    this.documentsInfo.UserId = documentContent.Result.UserId;
    this.documentsInfo.FileName = documentContent.FileName;
    this.documentsInfo.FileData = documentContent.FileData;
    this.documentsInfo.Result = documentContent.Result;
  }

  openDocumentModal() {
    this.$uibModal.open({
      animation: true,
      templateUrl: 'app/documents/documents-modal/documents-modal.html',
      controller: 'DocumentsModalController',
      controllerAs: 'vm',
      size: 'sm'
    });
  }

  documentStoredRejected() {
    this.loading = false;
    this.ngNotify.set('Documents are not available', {
      type: 'error',
      duration: 2000
    });
  }
}

export default DocumentsController;
