import angular from 'angular';
import login from './app/login/login';
import documents from './app/documents/documents';
import core from './app/core/core.constants';
import checkDocuments from './app/check-documents/check-documents';
import profiles from './app/profiles/profiles';
import users from './app/users/users';
import viewJSON from './app/view-json/view-json';
import {routesConfig, blockPrivateAccess, interceptor} from './routes';
import 'angular-ui-router';
import 'angular-ui-router/release/stateEvents';
import 'angular-ui-bootstrap';
import 'angular-spinner/dist/angular-spinner.min';
import 'ng-file-upload/dist/ng-file-upload.js';
import 'ng-notify/dist/ng-notify.min';
import 'angular-base64/angular-base64';

import './index.scss';
import './app/login/login.scss';
import './app/profiles/profiles.scss';
import './app/profiles/show/profiles-show.scss';
import './app/profiles/create/profiles-create.scss';
import './app/profiles/edit/profiles-edit.scss';
import './app/documents/documents.scss';
import './app/check-documents/check-documents.scss';
import 'ng-notify/dist/ng-notify.min.css';

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
    core,
    profiles,
    documents,
    checkDocuments,
    users,
    viewJSON,
    login
  ])
  .config(routesConfig)
  .config(interceptor)
  .run(blockPrivateAccess);
