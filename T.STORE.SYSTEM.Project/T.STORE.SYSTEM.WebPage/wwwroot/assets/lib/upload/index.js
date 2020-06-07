define(['main', 'text!lib/upload/index.html', 'lay!upload', 'lay!laytpl'], function(main, view) {
  var upload = layui.upload;
  var laytpl = layui.laytpl;

  var fileList = {};
  return {
    init: function(options) {
      var body = options.body ? $(options.body) : $('body');
      body.find(options.container).append(view);
      var trView = body.find('#trTpl')[0].innerHTML;

      options = Object.assign(
        {
          elem: '#btn-upload-list',
          url: '/upload/image',
          accept: 'images',
          acceptMime: 'image/*',
          multiple: true,
          auto: false,
          bindAction: '#btn-upload-start',
          choose: function(obj) {
            var files = (this.files = obj.pushFile());
            obj.preview(function(index, file, result) {
              var tr = $(
                laytpl(trView).render({
                  index: index,
                  file: file
                })
              );

              tr.find('.btn-upload-reload').on('click', function(e) {
                e.preventDefault();
                obj.upload(index, file);
              });

              tr.find('.btn-upload-delete').on('click', function(e) {
                e.preventDefault();
                delete files[index];
                delete fileList[index];
                tr.remove();
                uploadList.config.elem.next()[0].value = '';
              });

              listView.append(tr);
            });
          },
          done: function(res, index, upload) {
            if (res.success) {
              //上传成功
              var tr = listView.find('tr#upload-' + index);
              var tds = tr.children();
              tds.eq(2).html('<span style="color: #5FB878;">上传成功</span>');
              tds
                .eq(3)
                .find('.btn-upload-reload')
                .addClass('layui-hide'); //显示重传
              fileList[index] = res.result[0];
              return delete this.files[index]; //删除文件队列已经上传成功的文件
            }
            this.error(index, upload);
          },
          error: function(index, upload) {
            var tr = listView.find('tr#upload-' + index);
            var tds = tr.children();
            tds.eq(2).html('<span style="color: #FF5722;">上传失败</span>');
            tds
              .eq(3)
              .find('.btn-upload-reload')
              .removeClass('layui-hide'); //显示重传
          }
        },
        options
      );

      var listView = body.find('#table-upload-list');

      var uploadList = upload.render(options);
    },
    getFiles: function() {
      var list = [];
      for (var key in fileList) {
        list.push(fileList[key]);
      }
      return list;
    }
  };
});
