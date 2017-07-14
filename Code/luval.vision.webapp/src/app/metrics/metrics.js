import MetricsController from './metrics.controller';
import MetricsService from './metrics.service';
import sessionService from '../services/session.service';
import routes from './metrics.routes';

import 'angular-google-chart/ng-google-chart.min';

export default
  angular
    .module('luval-vision.metrics', ['googlechart'])
    .config(routes)
    .controller('MetricsController', MetricsController)
    .service('MetricsService', MetricsService)
    .service('sessionService', sessionService)
    .name;
