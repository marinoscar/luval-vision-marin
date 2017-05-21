class ProfilesCreateController {
  /* @ngInject */
  constructor($log, $state, ngNotify, profilesService, documentService) {
    this.$log = $log;
    this.$state = $state;
    this.ngNotify = ngNotify;
    this.profilesService = profilesService;
    this.documentService = documentService;
    this.disable = true;
    this.loadDefaultSettings();
  }

  loadFile($files) {
    this.disable = false;
    this.$files = $files;
  }

  uploadSettingsFile() {
    if (!this.disable) { // eslint-disable-line
      this.profilesService.uploadAttributeMappingConfig(this.documentService.objectBlobStorage(this.$files, this.profileName))
        .then(this.configFileUploadedHandler.bind(this));
    } else {
      this.ngNotify.set('Please Upload a Settings File!', {
        type: 'error',
        duration: 2000,
        position: 'bottom'
      });
    }
  }

  loadDefaultSettings() {
    this.profilesService.getDefaultSettings()
      .then(this.settingsLoadHandler.bind(this), this.settingsLoadRejected.bind(this));
  }

  settingsLoadRejected() {
    this.$log.error('Error');
  }

  settingsLoadHandler(settings) {
    this.jsonSrc = settings.data;
    this.ngNotify.set('Successfully Loaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  configFileUploadedHandler(fileConfig) {
    this.jsonSrc = fileConfig.data;
    this.profileName = '';
    this.ngNotify.set('Successfully Uploaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  backToShowProfiles() {
    this.$state.go('profiles-show');
  }
}

export default ProfilesCreateController;
