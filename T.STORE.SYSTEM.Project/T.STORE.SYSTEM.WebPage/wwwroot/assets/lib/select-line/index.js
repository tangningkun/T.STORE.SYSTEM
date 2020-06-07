define(['main', 'text!lib/select-line/index.html', 'lib/select-line-modal/index', 'lib/compare-line-modal/index', 'lay!table', 'lay!laytpl'], function(
  main,
  view,
  selectModal,
  compareModal
) {
  var laytpl = layui.laytpl;

  var module = {
    roads: [],
    init: function(options) {
      options = $.extend(
        {
          container: null,
          type: 0,
          line: null
        },
        options
      );

      var container = $(options.container);
      container.html(view);

      var roads = [];
      var actions = [
        abp.services.app.road.getConstructionLines,
        abp.services.app.road.getManagementLines,
        abp.services.app.road.getConservationLines,
        abp.services.app.road.getOperationLines
      ];
      var services = [abp.services.app.roadConstruction, abp.services.app.roadManagement, abp.services.app.roadConservation, abp.services.app.roadOperation];
      actions[options.type]({ id: g_road.Id }).then(function(result) {
        roads = result;
      });

      var trView = container.find('#trTpl')[0].innerHTML;
      var tbody = container.find('#line-table tbody');
      var openCompare = function(road, lineObject) {
        compareModal.open({
          road: road,
          line: lineObject,
          getDictionary: services[options.type].getDictionarys,
          callback: function(data) {
            var tr = $(laytpl(trView).render(data.new));
            var index = module.roads.findIndex(function(d) {
              return d.new.id == data.new.id;
            });
            if (index >= 0) {
              module.roads[index] = data;
            } else {
              module.roads.push(data);
              tr.find('#btn-edit-line').on('click', function(e) {
                e.preventDefault();
              });

              tr.find('#btn-delete-line').on('click', function(e) {
                e.preventDefault();
                module.roads.splice(tr.index(), 1);
                tr.remove();
              });

              tbody.append(tr);
            }
          }
        });
      };

      container.find('#btn-select-line').click(function(e) {
        e.preventDefault();
        selectModal.open({
          roads: roads,
          callback: function(data) {
            services[options.type].get({ id: data.id }).then(function(result) {
              result.objects = result.objects.map(function(d) {
                if (d.data) {
                  $.extend(d, JSON.parse(d.data));
                  delete d.data;
                }
                return d;
              });
              openCompare(result, options.line);
            });
          }
        });
      });
    }
  };
  return module;
});
