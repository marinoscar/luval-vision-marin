class SettingsController {
  /* @ngInject */
  constructor($log, $state, ngNotify, settingsService, documentService) {
    this.$log = $log;
    this.$state = $state;
    this.ngNotify = ngNotify;
    this.settingsService = settingsService;
    this.documentService = documentService;
    this.loadDefaultSettings();
  }

  uploadSettingsFile($files) {
    this.settingsService.uploadAttributeMappingConfig(this.documentService.objectBlobStorage($files))
      .then(this.configFileUploadedHandler.bind(this));
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
