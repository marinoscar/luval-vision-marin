/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('check-documents', {
      url: '/check-documents/tokenId=:tokenId',
      template: require('./check-documents.html'),
      controller: ('CheckDocumentsController as vm'),
      cache: false
    });
}

export default routes;
