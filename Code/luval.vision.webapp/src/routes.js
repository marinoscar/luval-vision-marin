/* @ngInject */
function routesConfig($stateProvider, $urlRouterProvider, $locationProvider) {
  $locationProvider.html5Mode(false);
  $urlRouterProvider.otherwise('/login');
}

/* @ngInject */
function blockPrivateAccess($rootScope, $state, $log, ngNotify, loginService) {
  const deregistration = $rootScope.$on('$stateChangeStart', (evt, targetState) => {
    if (!targetState.public && !loginService.isLoggedIn()) {
      evt.preventDefault();
      ngNotify.set('Please use Google Sign In again.', 'info');
      $state.go('login');
    }
  });

  $rootScope.$on('$destroy', deregistration);
}

export {routesConfig, blockPrivateAccess};
