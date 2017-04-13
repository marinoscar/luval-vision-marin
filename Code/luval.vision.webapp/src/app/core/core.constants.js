export const TESTING_PATH = 'http://localhost:55993/api/v1/';
export const APP_PATH = 'http://www.celeris.somee.com/api/v1/';

export default
  angular
    .module('luval-vision.core', [])
    .constant('CORE', {
      URL: APP_PATH
    })
		.name;
