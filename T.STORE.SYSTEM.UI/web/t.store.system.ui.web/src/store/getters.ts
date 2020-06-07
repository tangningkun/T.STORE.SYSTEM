import { GetterTree } from 'vuex';
const getters: GetterTree<any, any> = {
  /* tokenstate: any): any {
    return state.user.token;
  } */
  // 用户模块
  token: (state) => state.user.token,
  userInfo: (state) => state.user.userInfo,
  // app模块
  size: (state) => state.app.size,
  language: (state) => state.app.language,
  theme: (state) => state.app.theme,
  sidebar: (state) => state.app.sidebar,
  fullScreen: (state) => state.app.fullScreen,
  // tags模块
  visitedViews: (state) => state.tagsView.visitedViews,
  cachedViews: (state) => state.tagsView.cachedViews,
  // 权限模块
  menu: (state) => state.permission.menu,
  dataPerms: (state) => state.permission.dataPerms,
  // 错误日志模块
  errorLogs: (state) => state.errorLog.logs,
};
export default getters;
