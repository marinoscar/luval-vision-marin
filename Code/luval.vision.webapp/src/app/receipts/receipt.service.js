class ReceiptService {
  constructor(RequestService) {
    this.http = RequestService;
  }

  getAllReceipts() {
    return this.http.get('receipts/');
  }

  getReceipt(id) {
    return this.http.get(`receipts/${id}`);
  }
}

export default ReceiptService;
