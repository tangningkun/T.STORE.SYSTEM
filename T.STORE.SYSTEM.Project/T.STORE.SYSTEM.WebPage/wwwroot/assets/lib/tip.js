define([], function() {
  var defaultOptions = {
    element: null,
    container: 'body',
    jDom: null,
    data: [],
    render: function(d) {
      return d;
    },
    onSelect: function(text) {},
    events: {}
  };

  function InputTip(options) {
    this.options = {};
    $.extend(this.options, defaultOptions, options);

    this.init();
  }

  InputTip.prototype.init = function() {
    var options = this.options;
    options.jDom = $(this.options.element);
    if (!options.element || !options.jDom || options.jDom.length == 0) {
      throw new Error('err_empty_element');
    }

    options.id = 'tip_' + Date.now().toString() + '_' + Math.floor(Math.random() * 1e6);

    // event
    initEvents(this);
  };

  var initEvents = function(instance) {
    var options = instance.options;
    var events = {};

    for (var key in events) {
      events[key].clear && events[key].clear();
    }

    events.show = {
      event: function(e) {
        instance.showList(e);
      },
      bind: function() {
        options.jDom.bind('click', events.show.event);
      }
    };

    events.hide = {
      event: function(e) {
        if (options.jDom != null && e.target !== options.jDom[0]) {
          var ele = $(e.target);
          var isSelect = false;
          while (ele.length > 0) {
            if (ele[0].id == 'list_' + options.id) {
              isSelect = true;
              break;
            }
            ele = ele.parent();
          }
          isSelect = isSelect && e.target.nodeName == 'LI';
          instance.hideList(e);
          if (isSelect) {
            options.onSelect($(e.target).text(), instance);
          }
        }
      },
      bind: function() {
        $(options.container).bind('click', events.hide.event);
      }
    };

    options.events = events;
    for (var key in events) {
      events[key].bind();
    }
  };

  InputTip.prototype.reload = function() {};

  InputTip.prototype.showList = function(e) {
    var options = this.options;
    if (options.listDom) {
      return;
    }
    var position = options.jDom.offset();
    var height = options.jDom.height();
    options.listDom = $('<div>')
      .addClass('input-tip-list')
      .attr('id', 'list_' + options.id)
      .css({
        top: position.top + height + 10,
        left: position.left
      })
      .append(
        $('<ul>').append(
          options.data.map(function(d) {
            var text = options.render(d);
            return $('<li>')
              .attr('title', text)
              .text(text);
          })
        )
      );

    $(options.container).append(options.listDom);
  };

  InputTip.prototype.hideList = function(e) {
    var options = this.options;
    if (options.listDom != null) {
      options.listDom.remove();
      options.listDom = null;
    }
  };

  InputTip.prototype.destroy = function() {
    var options = this.options;
    var events = options.events;
    var container = $(options.container);

    container.unbind('click', events.show.event);
    container.unbind('click', events.hide.event);
  };

  return InputTip;
});
