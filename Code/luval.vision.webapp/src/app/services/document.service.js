class documentService {
  constructor() {
    this.metadata = {};
  }

  getMetadata() {
    return this.metadata;
  }

  setMetadata(metadata) {
    this.metadata = metadata;
  }

  setFileData(fileData) {
    this.fileData = fileData;
  }

  getFileData() {
    return this.fileData;
  }

  replaceSpecialCharacters(source) {
    return source.replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi, '') // eslint-disable-line
  }
}

export default documentService;
