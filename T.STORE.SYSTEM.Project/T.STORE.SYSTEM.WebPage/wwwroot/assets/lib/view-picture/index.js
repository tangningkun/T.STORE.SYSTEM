define(['main', 'text!lib/view-picture/index.html', 'lay!carousel', 'lay!form', 'lay!laytpl', 'lay!layer'], function(main, view) {
  var carousel = layui.carousel;
  var form = layui.form;
  var laytpl = layui.laytpl;
  var layer = layui.layer;

  var module = {
    index: null,
    open: function(options) {
      module.index = layer.open({
        type: 1,
        title: '',
        area: ['auto', 'auto'],
        shadeClose: true,
        closeBtn: 0,
        content: laytpl(view).render(options)
      });

      var viewer = carousel.render({
        elem: '.layui-carousel',
        width: '1000px',
        height: '600px',
        autoplay: false,
        arrow: 'always',
        indicator: 'none'
      });

      var loadPictures = function(type) {
        abp.services.app.file
          .getPictures({
            lineType: type || options.lineType,
            lineId: options.lineId,
            roadId: options.roadId
          })
          .then(function(result) {
            var div = $('div[carousel-item]');
            div.html('');
            result.forEach(function(d) {
              div.append($('<div>').append($('<img>').attr('src', '\\' + d.picture.origin)));
            });
            if (result.length == 0) {
              div.append($('<div>').append('暂无图片'));
            }
            viewer.reload({ index: 0 });
          });
      };
      if (options.isGroup) {
        form.render();
        form.on('radio', function(data) {
          loadPictures(data.value);
        });
        loadPictures(1);
      } else {
        loadPictures();
      }
    }
  };

  return {
    open: module.open
  };
});
