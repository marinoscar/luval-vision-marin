import SettingsController from './settings.controller';
import settingsService from './settings.service';
import routes from './settings.routes';

export default
  angular
    .module('luval-vision.settings', [])
    .config(routes)
    .controller('SettingsController', SettingsController)
    .service('settingsService', settingsService)
    .name;
