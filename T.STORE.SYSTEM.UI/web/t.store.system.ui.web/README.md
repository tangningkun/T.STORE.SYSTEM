# demo 示例建立

## 根目录 cd t.store.system.ui.web

## WEB 运行 npm run serve

## 打包 npm run build

## 网址实例

###1.https://lyh.red/admin/#/login;
###2.https://juejin.im/post/5b55c118f265da0f6f1aa354;
###3.https://juejin.im/post/5d0de4f7f265da1ba84a9985;
###4.https://github.com/2017coding/BBS_admin;

### 页面间传值

例如：this.$router.push({ name: 'register', params: { username: 'admin' } });======》this.$route.params.username

### 钩子函数（生命周期函数）

beforeCreate() {
/**beforeCreate:实例刚在内存中被创建出来，此时，还没有初始化好 data 和 methods 属性 \*/
console.log('beforeCreate');
}
created() {
/**created: 实例已经在内存中创建 OK，此时 data 和 methods 已经创建 OK，此时还没有开始 编译模板*/
console.log('created');
}
beforeMount() {
/\*\*beforeMount:此时已经完成了模板的编译，但是还没有挂载到页面中 */
console.log('beforeMount');
}
mounted() {
/**mounted：此时，已经将编译好的模板，挂载到了页面指定的容器中显示 \*/
console.log('mounted');
}
beforeUpdate() {
/**beforeUpdate：状态更新之前执行此函数， 此时 data 中的状态值是最新的，但是界面上显示的 数据还是旧的，因为此时还没有开始重新渲染 DOM 节点 _/
console.log('beforeUpdate');
}
updated() {
/\*\*updated：实例更新完毕之后调用此函数，此时 data 中的状态值 和 界面上显示的数据，都已经完成了更新，界面已经被重新渲染好了！ _/
console.log('updated');
}
beforeDestroy() {
/**beforeDestroy：实例销毁之前调用。在这一步，实例仍然完全可用。 \*/
console.log('beforeDestroy');
}
destroyed() {
/**destroyed：Vue 实例销毁后调用。调用后，Vue 实例指示的所有东西都会解绑定，所有的事件监听器会被移除，所有的子实例也会被销毁。 \*/
console.log('destroyed');
}
