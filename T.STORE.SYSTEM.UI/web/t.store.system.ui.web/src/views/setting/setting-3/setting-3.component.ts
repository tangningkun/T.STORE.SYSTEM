/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 16:15:36
 */

import { Vue, Component, Watch } from 'vue-property-decorator';

@Component({
  name: 'Setting3',
})
export default class Setting3 extends Vue {
  private create() {
    console.log('setting.omponent.create');
  }
}
