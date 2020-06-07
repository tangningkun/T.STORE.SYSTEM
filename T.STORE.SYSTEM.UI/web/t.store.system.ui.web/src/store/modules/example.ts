/*
 * @Descripttion: 空VUEX示例
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-06 02:09:46
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 02:10:28
 */
import { ActionTree, MutationTree } from 'vuex';

const state = {
  logs: [],
};
const mutations: MutationTree<any> = {};
const actions: ActionTree<any, any> = {};

export default {
  namespaced: true,
  state,
  actions,
  mutations,
};
