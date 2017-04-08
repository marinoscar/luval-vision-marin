class CheckInvoicesController {
  constructor($state, $log, documentService) {
    this.$state = $state;
    this.log = $log;
    this.documentService = documentService;
    this.metadata = this.documentService.getMetadata();
    this.imageSrc = this.documentService.getFileData();
    this.log.info(this.metadata);
    this.primaryData = this.metadata.Result.TextResults;
    this.log.info(this.metadata);
  }

  backToInvoices() {
    this.$state.go('invoices');
  }
}

export default CheckInvoicesController;
