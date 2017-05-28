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

  showProfileJSON(profile) {
    this.profilesService.setProfile(profile);
    this.$state.go('profiles-edit');
  }

  gotDefaultSettingsError() {
    this.loading = false;
  }

  gotDefaultSettingsHandler(settings) {
    this.settings = settings;
    if (this.settings.data.Id === null) {
      this.settings = undefined;
    }
    this.loading = false;
  }

  createProfile() {
    this.$state.go('profiles-create');
  }

  deleteProfile(profile) {
    this.profilesService.deleteProfile(profile)
      .then(this.profileDeletedHandler.bind(this));
  }

  profileDeletedHandler() {
    this.profilesService.getDefaultSettings()
      .then(this.gotDefaultSettingsHandler.bind(this),
      this.gotDefaultSettingsError.bind(this));
  }

  backToDocuments() {
    this.$state.go('documents');
  }
}

export default ProfilesShowController;
