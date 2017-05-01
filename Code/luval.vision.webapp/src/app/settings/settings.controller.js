class SettingsController {
  /* @ngInject */
  constructor($log, $state, ngNotify, settingsService, documentService) {
    this.$log = $log;
    this.$state = $state;
    this.ngNotify = ngNotify;
    this.settingsService = settingsService;
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
      this.settingsService.uploadAttributeMappingConfig(this.documentService.objectBlobStorage(this.$files, this.profileName))
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
    this.settingsService.getDefaultSettings()
      .then(this.settingsLoadHandler.bind(this), this.settingsLoadRejected.bind(this));
  }

  settingsLoadRejected() {
    this.$log.error('Error');
  }

  settingsLoadHandler(settings) {
    this.jsonSrc = settings.data;
    this.ngNotify.set('Successful Loaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  configFileUploadedHandler(fileConfig) {
    this.jsonSrc = fileConfig.data;
    this.profileName = '';
    this.ngNotify.set('Successful Uploaded', {
      duration: 2000,
      position: 'bottom'
    });
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default SettingsController;
