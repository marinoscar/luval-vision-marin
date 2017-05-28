import ProfilesCreateController from './create/profiles-create.controller';
import ProfilesShowController from './show/profiles-show.controller';
import ProfilesEditController from './edit/profiles-edit.controller';
import profilesService from './profiles.service';
import routes from './profiles.routes';

import 'angular-jsoneditor/dist/angular-jsoneditor';

export default
  angular
    .module('luval-vision.profiles', ['angular-jsoneditor'])
    .config(routes)
    .controller('ProfilesCreateController', ProfilesCreateController)
    .controller('ProfilesShowController', ProfilesShowController)
    .controller('ProfilesEditController', ProfilesEditController)
    .service('profilesService', profilesService)
    .name;
