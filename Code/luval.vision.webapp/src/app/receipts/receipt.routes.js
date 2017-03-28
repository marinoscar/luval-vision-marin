function routes($stateProvider) {
  $stateProvider
    .state('receipt', {
      url: '/receipts/:id',
      template: require('./receipt.html'),
      controller: ('ReceiptController as vm')
    })
    .state('receipts', {
      url: '/receipts',
      template: require('./receipts.html'),
      controller: ('ReceiptController as vm')
    });
}

export default routes;
