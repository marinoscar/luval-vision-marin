import CheckReceiptsController from './check-receipts.controller';
import checkReceiptsService from './check-receipts.service';
import routes from './check-receipts.routes';
import interact from 'interactjs/dist/interact';

export default
  angular
    .module('luval-vision.check-receipts', [])
    .config(routes)
    .config(interactiveConfig)
    .controller('CheckReceiptsController', CheckReceiptsController)
    .service('checkReceiptsService', checkReceiptsService)
    .name;

/* ngInject */
function interactiveConfig() {
  interact('#receipt-image')
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
