/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-06 02:01:12
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 02:03:40
 */

import { GlobalFn } from '../../utils/globalFn';
import { ActionTree, MutationTree } from 'vuex';
import { Inject } from 'vue-property-decorator';

/**
 * @author tangningkun
 * 实例化GlobalFn类
 */
let globalFn: any = new GlobalFn();

/* localStorage */
const state = {
  // 菜单状态
  sidebar: {
    opened: globalFn.getSessionStore('sidebarStatus') ? globalFn.getSessionStore('sidebarStatus') : true,
  },
  // 全屏状态
  fullScreen: false,
};
const mutations: MutationTree<any> = {
  // 切换侧边菜单显示状态
  TOGGLE_SIDEBAR: (state: any, status: any) => {
    state.sidebar.opened = !state.sidebar.opened;
    if (state.sidebar.opened) {
      globalFn.setSessionStore('sidebarStatus', true);
    } else {
      globalFn.setSessionStore('sidebarStatus', false);
    }
  },
  TOGGLE_FULLSCREEN: (state, val) => {
    state.fullScreen = val;
  },
};
const actions: ActionTree<any, any> = {
  // 切换侧边菜单
  toggleSideBar({ commit, state }, status) {
    commit('TOGGLE_SIDEBAR', status);
  },
};

export default {
  namespaced: true, // 配合module使用
  state,
  actions,
  mutations,
};
