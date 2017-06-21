/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('admin', {
      url: '/admin',
      template: require('./admin.html'),
      controller: ('AdminController as vm'),
      cache: false
    });
}

export default routes;
