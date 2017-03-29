import angular from 'angular';

import receipts from './app/receipts/receipts';
import 'angular-ui-router';
import routesConfig from './routes';

import './index.scss';

angular
  .module('luval-vision', [
    'ui.router',
    receipts
  ])
  .config(routesConfig);
