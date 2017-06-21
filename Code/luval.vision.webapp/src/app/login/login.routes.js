/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('login', {
      url: '/login',
      template: require('./login.html'),
      controller: ('LoginController as vm'),
      cache: false,
      public: true
    })
    .state('login-create', {
      url: '/login-create',
      template: require('./create/login-create.html'),
      controller: ('LoginCreateController as vm'),
      cache: false,
      public: true,
      params: {
        user: {
          w3: {}
        }
      }
    });
}

export default routes;
