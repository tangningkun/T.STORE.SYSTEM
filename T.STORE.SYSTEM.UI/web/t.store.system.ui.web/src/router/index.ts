/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 16:35:58
 */

import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const route = [
  {
    path: '/',
    redirect: '/home',
  },
  {
    path: '/layout',
    name: 'layout',
    component: () => import('@/views/layout/layout.vue'),
    children: [
      {
        path: '/home',
        name: 'home',
        component: () => import('@/views/home/home.vue'),
        meta: {
          title: '主页',
        },
      },
    ],
  },
];

const router = new VueRouter({
  // mode: 'history',
  base: process.env.BASE_URL,
  routes: route,
});

export default router;
