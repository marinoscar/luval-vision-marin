/* @ngInject */
function routesConfig($stateProvider, $urlRouterProvider, $locationProvider) {
  $locationProvider.html5Mode(false);
  $urlRouterProvider.otherwise('/documents');
}

/* @ngInject */
function blockPrivateAccess($rootScope, $state, $log, ngNotify, loginService) {
  const deregistration = $rootScope.$on('$stateChangeStart', (evt, targetState) => {
    if (!targetState.public && !loginService.isLoggedIn()) {
      evt.preventDefault();
      ngNotify.set('Please Sign In with Google', 'info');
      $state.go('login');
    }
  });

  $rootScope.$on('$destroy', deregistration);
}

/* @ngInject */
function interceptor($httpProvider) {
  $httpProvider.interceptors.push('authorizationInjectorService');
}

export {routesConfig, blockPrivateAccess, interceptor};
