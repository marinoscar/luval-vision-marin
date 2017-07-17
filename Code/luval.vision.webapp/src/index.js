import angular from 'angular';
import core from './app/core/core.constants';
import login from './app/login/login';
import admin from './app/admin/admin';
import users from './app/users/users';
import documents from './app/documents/documents';
import checkDocuments from './app/check-documents/check-documents';
import profiles from './app/profiles/profiles';
import viewJSON from './app/view-json/view-json';
import metrics from './app/metrics/metrics';
import {routesConfig, blockPrivateAccess, interceptor} from './routes';
import 'angular-ui-router';
import 'angular-ui-router/release/stateEvents';
import 'angular-ui-bootstrap';
import 'angular-spinner/dist/angular-spinner.min';
import 'ng-file-upload/dist/ng-file-upload.js';
import 'ng-notify/dist/ng-notify.min';
import 'angular-base64/angular-base64';
import 'angular-ui-switch/angular-ui-switch.min';

import './index.scss';
import './app/login/login.scss';
import './app/admin/admin.scss';
import './app/profiles/profiles.scss';
import './app/profiles/show/profiles-show.scss';
import './app/profiles/create/profiles-create.scss';
import './app/profiles/edit/profiles-edit.scss';
import './app/documents/documents.scss';
import './app/check-documents/check-documents.scss';
import './app/metrics/metrics.scss';
import 'ng-notify/dist/ng-notify.min.css';
import 'angular-ui-switch/angular-ui-switch.min.css';

angular
  .module('luval-vision', [
    'ui.router',
    'ui.router.state.events',
    'ui.bootstrap',
    'google-signin',
    'ngNotify',
    'base64',
    'ngFileUpload',
    'angularSpinner',
    'uiSwitch',
    core,
    login,
    profiles,
    documents,
    checkDocuments,
    users,
    viewJSON,
    admin,
    login,
    metrics
  ])
  .config(routesConfig)
  .config(interceptor)
  .run(blockPrivateAccess);
