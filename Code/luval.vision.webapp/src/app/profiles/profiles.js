import ProfilesCreateController from './create/profiles-create.controller';
import ProfilesShowController from './show/profiles-show.controller';
import profilesService from './profiles.service';
import routes from './profiles.routes';

export default
  angular
    .module('luval-vision.profiles', [])
    .config(routes)
    .controller('ProfilesCreateController', ProfilesCreateController)
    .controller('ProfilesShowController', ProfilesShowController)
    .service('profilesService', profilesService)
    .name;
