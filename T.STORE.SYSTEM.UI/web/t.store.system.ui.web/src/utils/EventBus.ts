/*
 * @Descripttion:通用类的EventBus，页面间的传值等
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-07 23:23:19
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-08 00:05:18
 */
import Vue from 'vue';
import { Injectable } from '@vue-ioc/core';

@Injectable()
export class EventBus {
  public constructor() {}
  private bus: Vue = new Vue();

  /**
   * 触发传值
   * @Author: 唐宁坤
   * @Date: 2020-06-07 23:33:52
   * @Descripttion:
   */
  dispatch(name: string, data: any) {
    this.bus.$emit(name, data);
  }
  /**
   * 监控传值
   * @Author: 唐宁坤
   * @Date: 2020-06-07 23:34:08
   * @Descripttion:
   */
  addListener(name: string, listener: (data: any) => void) {
    this.bus.$on(name, listener);
  }
  /**
   * 关闭传值
   * @Author: 唐宁坤
   * @Date: 2020-06-07 23:34:20
   * @Descripttion:
   */
  removeListener(name: string, listener: (data: any) => void) {
    this.bus.$off(name, listener);
  }
}
