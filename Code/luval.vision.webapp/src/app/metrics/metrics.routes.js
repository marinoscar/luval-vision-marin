/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('metrics', {
      url: '/metrics',
      template: require('./metrics.html'),
      controller: ('MetricsController as vm'),
      cache: false
    });
}

export default routes;
