/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 21:58:36
 */
/** VUE */
import Vue from 'vue';
/** 路由 */
import router from '@/router/index';
/** vuex */
import store from '@/store/index';
/** 编译ES6API */
import 'babel-polyfill';
/** 前端框架 */
import ElementUI from 'element-ui';
/** xml数据处理插件 */
import x2js from 'x2js';

import App from './App.vue';
/* css */
import 'normalize.css';
import '@/styles/element-variables.scss';
import '@/styles/index.scss'; // 自定义样式
import './utils/config/permission';

import { VueIocPlugin } from '@vue-ioc/core';

Vue.use(VueIocPlugin);

Vue.use(ElementUI);

Vue.config.productionTip = false;
/** 全局方法挂载 */
Vue.prototype.$x2js = new x2js();

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
