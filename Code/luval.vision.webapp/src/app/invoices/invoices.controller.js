class InvoicesController {
  constructor($log, $state, $uibModal, invoicesService, documentService) {
    this.log = $log;
    this.$state = $state;
    this.$uibModal = $uibModal;
    this.invoicesService = invoicesService;
    this.documentService = documentService;
    this.invoicesService.getFilesStored()
      .then(this.filesStoredHandler.bind(this), this.filesStoredRejected);
  }

  uploadFile($files) {
    const $file = $files[0];
    const json = {
      userId: this.invoicesService.buildUserJSON().id,
      file: $file
    };
    this.invoicesService.uploadDocumenToBlobStorage(json)
      .then(invoices => {
        this.serializeInvoice = angular.fromJson(invoices.data);
        this.documentService.setMetadata(this.serializeInvoice);
        this.documentService.setFileData(this.serializeInvoice.FileData);
        this.$state.go('check-invoice');
      });
  }

  filesStoredHandler(invoices) {
    this.invoices = invoices.data;
    this.documentService.setMetadata(invoices);
  }

  showInvoice(invoice) {
    this.documentService.setMetadata(invoice);
  }

  openInvoiceModal() {
    const modalInstance = this.$uibModal.open({
      animation: true,
      templateUrl: 'app/invoices/invoices-modal/invoices-modal.html',
      controller: 'InvoicesModalController',
      controllerAs: 'vm',
      size: 'sm'
    });

    modalInstance.result.then(this.modalHandler.bind(this), this.modalRejected.bind(this));
  }

  modalHandler() {
    this.log.info('');
  }

  modalRejected() {
    this.log.info('');
  }

  filesStoredRejected(err) {
    if (err.status === 500) {
      // TODO
    }
  }
}

export default InvoicesController;
