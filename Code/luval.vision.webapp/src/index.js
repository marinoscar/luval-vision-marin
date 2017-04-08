import angular from 'angular';
import login from './app/login/login';
import invoices from './app/invoices/invoices';
import core from './app/core/core.constants';
import checkInvoices from './app/check-invoice/check-invoice';
import 'angular-ui-router';
import 'angular-ui-bootstrap';
import routesConfig from './routes';

import './index.scss';
import './app/login/login.scss';
import './app/invoices/invoices.scss';
import './app/check-invoice/check-invoice.scss';

angular
  .module('luval-vision', [
    'ui.router',
    'ui.bootstrap',
    'google-signin',
    core,
    invoices,
    checkInvoices,
    login
  ])
  .config(routesConfig);
