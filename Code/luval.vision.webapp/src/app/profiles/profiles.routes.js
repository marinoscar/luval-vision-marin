/* @ngInject */
function routes($stateProvider) {
  $stateProvider
    .state('profiles-show', {
      url: '/profiles-show',
      template: require('./show/profiles-show.html'),
      controller: ('ProfilesShowController as vm'),
      cache: false
    })
    .state('profiles-create', {
      url: '/profiles-create',
      template: require('./create/profiles-create.html'),
      controller: ('ProfilesCreateController as vm'),
      cache: false
    })
    .state('profiles-edit', {
      url: '/profiles-edit',
      template: require('./edit/profiles-edit.html'),
      controller: ('ProfilesEditController as vm'),
      cache: false
    });
}

export default routes;
