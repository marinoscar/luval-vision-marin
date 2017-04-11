/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('login', {
      url: '/login',
      template: require('./login.html'),
      controller: ('LoginController as vm'),
      cache: false,
      public: true
    });
}

export default routes;
