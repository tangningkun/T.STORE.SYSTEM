/*
 * @Descripttion: 使用mixins进行实例化类进行注入(后续待优化依赖注入)
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-05-29 23:53:32
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-03 02:02:44
 */

import { Vue, Component, Provide } from 'vue-property-decorator';
import { HttpServices } from '@/http/HttpServices';
import { HttpUrlConfig } from '@/http/HttpUrlConfig';
import { GlobalFn } from './utils/globalFn';

declare module 'vue/types/vue' {
  interface Vue {
    mixinValue: string;
  }
}
@Component
/**
 * @Author: 唐宁坤
 * @Date: 2020-05-30 01:42:14
 * @Descripttion：每次建立新类都在此处进行处理
 */
export default class Injectable extends Vue {
  /**
   * @Descripttion：一个类对应一个@Provide
   * @Author: 唐宁坤
   * @Date: 2020-05-30 01:59:22
   */
  @Provide('globalFn') globalFn = new GlobalFn();
  @Provide('httpServices') httpServices = new HttpServices();
  @Provide('httpUrlConfig') httpUrlConfig = new HttpUrlConfig();
}
