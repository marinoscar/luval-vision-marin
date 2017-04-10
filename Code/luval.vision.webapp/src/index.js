import angular from 'angular';
import login from './app/login/login';
import documents from './app/documents/documents';
import core from './app/core/core.constants';
import checkDocuments from './app/check-documents/check-documents';
import 'angular-ui-router';
import 'angular-ui-bootstrap';
import routesConfig from './routes';
import 'ng-notify/dist/ng-notify.min';

import './index.scss';
import './app/login/login.scss';
import './app/documents/documents.scss';
import './app/check-documents/check-documents.scss';
import 'ng-notify/dist/ng-notify.min.css';

angular
  .module('luval-vision', [
    'ui.router',
    'ui.bootstrap',
    'google-signin',
    'ngNotify',
    core,
    documents,
    checkDocuments,
    login
  ])
  .config(routesConfig)
  .run(initialiazeConfig);

/* @ngInject */
function initialiazeConfig(ngNotify) {
  const notifyConfig = {
    theme: 'pure',
    position: 'bottom',
    duration: 3000,
    type: 'info',
    sticky: false,
    button: true,
    html: false
  };
  ngNotify.config(notifyConfig); // eslint-disable-line angular/module-getter
}
