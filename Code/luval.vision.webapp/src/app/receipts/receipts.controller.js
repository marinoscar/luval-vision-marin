class ReceiptsController {
  constructor($log, ReceiptsService) {
    this.$log = $log;
    this.ReceiptsService = ReceiptsService;
  }

  getReceipt() {
    this.ReceiptsService.getReceipt(this.$stateParams.id);
  }

  getAllReceipts() {
    this.ReceiptsService.getAllReceipts();
  }
}

export default ReceiptsController;
