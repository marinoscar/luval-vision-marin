/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('invoices', {
      url: '/invoices',
      template: require('./invoices.html'),
      controller: ('InvoicesController as vm')
    });
}

export default routes;
