/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-06 02:05:35
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 02:08:22
 */
import { ActionTree, MutationTree } from 'vuex';

const state = {
  logs: [],
};
const mutations: MutationTree<any> = {
  ADD_ERROR_LOG: (state: any, log: any) => {
    state.logs.push(log);
  },
};
const actions: ActionTree<any, any> = {
  addErrorLog({ commit }, log) {
    commit('ADD_ERROR_LOG', log);
  },
};

export default {
  namespaced: true,
  state,
  actions,
  mutations,
};
