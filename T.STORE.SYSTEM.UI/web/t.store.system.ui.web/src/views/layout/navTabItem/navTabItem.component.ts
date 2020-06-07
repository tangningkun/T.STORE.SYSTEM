/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-03 22:35:57
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-03 22:39:00
 */
import { Vue, Component, Inject } from 'vue-property-decorator';
import { mapGetters } from 'vuex';
@Component({
  name: 'NavTabItem',
  props: {
    // route object
    item: {
      type: Object,
      required: true,
    },
  },
})
export default class NavTabItem extends Vue {
  private resolvePath(item: any) {
    let path = item.path ? item.path + '/' + item.children[0].path : item.children[0].path;
    // let path = item.redirect;
    return path;
  }
  private hasOneShowingChildren(item: any, children: any) {
    // 判断路由是否显示
    const showingChildren = children.filter((item: any) => {
      return !item.hidden;
    });
    // 设置当只有一个子目录的时候并且名字和父级一样时，菜单不展开
    if (showingChildren.length === 1 && showingChildren[0].meta.title === item.meta.title) {
      return true;
    }
    return false;
  }
}
