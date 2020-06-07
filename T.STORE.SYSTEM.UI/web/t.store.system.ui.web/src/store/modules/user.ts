/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-05-18 11:21:08
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 02:00:28
 */

import { GlobalFn } from '../../utils/globalFn';
import { ActionTree, MutationTree } from 'vuex';
import { Inject } from 'vue-property-decorator';

/**
 * @author tangningkun
 * 实例化GlobalFn类
 */
let globalFn: any = new GlobalFn();

const state = {
  token: globalFn.getSessionStore('token'),
};

const mutations: MutationTree<any> = {
  SET_TOKEN(state: any, data: any): void {
    state.token = data;
  },
};

const actions: ActionTree<any, any> = {
  setToken({ commit, state }, data: any) {
    return new Promise((resolve, reject) => {
      commit('SET_TOKEN', data);
      // 将数据存到session缓存与cookie缓存
      globalFn.setSessionStore('token', data);
      globalFn.setCookie('token', data);
      // console.log(_getCookie('Token'));
      resolve();
    });
  },
  /**
   * 深拷贝
   * @param param0
   * @param params
   */
  async deep({ state, commit }, params: any) {
    let obj = {};
    obj = JSON.parse(JSON.stringify(params));
    return obj;
  },

  loginOut({ state, commit, dispatch }) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        sessionStorage.clear();
        resolve();
      }, 500);
      setTimeout('location.reload();', 1000); // 延迟1s刷新页面
      /**
       * 将缓存信息清空
       */
      sessionStorage.clear();
      commit('SET_TOKEN', '');
      resolve();
    });
  },
};
export default {
  namespaced: true, // 配合module使用
  actions,
  mutations,
  state,
};
