/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-05-30 16:22:42
 */

declare module '*.vue' {
  import Vue from 'vue';
  export default Vue;
}

declare module '*.png';
declare module '*.jpg';
declare module '*.gif';

declare module 'element-ui/lib/locale/lang/*' {
  export const elementLocale: any;
}
