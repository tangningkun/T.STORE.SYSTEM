<!--
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 23:42:44
-->

# 项目文档

## 项目配置文档

```
1.node.js安装(网址:http://nodejs.cn/)
2.jdk安装已经环境变量配置
2.vue-cli全局安装(cmd命令下执行：npm install -g @vue/cli)
```

## 路径详解

├─ node_modules/ # npm 执行命令引用的包
├─ public/ # 模板文件
├─ dist/ # build(发布) 生成的生产环境下的项目
├─ src/ # 源码目录（开发都在这里进行）
│ ├─ assets/ # 静态资源文件
│ ├─ components/ # 组件
│ ├─ filters/ # 全局过滤器
│ ├─ icons/ # svg 转 ts 格式的 icon,图标
│ ├─ lang/ # 国际化语言
│ ├─ layout/ # 架构布局
│ ├─ router/ # 路由（ROUTE）
│ ├─ services / # services 接口管理）
│ ├─ store/ # 模块化状态管理 vuex
│ ├─ styles/ # 公共样式
│ ├─ utils/ # 工具库
│ ├─ views/ # 视图页（pages）
│ ├─ App.vue # 启动文件
│ ├─ main.ts # 主入口页
│ ├─ permission.ts # 路由鉴权
│ ├─ Injectable #使用 mixins 进行实例化类进行注入(可看作依赖注入,后续待优化依赖注入)
│ ├─ shims-tsx.d.ts # 相关 tsx 模块注入
│ ├─ shims-vue.d.ts # Vue 模块注入
│ ├─ .env.development # 开发环境默认 API 属性配置
│ ├─ .env.production # 线上环境默认 API 属性配置
│ ├─ babel.config.js # babel 配置

## demo 示例建立(CMD 命令)

根目录： cd t.store.system.ui.web

WEB 运行 ：npm run serve

打包 ：npm run build

## 网址实例

1.https://lyh.red/admin/#/login; 2.https://juejin.im/post/5b55c118f265da0f6f1aa354; 3.https://juejin.im/post/5d0de4f7f265da1ba84a9985; 4.https://github.com/2017coding/BBS_admin;

## 页面间传值

例如：this.$router.push({ name: 'register', params: { username: 'admin' } });======》this.$route.params.username

## 钩子函数（生命周期函数）

```TS
beforeCreate() {
  /**beforeCreate:实例刚在内存中被创建出来，此时，还没有初始化好 data 和 methods 属性 \*/
  console.log('beforeCreate');
}
created() {
  /**created: 实例已经在内存中创建 OK，此时 data 和 methods 已经创建 OK，此时还没有开始 编译模板*/
  console.log('created');
}
beforeMount() {
  /**beforeMount:此时已经完成了模板的编译，但是还没有挂载到页面中 */
  console.log('beforeMount');
}
mounted() {
  /**mounted：此时，已经将编译好的模板，挂载到了页面指定的容器中显示 */
  console.log('mounted');
}
beforeUpdate() {
  /**beforeUpdate：状态更新之前执行此函数， 此时 data 中的状态值是最新的，但是界面上显示的 数据还是旧的，因为此时还没有开始重新渲染 DOM 节点 */
  console.log('beforeUpdate');
}
updated() {
  /**updated：实例更新完毕之后调用此函数，此时 data 中的状态值 和 界面上显示的数据，都已经完成了更新，界面已经被重新渲染好了！*/
  console.log('updated');
}
beforeDestroy() {
  /**beforeDestroy：实例销毁之前调用。在这一步，实例仍然完全可用。 \*/
  console.log('beforeDestroy');
}
destroyed() {
  /**destroyed：Vue 实例销毁后调用。调用后，Vue 实例指示的所有东西都会解绑定，所有的事件监听器会被移除，所有的子实例也会被销毁。*/
  console.log('destroyed');
}
```

```ts
public screenWidth: any = document.documentElement.clientWidth; // 屏幕宽度
public screenHeight: any = document.documentElement.clientHeight; // 屏幕高度
```

## 使用注释详解

文件头部注释：快捷键：crtl+alt+i（window）,ctrl+cmd+t (mac)

函数注释：快捷键：ctrl+alt+t (window), ctrl+alt+t(mac)

## 关于时间的处理

全局使用 dayjs 轻量级插件，不允许自己定义时间格式.以免造成代码冗余

## 使用 vue 的 ref 获取 DOM

```TS
//这样使用页面不会报错($ref主指获取DOM)
let tags: any = this.$refs.tag;
```

## vue 依赖注入

```TS
1. 网址：https://github.com/vue-ioc/vue-ioc
2. 使用方式：
    (1) 每次定义TS(不继承VUE类或接口)的外部类,都需要在APP.component.ts的下注入:例如：
    import { Module } from '@vue-ioc/core';
    import { HttpServices } from './http/HttpServices';
    import { RouteService } from './services/RouteService';
    import { HttpUrlConfig } from './http/HttpUrlConfig';
    import { EventBus } from './utils/EventBus';

    @Module({
      providers: [HttpServices, RouteService, HttpUrlConfig, EventBus],
    })
3. 具体使用请参考网址示例。
```
