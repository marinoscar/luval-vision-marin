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
      .then(this.stopLoading.bind(this),
      this.stopLoading.bind(this));

    this.totalItems = this.documents.length;
  }

  serializeDocumentsContent(documents) {
    this.documentDeferred = this.$q.defer();
    angular.forEach(documents, index => {
      index.Content = angular.fromJson(index.Content);
      const documentsContent = index;
      documentsContent.Content.ProfileName = index.ProfileName;
      this.setDocumentContent(documentsContent);
    });
    this.documents = this.documentsService.getDocumentsList();
    this.documentDeferred.resolve(this.documents);
    return this.documentDeferred.promise;
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
    this.documentsService.uploadDocumenToBlobStorage(this.documentService.objectBlobStorage($files, profileName))
      .then(this.fileUploadedHandler.bind(this), this.fileUploadedRejected.bind(this));
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

  setDocumentContent(documentContent) {
    this.initilizeDocumentInfo(documentContent.Content);
    angular.forEach(documentContent.Content.Result.TextResults, index => {
      this.documentsInfo.attributes.push(index.Value);
      this.documentsInfo.createdDate = documentContent.Date;
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

  getPaginationLowerBound() {
    return (this.currentPage - 1) * this.itemsPerPage;
  }

  getPaginationUpperBound() {
    return this.currentPage * this.itemsPerPage;
  }
}

export default DocumentsController;
