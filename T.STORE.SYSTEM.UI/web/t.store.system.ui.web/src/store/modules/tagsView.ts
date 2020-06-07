/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-02 00:46:07
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 16:32:09
 */
import { ActionTree, MutationTree } from 'vuex';
const state = {
  visitedViews: [],
  cachedViews: [],
};

const mutations: MutationTree<any> = {
  // 添加访问标签
  ADD_VISITED_VIEWS: (state: any, view: any) => {
    if (state.visitedViews.some((v: any) => v.path === view.path)) return;
    state.visitedViews.push(
      Object.assign({}, view, {
        title: view.meta.title || 'no-name',
      })
    );
    if (!view.meta.noCache) {
      state.cachedViews.push(view.name);
    }
  },
  // 删除访问标签
  DEL_VISITED_VIEWS: (state: any, view: any) => {
    for (let [i, v] of state.visitedViews.entries()) {
      if (v.path === view.path) {
        state.visitedViews.splice(i, 1);
        break;
      }
    }
    for (const i of state.cachedViews) {
      if (i === view.name) {
        const index = state.cachedViews.indexOf(i);
        state.cachedViews.splice(index, 1);
        break;
      }
    }
  },
  // 删除其他便签
  DEL_OTHERS_VIEWS: (state: any, view: any) => {
    for (let [i, v] of state.visitedViews.entries()) {
      if (v.path === view.path) {
        state.visitedViews = state.visitedViews.slice(i, i + 1);
        break;
      }
    }
    for (const i of state.cachedViews) {
      if (i === view.name) {
        const index = state.cachedViews.indexOf(i);
        state.cachedViews = state.cachedViews.slice(index, i + 1);
        break;
      }
    }
  },
  // 删除所有标签
  DEL_ALL_VIEWS: (state: any) => {
    state.visitedViews = [];
    state.cachedViews = [];
  },
};
const actions: ActionTree<any, any> = {
  // 添加访问标签
  addVisitedViews({ commit }, view) {
    commit('ADD_VISITED_VIEWS', view);
  },
  // 删除访问标签
  delVisitedViews({ commit, state }, view) {
    return new Promise((resolve) => {
      commit('DEL_VISITED_VIEWS', view);
      resolve([...state.visitedViews]);
    });
  },
  // 删除其他标签
  delOthersViews({ commit, state }, view) {
    return new Promise((resolve) => {
      commit('DEL_OTHERS_VIEWS', view);
      resolve([...state.visitedViews]);
    });
  },
  // 删除所有便签
  delAllViews({ commit, state }) {
    return new Promise((resolve) => {
      commit('DEL_ALL_VIEWS');
      resolve([...state.visitedViews]);
    });
  },
};

export default {
  namespaced: true, // 配合module使用
  state,
  actions,
  mutations,
};
