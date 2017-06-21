/* @ngInject */
function routesConfig($stateProvider, $urlRouterProvider, $locationProvider) {
  $locationProvider.html5Mode(false);
  $urlRouterProvider.otherwise('/documents');
}

/* @ngInject */
function blockPrivateAccess($rootScope, $state, $log, ngNotify, loginService, sessionService, GAuth, GData) {
  const deregistration = $rootScope.$on('$stateChangeStart', (evt, targetState) => {
    if (!targetState.public && !GData.isLogin()) {
      evt.preventDefault();
      loginService.checkAuth()
        .then(user => loggedInHandler(user, targetState, $log, $state),
        res => notLoggedInHandler(res, $log, $state));
    }
  });

  $rootScope.$on('$destroy', deregistration);

  const CLIENT = '387533728662-ovqlpu27rait2m5idsa6aadqf7qa00e4.apps.googleusercontent.com';

  GAuth.setClient(CLIENT);
  GAuth.setScope('https://www.googleapis.com/auth/userinfo.email');

  GAuth.load();
}

function loggedInHandler(user, targetState, log, $state) {
  log.debug(user);
  $state.go(targetState.name);
}

function notLoggedInHandler(res, log, $state) {
  log.debug(res);
  $state.go('login');
}

export {routesConfig, blockPrivateAccess};
