/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('user-create', {
      url: '/user-create',
      template: require('./create/user-create.html'),
      controller: ('UserCreateController as vm'),
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
