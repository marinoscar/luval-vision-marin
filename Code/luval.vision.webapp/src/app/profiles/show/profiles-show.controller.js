class ProfilesShowController {
  /* @ngInject */
  constructor($log, $state, profilesService) {
    this.$log = $log;
    this.$state = $state;
    this.profilesService = profilesService;
    this.loading = true;
    this.activate();
  }

  activate() {
    this.profilesService.getDefaultSettings()
      .then(this.gotDefaultSettingsHandler.bind(this),
      this.gotDefaultSettingsError.bind(this));
  }

  gotDefaultSettingsError() {
    this.loading = false;
  }

  gotDefaultSettingsHandler(settings) {
    this.settings = settings;
    this.$log.info(settings);
    this.loading = false;
  }

  createProfile() {
    this.$state.go('profiles-create');
  }

  deleteProfile(profile) {
    this.profilesService.deleteProfile(profile)
      .then(this.profileDeletedHandler.bind(this));
  }

  profileDeletedHandler(status) {
    this.$log.info(status);
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default ProfilesShowController;
