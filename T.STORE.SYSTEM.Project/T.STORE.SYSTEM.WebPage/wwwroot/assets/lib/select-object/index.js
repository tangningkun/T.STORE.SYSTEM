define(['main', 'text!lib/select-object/index.html', 'lay!laytpl', 'lay!form'], function(main, view) {
  var laytpl = layui.laytpl;
  var form = layui.form;

  return {
    init: function(options) {
      options = $.extend(
        {
          container: null,
          name: null,
          data: [],
          category: 0,
          lists: [],
          fields: [
            {
              type: 'string | number',
              name: 'name',
              title: 'title'
            }
          ],
          tag: function(item) {}
        },
        options,
        {
          data: JSON.parse(JSON.stringify(options.data || []))
        }
      );
      options.getText = function(item) {
        var text;
        if (typeof options.tag === 'string') {
          text = item[options.tag];
        } else if (typeof options.tag === 'function') {
          text = options.tag(item);
        } else {
          text = item.name;
        }
        return text;
      };

      var body = options.body ? $(options.body) : $('body');
      var container = body.find(options.container);
      container.html(laytpl(view).render(options));
      if (options.lists.length) {
        form.render('select');
      }

      var list = container.find('.object-tag-list');

      var getItem = function() {
        var item = {};
        for (var i = 0; i < options.lists.length; i++) {
          var list = options.lists[i];
          var index = container.find('#select-' + list.name)[0].selectedIndex;
          if (index < 0) {
            container.find('#select-' + list.name).addClass('layui-form-danger');
            return;
          }
          item[list.name] = list.items[index];
        }
        for (var i = 0; i < options.fields.length; i++) {
          var field = options.fields[i];
          var value = container
            .find('#input-' + field.name)
            .val()
            .trim();

          // check value
          if (!value || (field.type == 'number' && isNaN(+value))) {
            container
              .find('#input-' + field.name)
              .addClass('layui-form-danger')
              .focus();
            return;
          }

          item[field.name] = field.type == 'number' ? +value : value;
        }

        item.category = options.category;
        if (window.g_road) {
          item.roadId = window.g_road.Id;
        }

        return item;
      };
      var clearInput = function() {
        container.find('.input-field').each(function(i, e) {
          $(e)
            .val('')
            .removeClass('layui-form-danger');
        });
      };

      container.find('#btn-add-' + options.name).click(function(e) {
        e.preventDefault();
        var item = getItem();
        if (item) {
          list.append(
            $('<span>')
              .addClass('layui-badge-rim')
              .text(options.getText(item))
              .append('<i class="layui-icon">&#x1006;</i>')
          );
          clearInput();
          options.data.push(item);
        }
      });

      list.click(function(e) {
        if (e.target.nodeName == 'I') {
          var index = $(e.target.parentElement).index();
          options.data.splice(index, 1);
          e.target.parentElement.remove();
        }
      });

      return {
        getItems: function() {
          if (typeof options.parse == 'function') {
            return JSON.parse(
              JSON.stringify(
                options.data.map(function(d) {
                  return options.parse(d);
                })
              )
            );
          }
          return JSON.parse(JSON.stringify(options.data));
        }
      };
    }
  };
});
