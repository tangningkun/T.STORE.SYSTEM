/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-05 16:58:14
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 16:01:53
 */

import { Vue, Component, Inject, Watch } from 'vue-property-decorator';
import ScrollPane from '../scrollPane/scrollPane.vue';
import baseScss from '../../../styles/bass.scss';
import { Getter } from 'vuex-class';
import { mapGetters } from 'vuex';

@Component({
  name: 'TagView',
  components: { ScrollPane },
  computed: {
    ...mapGetters(['sidebar']),
    visitedViews() {
      return this.$store.state.tagsView.visitedViews;
      // 设置只保留8个菜单
      // return this.$store.state.tagsView.visitedViews.slice(-8)
    },
  },
})
export default class TagView extends Vue {
  @Getter('sidebar') sidebar: any;
  /**
   * 变量的定义
   */
  private visible: boolean = false;
  private top: number = 0;
  private left: number = 0;
  private selectedTag: any = {};
  private baseScss: any;

  public mounted() {
    this.addViewTags();
  }

  public generateRoute() {
    if (this.$route.name) {
      return this.$route;
    }
    return false;
  }
  // 返回当前访问路由的样式
  public isActive(tag: any) {
    if (tag.path === this.$route.path) {
      return 'background-color: ' + baseScss.theme + '; color: #fff;border-color: ' + baseScss.theme + ';';
    }
    return false;
  }

  @Watch('$route')
  public addViewTags() {
    const route = this.generateRoute();
    // route || route.path === '/index' || route.path === '/home/index'
    if (!route || route.path === '/retrieve') {
      return false;
    }
    this.$store.dispatch('tagsView/addVisitedViews', route);
  }
  @Watch('$route')
  public moveToCurrentTag() {
    let tags: any = this.$refs.tag;
    let scrollPanes: any = this.$refs.scrollPane;
    console.log(tags);
    this.$nextTick(() => {
      for (let tag of tags) {
        if (tag.to.path === this.$route.path) {
          if (!tag.$el) break;
          scrollPanes.moveToTarget(tag.$el);
          break;
        }
      }
    });
  }
  /**
   * 监控控制关闭小按钮界面
   * @param value{true|打开，false|关闭}
   */
  @Watch('visible')
  public monitorVisible(value: boolean) {
    if (value) {
      document.body.addEventListener('click', this.closeMenu);
    } else {
      document.body.removeEventListener('click', this.closeMenu);
    }
  }
  public closeSelectedTag(view: any) {
    // 关掉选中的tag后，将最后一个tag变成选择
    this.$store.dispatch('tagsView/delVisitedViews', view).then((views) => {
      if (this.isActive(view)) {
        const latestView = views.slice(-1)[0];
        if (latestView) {
          this.$router.push(latestView);
        } else {
          // 关闭所有路由后进入的页面;
          this.$router.push('/');
        }
      }
    });
  }
  /**关闭其他标签
   * @Author: 唐宁坤
   * @Date: 2020-06-06 10:08:54
   * @Descripttion:
   */
  public closeOthersTags() {
    this.$router.push(this.selectedTag);
    this.$store.dispatch('tagsView/delOthersViews', this.selectedTag).then(() => {
      this.moveToCurrentTag();
    });
  }
  /**关闭所有标签
   * @Author: 唐宁坤
   * @Date: 2020-06-06 10:09:14
   * @Descripttion:
   */
  public closeAllTags() {
    this.$store.dispatch('tagsView/delAllViews');
    // 关闭所有路由后进入的页面
    this.$router.push('/');
  }
  public openMenu(tag: any, e: any) {
    this.visible = true;
    this.selectedTag = tag;
    // 不同布局下的位置
    if (!this.sidebar.opened) {
      this.left = e.clientX - 60;
    } else {
      this.left = e.clientX - 220;
    }
    this.top = 40;
  }
  public closeMenu() {
    this.visible = false;
  }
}
