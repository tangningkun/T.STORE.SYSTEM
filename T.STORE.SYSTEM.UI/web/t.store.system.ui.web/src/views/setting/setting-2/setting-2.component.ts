/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 15:18:32
 */

import { Vue, Component, Watch } from 'vue-property-decorator';
//import echarts, { EChartOption } from 'echarts';
/* import '../../../node_modules/echarts/dist/echarts.min.js';
declare var echarts: any;
declare var $: any; */
@Component({
  name: 'Setting2',
})
export default class Setting2 extends Vue {
  private create() {
    console.log('setting.omponent.create');
  }
}
