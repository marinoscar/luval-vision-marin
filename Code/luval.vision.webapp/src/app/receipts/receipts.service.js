class ReceiptsService {
  constructor(RequestService) {
    this.http = RequestService;
  }

  getAllReceipts() {
    return this.http.get('http://localhost:55993/api/v1/Storage/');
  }

  postReceipt() {
    return null;
  }

  getReceipt(id) {
    return this.http.get(`receipts/${id}`);
  }
}

export default ReceiptsService;
