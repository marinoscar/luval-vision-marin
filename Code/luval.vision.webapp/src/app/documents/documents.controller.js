class DocumentsController {
  /* @ngInject */
  constructor($q, $log, $state, ngNotify, $uibModal, documentsService, errorService, usSpinnerService, documentService) {
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
      .then(this.documentStoredHandler.bind(this),
      this.documentStoredRejected.bind(this));
    this.documentsService.getProfiles()
      .then(this.profilesLoadedHandler.bind(this));
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

  uploadFile($files, profileName) {
    this.loading = true;
    this.documentsService.uploadDocumenToBlobStorage(this.documentService.objectBlobStorage($files, profileName))
      .then(this.fileUploadedHandler.bind(this), this.fileUploadedRejected.bind(this));
  }

  fileUploadedHandler(documents) {
    this.loading = false;
    this.serializeDocument = angular.fromJson(documents.data);
    this.$state.go('check-documents', {tokenId: this.serializeDocument.Result.Id});
    this.ngNotify.set('Successfully Loaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  fileUploadedRejected() {
    this.loading = false;
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

  documentStoredHandler(documents) {
    this.documents = documents.data;
    this.serializeDocumentsContent(this.documents)
      .then(this.stopLoading.bind(this),
      this.stopLoading.bind(this));

    this.totalItems = this.documents.length;
  }

  stopLoading() {
    this.loading = false;
  }

  serializeDocumentsContent(documents) {
    this.documentDeferred = this.$q.defer();
    angular.forEach(documents, index => {
      index.Content = angular.fromJson(index.Content);
      const documentsContent = index;
      documentsContent.Content.ProfileName = index.ProfileName;
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
    this.documentsInfo.ProfileName = documentContent.ProfileName;
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

  documentStoredRejected(res) {
    this.loading = false;
    this.errorService.handleError(res);
  }

  getPaginationLowerBound() {
    return (this.currentPage - 1) * this.itemsPerPage;
  }

  getPaginationUpperBound() {
    return this.currentPage * this.itemsPerPage;
  }
}

export default DocumentsController;
