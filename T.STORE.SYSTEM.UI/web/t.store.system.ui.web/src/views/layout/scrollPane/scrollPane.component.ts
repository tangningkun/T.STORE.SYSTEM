/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-06 02:14:36
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 11:55:09
 */

import { Vue, Component, Inject } from 'vue-property-decorator';
import { Getter } from 'vuex-class';

const padding = 15;
@Component({
  name: 'ScrollPane',
  components: { ScrollPane },
})
export default class ScrollPane extends Vue {
  private left: number = 0;
  handleScroll(e: any) {
    const eventDelta = e.wheelDelta || -e.deltaY * 3;
    const $container: any = this.$refs.scrollContainer;
    const $containerWidth = $container.offsetWidth;
    const $wrapper: any = this.$refs.scrollWrapper;
    const $wrapperWidth = $wrapper.offsetWidth;
    if (eventDelta > 0) {
      this.left = Math.min(0, this.left + eventDelta);
    } else {
      if ($containerWidth - padding < $wrapperWidth) {
        if (this.left < -($wrapperWidth - $containerWidth + padding)) {
          this.left = this.left;
        } else {
          this.left = Math.max(this.left + eventDelta, $containerWidth - $wrapperWidth - padding);
        }
      } else {
        this.left = 0;
      }
    }
  }
  moveToTarget($target: any) {
    // 容器
    let $container: any = this.$refs.scrollContainer;
    // 容器宽度
    const $containerWidth = $container.offsetWidth;
    // 标签左偏移
    const $targetLeft = $target.offsetLeft;
    // 标签可见宽度
    const $targetWidth = $target.offsetWidth;
    if ($targetLeft < -this.left) {
      // 标签在可视区域左侧
      this.left = -$targetLeft + padding;
    } else if ($targetLeft + padding > -this.left && $targetLeft + $targetWidth < -this.left + $containerWidth - padding) {
      // 标签在可视区域
      this.left = Math.min(0, $containerWidth - $targetWidth - $targetLeft - padding);
    } else {
      // 标签在可视区域右侧
      this.left = -($targetLeft - ($containerWidth - $targetWidth) + padding);
    }
  }
}
