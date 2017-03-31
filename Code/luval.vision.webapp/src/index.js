import angular from 'angular';
import login from './app/login/login';
import receipts from './app/receipts/receipts';
import 'angular-ui-router';
import routesConfig from './routes';

import './index.scss';
import './app/login/login.scss';

angular
  .module('luval-vision', [
    'ui.router',
    'google-signin',
    receipts,
    login
  ])
  .config(routesConfig);
