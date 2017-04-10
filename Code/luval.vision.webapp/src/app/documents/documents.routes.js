/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('documents', {
      url: '/documents',
      template: require('./documents.html'),
      controller: ('DocumentsController as vm')
    });
}

export default routes;
