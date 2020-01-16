import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const route = [
  {
    path: '/',
    redirect: '/home'
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
          title: '主页'
        }
      }
    ]
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: route
});

export default router;
