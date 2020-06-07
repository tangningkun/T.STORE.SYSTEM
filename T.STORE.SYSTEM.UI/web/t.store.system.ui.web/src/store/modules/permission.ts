import { ActionTree, MutationTree } from 'vuex';
// import { getPermissionsApi } from '@/api/user';
// 布局组件
import Layout from '@/views/layout/layout.vue';
import { GlobalFn } from '../../utils/globalFn';
import { HttpServices } from '@/http/HttpServices';
import { HttpUrlConfig } from '@/http/HttpUrlConfig';

/**
 * @author tangningkun
 * 实例化GlobalFn类
 */
let globalFn: any = new GlobalFn();
let httpServices = new HttpServices();
let httpUrlConfig = new HttpUrlConfig();

// 添加默认页面
function addPage(arr: any) {
  // 首页
  const home = {
    id: 2,
    pid: 1,
    path: '',
    component: Layout,
    redirect: '/',
    meta: { title: '首页', code: 'home', icon: 'iconfont icon-home' },
    children: [
      {
        path: '/',
        component: () => import('../../views/home/home.vue'),
        name: 'home',
        meta: { title: '首页', code: 'home', icon: 'iconfont icon-home' },
        children: [],
      },
    ],
  };
  /**
   * unshift() 方法可向数组的开头添加一个或更多元素，并返回新的长度
   */
  arr.unshift(home);
  return arr;
}

/**
 * 得到页面路径
 * @param arr
 * @param child
 * @param code
 */
function getPath(arr: any, child: any, code: any) {
  const pItem = arr.find((item: any) => child.pid === item.id);
  // 当前元素还存在父节点, 且父节点不为根节点
  if (arr.find((item: any) => pItem.pid === item.id && item.pid > -1)) {
    getPath(arr, pItem, `${pItem.code}/${code}`);
  } else {
    return `${pItem.code}/${code}`;
  }
}

const mutations: MutationTree<any> = {
  SET_MENU(state: any, menu: any): void {
    state.menu = menu;
  },
  SET_BASEMENU(state: any, baseMenu: any): void {
    state.baseMenu = baseMenu;
  },
};
const actions: ActionTree<any, any> = {
  // 获取用户权限数据
  getPermissions({ commit, state }) {
    return new Promise((resolve, reject) => {
      httpServices.httpGetNoAuth(httpUrlConfig.getRouteUrl()).then((res: any) => {
        if (res.success) {
          const menu = res.content.mod.filter((item: any) => item.pid > -1);
          // const dataPerms = res.content.dataPerms.map((item: any) => item.code);
          let baseMenu = [];
          let treeMenu = [];
          // 将菜单数据处理成可挂载的路由数据
          baseMenu = menu.map((item: any, index: any) => {
            // 对基础数据的处理
            item.meta = {};
            item.meta.title = item.name;
            item.meta.code = item.code;
            item.meta.icon = item.icon;
            item.meta.id = item.id;
            // 使路由名字具有唯一性
            item.name = item.name + index;
            // 设置对应的页面路径
            item.path = '/' + item.code;
            // 设置页面对应的组件 对应组件: -1. 根节点 1. 页面组件 2.默认布局 3456...扩展布局
            switch (item.component) {
              case -1:
                console.log('根节点，已经过滤掉了');
                break;
              case 1:
                item.component = (resolve: any) => require([`@/views/${getPath(menu, item, item.code)}/${item.code}`], resolve);
                break;
              case 2:
                item.component = Layout;
                break;
              // default:
              //   item.component = (resolve: any) => require(['@/views/errorPage/401'], resolve);
              //   break;
            }
            return {
              id: item.id,
              pid: item.pid,
              path: item.path,
              component: item.component,
              name: item.name,
              meta: item.meta,
              sort: item.sort,
            };
          });
          // 数据排序
          baseMenu = baseMenu.sort((a: any, b: any) => a.sort - b.sort);
          // 得到树状数组
          treeMenu = globalFn.getTreeArr({ key: 'id', pKey: 'pid', data: baseMenu, jsonData: false });
          // 得到静态目录
          treeMenu = addPage(treeMenu);
          // 添加不需要权限也能访问的页面
          commit('SET_MENU', treeMenu);
          commit('SET_BASEMENU', baseMenu);
          // commit('SET_DATAPERMS', dataPerms);
          resolve(treeMenu);
        } else {
          // 得到静态目录
          const treeMenu = addPage([]);
          commit('SET_MENU', treeMenu, treeMenu);
          reject();
        }
      });
    });
  },
};

export default {
  namespaced: true, // 配合module使用
  state: {
    menu: [],
    baseMenu: [],
    dataPerms: [],
  },
  actions,
  mutations,
};
