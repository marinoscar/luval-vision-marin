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
      loginService.logOut();
      $state.go('login');
    } else if (!targetState.public && !loginService.isAuthorized()) {
      evt.preventDefault();
      ngNotify.set('Your account is not authorized', 'info');
      loginService.logOut();
      $state.go('login');
    } else if (targetState.admin && !loginService.isAdmin()) {
      evt.preventDefault();
      ngNotify.set('Your account does not have enough permissions', 'info');
      $state.go('documents');
    }
  });

  $rootScope.$on('$destroy', deregistration);
}

/* @ngInject */
function interceptor($httpProvider) {
  $httpProvider.interceptors.push('authorizationInjectorService');
}

export {routesConfig, blockPrivateAccess, interceptor};
