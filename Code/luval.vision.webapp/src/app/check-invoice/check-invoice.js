import CheckInvoicesController from './check-invoice.controller';
import checkInvoicesService from './check-invoice.service';
import documentService from '../services/document.service';
import routes from './check-invoice.routes';
import interact from 'interactjs/dist/interact';

export default
  angular
    .module('luval-vision.check-invoice', [])
    .config(routes)
    .config(interactiveConfig)
    .controller('CheckInvoicesController', CheckInvoicesController)
    .service('checkInvoicesService', checkInvoicesService)
    .service('documentService', documentService)
    .name;

/* ngInject */
function interactiveConfig() {
  // TODO: use canvas-viewer // eslint-disable-line no-warning-comments
  interact('#document-container')
    .draggable({
      inertia: true,
      restrict: {
        restriction: 'parent',
        endOnly: true,
        elementRect: {top: 0, left: 0, bottom: 1, right: 1}
      },
      autoScroll: true,
      onmove: dragMoveListener,
      onend: function (event) { // eslint-disable-line object-shorthand
        const textEl = event.target.querySelector('p');

        textEl && (textEl.textContent = // eslint-disable-line no-unused-expressions
          'moved a distance of ' + (Math.sqrt(event.dx * event.dx + event.dy * event.dy) | 0) + 'px'); // eslint-disable-line no-mixed-operators
      }
    });

    function dragMoveListener(event) { // eslint-disable-line indent
      const target = event.target;
      const x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx;
      const y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

      target.style.webkitTransform =
      target.style.transform =
        'translate(' + x + 'px, ' + y + 'px)';

      target.setAttribute('data-x', x);
      target.setAttribute('data-y', y);
    }
  window.dragMoveListener = dragMoveListener; // eslint-disable-line angular/window-service
}