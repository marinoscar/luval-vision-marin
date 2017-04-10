class DocumentsController {
  /* @ngInject */
  constructor($q, $log, $state, ngNotify, $uibModal, documentsService, documentService) {
    this.$q = $q;
    this.log = $log;
    this.$state = $state;
    this.$uibModal = $uibModal;
    this.ngNotify = ngNotify;
    this.loading = true;
    this.documentsService = documentsService;
    this.documentService = documentService;
    this.documentsService.getDocumentsStored()
      .then(this.documentStoredHandler.bind(this),
      this.documentStoredRejected);
  }

  uploadFile($files) {
    this.documentsService.uploadDocumenToBlobStorage(this.objectBlobStorage($files))
      .then(documents => {
        this.serializeDocument = angular.fromJson(documents.data);
        this.documentService.setMetadata(this.serializeDocument);
        this.documentService.setFileData(this.serializeDocument.FileData);
        this.documentsService.resetDocumentsList();
        this.$state.go('check-documents', {tokenId: this.serializeDocument.Result.Id});
      });
  }

  objectBlobStorage(files) {
    return {
      userId: this.documentsService.buildUserJSON().id,
      file: files[0]
    };
  }

  showDocument(file) {
    this.documentService.setMetadata(file);
    this.documentService.setFileData(file.FileData);
    this.documentsService.resetDocumentsList();
    this.$state.go('check-documents', {tokenId: file.Id});
  }

  documentStoredHandler(documents) {
    this.log.info(documents);
    this.documents = documents.data;
    this.serializeDocumentsContent(this.documents)
      .then(this.serializeDocumentsHandler.bind(this));
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
      if (index.Map.attributeName === 'DueDate') {
        this.documentsInfo.date = index.Value;
      } else if (index.Map.attributeName === 'Date') {
        this.documentsInfo.dueDate = index.Value;
      } else if (index.Map.attributeName === 'Total') {
        this.documentsInfo.total = index.Value;
      } else if (index.Map.attributeName === 'InvoiceNumber') {
        this.documentsInfo.invoiceNumber = index.Value;
      } else if (index.Map.attributeName === 'PONumber') {
        this.documentsInfo.poNumber = index.Value;
      }
    });
    this.documentsService.addDocument(this.documentsInfo);
  }

  initilizeDocumentInfo(documentContent) {
    this.documentsInfo = {};
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
