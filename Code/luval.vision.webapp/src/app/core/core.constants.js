export const TESTING_PATH = 'http://localhost:55993/api/v1/';
export const APP_PATH = 'https://celeris-api-dev.azurewebsites.net/api/v1/';

export default
  angular
    .module('luval-vision.core', [])
    .constant('CORE', {
      URL: TESTING_PATH
    })
		.name;
