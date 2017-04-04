import angular from 'angular';
import login from './app/login/login';
import receipts from './app/receipts/receipts';
import core from './app/core/core.constants';
import checkReceipts from './app/check-receipts/check-receipts';
import 'angular-ui-router';
import routesConfig from './routes';

import './index.scss';
import './app/login/login.scss';
import './app/check-receipts/check-receipts.scss';

angular
  .module('luval-vision', [
    'ui.router',
    'google-signin',
    core,
    receipts,
    checkReceipts,
    login
  ])
  .config(routesConfig);
