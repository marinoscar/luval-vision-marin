import angular from 'angular';
import login from './app/login/login';
import documents from './app/documents/documents';
import core from './app/core/core.constants';
import checkDocuments from './app/check-documents/check-documents';
import 'angular-ui-router';
import 'angular-ui-router/release/stateEvents';
import 'angular-ui-bootstrap';
import {routesConfig, blockPrivateAccess} from './routes';
import 'ng-notify/dist/ng-notify.min';

import './index.scss';
import './app/login/login.scss';
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
    core,
    documents,
    checkDocuments,
    login
  ])
  .config(routesConfig)
  .run(blockPrivateAccess);
