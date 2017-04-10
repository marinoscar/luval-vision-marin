/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('view-json', {
      url: '/view-json/tokenId=:tokenId',
      template: require('./view-json.html'),
      controller: ('ViewJsonController as vm')
    });
}

export default routes;
