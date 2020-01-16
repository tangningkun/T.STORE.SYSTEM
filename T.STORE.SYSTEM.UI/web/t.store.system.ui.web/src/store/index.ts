import Vue from 'vue';
import Vuex from 'vuex';
import state from './state';
import getters from './getters';

Vue.use(Vuex);

const store = new Vuex.Store({
  state,
  getters
});

export default store;

/* state: {
    isCollapse: false
  } */
