class profilesService {
  /* @ngInject */
  constructor($log, $http, sessionService, Upload, CORE) {
    this.profile = {};
    this.$log = $log;
    this.$http = $http;
    this.CORE = CORE;
    this.upload = Upload;
    this.sessionService = sessionService;
  }

  updateProfile(profile) {
    const putRequest = {
      method: 'PUT',
      url: this.CORE.URL + 'Settings/Put',
      data: profile
    };
    return this.$http(putRequest);
  }

  uploadAttributeMappingConfig(blob) {
    const upload = this.upload.upload({
      url: this.CORE.URL + 'Settings',
      method: 'POST',
      data: blob,
      file: blob.file
    });
    return upload;
  }

  deleteProfile(profileName) {
    const deleteRequest = {
      method: 'DELETE',
      url: this.CORE.URL + 'Settings/Delete',
      params: {profile: profileName}
    };
    return this.$http(deleteRequest);
  }

  getDefaultSettings() {
    const getRequest = {
      method: 'GET',
      url: this.CORE.URL + 'Settings/GetProfiles',
      params: this.sessionService.buildUserJSON()
    };
    return this.$http(getRequest);
  }

  setProfile(profile) {
    this.profile = profile;
  }

  getProfile() {
    return this.profile;
  }
}

export default profilesService;
