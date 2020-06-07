/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-05-17 14:11:58
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-02 01:14:32
 */
import axios, { AxiosResponse, AxiosRequestConfig } from 'axios';
import qs from 'qs';
import store from '@/store/index';
import { GlobalFn } from '@/utils/globalFn';
import { Message, MessageBox } from 'element-ui';

let globalFn = new GlobalFn();
/**
 * 创建axios实例
 */
const service = axios.create({
  // baseURL: 'https://www.apiopen.top', // api的base_url
  // timeout: 3000 // 请求超时时间,
  withCredentials: false, // 允许使用cookie传值给服务器，并要求服务器指定源和Access-Control-Allow-Credentials: true
});
// service.defaults.withCredentials = true;
service.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
// service.defaults.headers.common['authorization'] = _getSessionStore('token');

// 请求拦截器
service.interceptors.request.use(
  (config) => {
    // 设置请求头
    // const token = store.getters.token;
    // token && (config.headers.Authorization = globalFn.getSessionStore('token'));

    // 对全局参数做过滤，把不存在的参数删除

    if (config.method === 'post') {
      config.data = qs.parse(config.data);
    } else if (config.method === 'get') {
      for (const key in config.params) {
        if (!config.params[key] && config.params[key] !== 0) {
          delete config.params[key];
        }
      }
    }
    globalFn.dataTrim(config.data);
    return config;
  },
  (error) => {
    // Do something with request error
    Promise.reject(error);
  }
);

// respone interceptor
service.interceptors.response.use(
  /**
   * 下面的注释为通过在response里，自定义code来标示请求状态
   * 当code返回如下情况则说明权限有问题，登出并返回到登录页
   * 如想通过xmlhttprequest来状态码标识 逻辑可写在下面error中
   * 以下代码均为样例，请结合自生需求加以修改，若不需要，则可删除
   */
  (response) => {
    const res = response.data;
    if (res.code === -1 || res.code === -2) {
      let tips = '用户登录超时,请重新登录!';
      let btMsg = '确定';
      MessageBox.alert(tips, {
        confirmButtonText: btMsg,
        type: 'info',
      })
        .then(() => {
          store.dispatch('user/loginOut').then(() => {
            location.reload(); // 为了重新实例化vue-router对象 避免bug
          });
        })
        .catch(() => {});
      return Promise.reject('error');
    } else {
      const data = response.data;
      return data;
    }
  },
  (error) => {
    console.log(error); // for debug
    const message = error.response ? globalFn.requestError(error.response.status) : '请求超时';
    Message({
      showClose: true,
      message: message,
      type: 'error',
      duration: 3 * 1000,
    });
    return Promise.reject(error);
  }
);

export default service;
