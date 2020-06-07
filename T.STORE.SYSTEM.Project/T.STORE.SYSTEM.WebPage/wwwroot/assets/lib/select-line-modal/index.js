define(['main', 'text!lib/select-line-modal/index.html', 'lay!layer', 'lay!laytpl', 'lay!form'], function(main, modalView) {
  var layer = layui.layer;
  var laytpl = layui.laytpl;
  var form = layui.form;

  var modal = {
    index: 0,
    roads: null,
    callback: null,
    init: function(options) {
      modal.roads = options.roads;
      modal.callback = options.callback;

      modal.initForm();
    },
    initForm: function() {
      form.on('submit', function(data) {
        if (data.field.line) {
          modal.callback && modal.callback({ id: data.field.line });
          layer.close(modal.index);
        }
        return false;
      });
    },
    open: function() {
      modal.index = layer.open({
        type: 1,
        title: '选择线路',
        area: '400px',
        content: laytpl(modalView).render({ roads: modal.roads || [] })
      });
      form.render(null, 'form-select-line');
      $('#layui-layer' + modal.index)
        .find('.layui-layer-content')
        .css('overflow', 'visible');
    }
  };
  return {
    open: function(options) {
      modal.init(options);
      modal.open();
    }
  };
});
