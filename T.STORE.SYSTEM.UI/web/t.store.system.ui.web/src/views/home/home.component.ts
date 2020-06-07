/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-05 16:10:47
 */

import { Vue, Component, Watch } from 'vue-property-decorator';
//import echarts, { EChartOption } from 'echarts';
/* import '../../../node_modules/echarts/dist/echarts.min.js';
declare var echarts: any;
declare var $: any; */
@Component({
  name: 'home',
})
export default class Home extends Vue {
  public screenWidth: any = document.documentElement.clientWidth; // 屏幕宽度
  public screenHeight: any = document.documentElement.clientHeight; // 屏幕高度
  public message: string = 'Home';
  public list = [
    { title: '问题数', type: 'questions', total: 11, icon: 'el-icon-question' },
    { title: '文章数', type: 'articles', total: 12, icon: 'el-icon-collection' },
    { title: '专栏数', type: 'columns', total: 14, icon: 'el-icon-s-order' },
    { title: '用户数', type: 'users', total: 55, icon: 'el-icon-s-custom' },
  ];
}
