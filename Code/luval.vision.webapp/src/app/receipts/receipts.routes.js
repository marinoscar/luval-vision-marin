/** @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('receipts', {
      url: '/receipts',
      template: require('./receipts.html'),
      controller: ('ReceiptsController as vm')
    })
    .state('receipt', {
      url: '/receipts/:id',
      template: require('./receipt.html'),
      controller: ('ReceiptsController as vm')
    });
}

export default routes;
