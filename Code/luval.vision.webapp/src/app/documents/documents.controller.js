class DocumentsController {
  /* @ngInject */
  constructor($q, $log, $state, ngNotify, $uibModal, documentsService,
              errorService, usSpinnerService, documentService) {
    this.$q = $q;
    this.$log = $log;
    this.$state = $state;
    this.$uibModal = $uibModal;
    this.ngNotify = ngNotify;
    this.profiles = [];
    this.documentsService = documentsService;
    this.documentService = documentService;
    this.errorService = errorService;
    this.usSpinnerService = usSpinnerService;
    this.loading = true;
    this.documentsService.resetDocumentsList();
    this.downloadImage = documentService.downloadImage.bind(documentService);
    this.viewJSON = documentService.openDocumentViewer.bind(documentService);
    this.activate();
  }

  activate() {
    this.currentPage = 1;
    this.itemsPerPage = 10;

    this.documentsService.getDocumentsStored()
      .then(
        this.documentStoredHandler.bind(this),
        this.documentStoredRejected.bind(this)
      );
    this.documentsService.getProfiles()
      .then(this.profilesLoadedHandler.bind(this));
  }

  documentStoredHandler(documents) {
    this.documents = documents.data;
    this.serializeDocumentsContent(this.documents)
      .then(
        this.stopLoading.bind(this),
        this.stopLoading.bind(this)
      );
    this.setNumberOfDocuments();
  }

  setNumberOfDocuments() {
    this.numberOfDocuments = this.documents.length;
  }

  serializeDocumentsContent(documents) {
    this.documentDeferred = this.$q.defer();
    angular.forEach(documents, doc => {
      doc.Content = angular.fromJson(doc.Content);
      const documentsContent = doc;
      documentsContent.Content.ProfileName = doc.ProfileName;
      this.setDocumentContent(documentsContent);
    });
    this.setSerializedDocuments();
    this.documentDeferred.resolve(this.documents);
    return this.documentDeferred.promise;
  }

  setSerializedDocuments() {
    this.documents = this.documentsService.getDocumentsList();
  }

  documentStoredRejected(res) {
    this.stopLoading();
    this.errorService.handleError(res);
  }

  profilesLoadedHandler(profiles) {
    this.profilesName = [];
    angular.forEach(profiles.data, profile => {
      if (profile !== null) {
        if (angular.isDefined(profile.profileName)) {
          this.profilesName.push(profile.profileName);
        } else {
          this.profilesName.push(profile);
        }
      }
    });
  }

  stopLoading() {
    this.loading = false;
  }

  startLoading() {
    this.loading = true;
  }

  uploadFile($files, profileName) {
    this.startLoading();
    this.documentsService.uploadDocumenToBlobStorage(
      this.documentService.objectBlobStorage($files, profileName)
      ).then(this.fileUploadedHandler.bind(this), this.fileUploadedRejected.bind(this));
  }

  fileUploadedHandler(documents) {
    this.stopLoading();
    this.serializeDocument = angular.fromJson(documents.data);
    this.$state.go('check-documents', {tokenId: this.serializeDocument.Result.Id});
    this.ngNotify.set('Successfully Loaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  fileUploadedRejected() {
    this.stopLoading();
    this.ngNotify.set('Falied to Load', {
      duration: 2000,
      position: 'bottom',
      type: 'error'
    });
  }

  showDocument(file) {
    this.$state.go('check-documents', {tokenId: file.Id});
    this.ngNotify.set('Successfully Loaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  setDocumentContent(doc) {
    this.initilizeDocumentInfo(doc.Content);
    angular.forEach(doc.Content.Result.TextResults, index => {
      this.docWithInfo.attributes.push(index.Value);
    });
    this.addDateToDocument(this.docWithInfo, doc.Date);
    this.documentsService.addDocument(this.docWithInfo);
  }

  initilizeDocumentInfo(documentContent) {
    this.docWithInfo = {};
    this.docWithInfo.attributes = [];
    this.docWithInfo.Id = documentContent.Result.Id;
    this.docWithInfo.UserId = documentContent.Result.UserId;
    this.docWithInfo.FileName = documentContent.FileName;
    this.docWithInfo.FileData = documentContent.FileData;
    this.docWithInfo.Result = documentContent.Result;
    this.docWithInfo.ProfileName = documentContent.ProfileName;
  }

  addDateToDocument(doc, date) {
    doc.createdDate = date;
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

  getPaginationLowerBound() {
    return (this.currentPage - 1) * this.itemsPerPage;
  }

  getPaginationUpperBound() {
    return this.currentPage * this.itemsPerPage;
  }
}

export default DocumentsController;
