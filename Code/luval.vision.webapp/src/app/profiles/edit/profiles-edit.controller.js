class ProfilesEditController {
  /* @ngInject */
  constructor($log, $state, ngNotify, profilesService, documentService) {
    this.$log = $log;
    this.$state = $state;
    this.ngNotify = ngNotify;
    this.profilesService = profilesService;
    this.documentService = documentService;
    this.activate();
  }

  activate() {
    this.profiles = this.profilesService.getProfile();
    this.jsonEditor = {
      options: {
        mode: 'tree'
      }
    };
  }

  onChangeProfile(profile, index) {
    this.profiles.attributeMapping[index] = profile;
  }

  changeJSONView() {
    this.jsonEditor.options.mode = this.jsonEditor.options.mode === 'tree' ? 'code' : 'tree';
  }

  editProfileJSON(profile) {
    this.profilesService.updateProfile(profile)
      .then(this.profileUpdatedHandler.bind(this),
      this.profileUpdatedError.bind(this));
  }

  profileUpdatedError() {
    this.ngNotify.set('Failed Profile Update', {
      duration: 2000,
      type: 'error',
      position: 'bottom'
    });
  }

  profileUpdatedHandler() {
    this.ngNotify.set('Successfully Updated', {
      duration: 2000,
      position: 'bottom'
    });
  }

  backToShowProfiles() {
    this.$state.go('profiles-show');
  }
}

export default ProfilesEditController;
