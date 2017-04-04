/** @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('check-receipts', {
      url: '/check-receipts',
      template: require('./check-receipts.html'),
      controller: ('CheckReceiptsController as vm')
    });
}

export default routes;
