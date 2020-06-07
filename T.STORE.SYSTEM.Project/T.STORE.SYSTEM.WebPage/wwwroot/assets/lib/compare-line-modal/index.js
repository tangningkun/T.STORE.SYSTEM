define(['main', 'text!lib/compare-line-modal/index.html', 'lay!layer', 'lay!laytpl', 'lay!form'], function(main, modalView) {
  var layer = layui.layer;
  var laytpl = layui.laytpl;
  var form = layui.form;

  var modal = {
    index: 0,
    roads: null,
    callback: null,
    line: null,
    data: {},
    cover: false,
    getDictionary: null,
    init: function(options) {
      modal.road = options.road;
      modal.callback = options.callback;
      modal.line = options.line;
      modal.getDictionary = options.getDictionary;

      modal.initForm();
    },
    initForm: function() {
      form.on('submit(save-compare)', function(data) {
        modal.data.cover = data.field.cover == 'true';
        $('.old-line button[lay-submit]').click();
        $('.new-line button[lay-submit]').click();
        return false;
      });
    },
    open: function() {
      modal.index = layer.open({
        type: 1,
        title: '比较线路',
        area: ['100%', '100%'],
        content: laytpl(modalView).render({})
      });

      modal.getDictionary().then(function(result) {
        var dictionarys = {};
        result.forEach(function(d) {
          dictionarys[d.name] = d.items.map(function(item) {
            return {
              id: item.id,
              name: item.name
            };
          });
        });
        modal.line.init({ container: '.old-line', mode: 'history', type: 'old', data: modal.road, submit: modal.collectData, dictionarys: dictionarys });
        modal.line.init({ container: '.new-line', mode: 'history', type: 'new', data: modal.road, submit: modal.collectData, dictionarys: dictionarys });
      });
    },
    collectData: function(data, type) {
      if (type == 'new') {
        modal.data.new = data;
      } else {
        modal.data.old = data;
      }

      if (modal.data.new && modal.data.old) {
        layer.close(modal.index);
        modal.callback && modal.callback(modal.data);
        modal.data = {};
      }
    }
  };
  return {
    open: function(options) {
      modal.init(options);
      modal.open();
    }
  };
});
