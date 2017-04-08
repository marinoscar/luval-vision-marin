/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('check-invoice', {
      url: '/check-invoice',
      template: require('./check-invoice.html'),
      controller: ('CheckInvoicesController as vm')
    });
}

export default routes;
