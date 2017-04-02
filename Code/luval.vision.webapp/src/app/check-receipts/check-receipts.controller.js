class CheckReceiptsController {
  constructor($state) {
    this.$state = $state;
    this.imageSrc = 'https://s3.amazonaws.com/ocrreceiptsbucket/f99790bc-f253-41fd-a564-6317bdadfdee.jpeg';
  }

  backToReceipts() {
    this.$state.go('login');
  }
}

export default CheckReceiptsController;
