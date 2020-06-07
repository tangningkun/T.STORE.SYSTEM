/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-03 22:25:13
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 00:19:08
 */

import { Vue, Component, Inject } from 'vue-property-decorator';
import bus from '@/utils/bus';
import NavTabItem from '../navTabItem/navTabItem.vue';
import { Getter } from 'vuex-class';

@Component({
  components: { NavTabItem },
})
export default class NavTab extends Vue {
  @Getter('menu') menu: any;

  private collapsed: boolean = false;
  private navtablist = [];
  private created() {
    console.log('navTab.component.created');
    // 通过 Event Bus 进行组件间通信，来折叠侧边栏
    bus.$on('collapsed', (msg: any) => {
      this.collapsed = msg;
    });
  }
}
