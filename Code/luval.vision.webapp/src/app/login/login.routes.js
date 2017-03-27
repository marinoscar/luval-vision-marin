/** @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('login', {
      url: '/',
      template: require('./login.html'),
      controller: ('LoginController as vm')
    });
}

export default routes;