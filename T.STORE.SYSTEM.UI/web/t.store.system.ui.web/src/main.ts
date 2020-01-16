import Vue from 'vue';
import App from './App.vue';
import router from '../src/router/index';
import store from '../src/store/index';
import * as ElementUI from 'element-ui';
import 'babel-polyfill'; // 编译ES6API
import * as echarts from 'echarts';

Vue.config.productionTip = false;
Vue.use(ElementUI);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
