/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('settings', {
      url: '/settings',
      template: require('./settings.html'),
      controller: ('SettingsController as vm'),
      cache: false
    });
}

export default routes;
