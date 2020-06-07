/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-05 00:26:14
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-05 00:47:23
 */
/* jshint esversion:6 */

import router from '../../router/index';
import store from '../../store/index';
import { Message } from 'element-ui';
// import {NProgress} from 'nprogress';
import 'nprogress/nprogress.css'; // progress bar style

// NProgress.configure({ showSpinner: false }); // 不显示加载圆圈

// 免登陆可进入的页面
const whiteList = ['/login', '/401', '/404', '/register'];

// 动态路由前置
router.beforeEach((to: any, from: any, next) => {
  //NProgress.start();
  if (store.getters.menu.length === 0) {
    // 拉取用户信息
    store.dispatch('permission/getPermissions').then((routers) => {
      // 获取用户权限数据
      router.addRoutes(routers); // 动态添加可访问路由表
      next({ ...to, replace: true }); // hack方法 确保addRoutes已完成 ,设置replace: true，以便导航不会留下历史记录
    });
  } else {
    next();
  }
});
// 路由后置
router.afterEach(() => {
  //NProgress.done();
});
