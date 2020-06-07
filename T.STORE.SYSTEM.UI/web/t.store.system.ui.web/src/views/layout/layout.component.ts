/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 00:19:35
 */

import { Vue, Component, Inject } from 'vue-property-decorator';
import { mapGetters } from 'vuex';
import { HttpServices } from '../../http/HttpServices';
import { HttpUrlConfig } from '../../http/HttpUrlConfig';
import NavHeader from './header/navHeader.vue';
import NavTab from './navTab/navTab.vue';
import TagsView from './tagView/tagView.vue';
import bus from '@/utils/bus';

@Component({
  name: 'Layout',
  components: { NavHeader, NavTab, TagsView },
  computed: {
    ...mapGetters(['token']),
  },
})
export default class Layout extends Vue {
  @Inject()
  public httpServices!: HttpServices;
  @Inject()
  public httpUrlConfig!: HttpUrlConfig;

  public collapsed: boolean = false;
  public created() {
    console.log(this);
    console.log('layout.component.created');
  }
}
