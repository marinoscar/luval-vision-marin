export const TESTING_PATH = 'http://localhost:55993/api/v1/';

export default
  angular
    .module('luval-vision.core', [])
    .constant('CORE', {
      URL: TESTING_PATH
    })
		.name;
