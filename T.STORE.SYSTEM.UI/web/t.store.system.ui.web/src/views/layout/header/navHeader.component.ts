/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-02 00:06:49
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 23:07:03
 */

import { Vue, Component } from 'vue-property-decorator';
import bus from '@/utils/bus';
import dayjs from 'dayjs';
import { HttpServices } from '@/http/HttpServices';
import { Inject } from '@vue-ioc/core';
import { RouteService } from '@/services/RouteService';
@Component({
  name: 'NavHeader',
})
export default class NavHeader extends Vue {
  @Inject()
  private routeService!: RouteService;

  private collapsed: boolean = false;
  private fullscreen: boolean = false;
  private timer: any;
  private currentTime: any = dayjs(new Date()).format('YYYY-MM-DD HH:mm:ss');

  private created() {
    console.log(this);
    console.log('header.component.created');
  }
  private mounted() {
    console.log('header.component.mounted');
    let _this = this; // 声明一个变量指向Vue实例this，保证作用域一致
    _this.timer = setInterval(() => {
      _this.currentTime = dayjs(new Date()).format('YYYY-MM-DD HH:mm:ss');
    });
  }
  private beforeDestroy() {
    if (this.timer) {
      clearInterval(this.timer); // 在Vue实例销毁前，清除我们的定时器
    }
  }
  private collapseChage() {
    console.log('header.component.collapseChage');
    this.collapsed = !this.collapsed;
    bus.$emit('collapsed', this.collapsed);
    // this.$emit('refresh');刷新
  }
  /**
   * @Author: 唐宁坤
   * @Date: 2020-06-03 00:05:20
   * @Descripttion: 全屏事件
   */
  private handleFullScreen() {
    let element: any = document.documentElement;
    let doc: any = document;
    if (this.fullscreen) {
      if (doc.exitFullscreen) {
        doc.exitFullscreen();
      } else if (doc.webkitCancelFullScreen) {
        doc.webkitCancelFullScreen();
      } else if (doc.mozCancelFullScreen) {
        doc.mozCancelFullScreen();
      } else if (doc.msExitFullscreen) {
        doc.msExitFullscreen();
      }
    } else {
      if (element.requestFullscreen) {
        element.requestFullscreen();
      } else if (element.webkitRequestFullScreen) {
        element.webkitRequestFullScreen();
      } else if (element.mozRequestFullScreen) {
        element.mozRequestFullScreen();
      } else if (element.msRequestFullscreen) {
        // IE11
        element.msRequestFullscreen();
      }
    }
    this.fullscreen = !this.fullscreen;
  }
  private help() {
    this.routeService
      .GetRouteData1()
      .then((res) => {
        console.log(res);
      })
      .catch((err) => {
        console.log(err);
      });
  }
  private logout() {
    console.log('Log out of the system!!!');
  }
}
