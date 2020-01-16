<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script lang="ts">
import { Component, Vue, Model } from 'vue-property-decorator';

@Component({})
export default class App extends Vue {
  private loading: boolean = false;
  public computed() {
    // computed
  }
  public watch() {
    // watch
  }
  public methods() {
    // methods
  }
}
</script>
<style lang="scss">
#app {
  height: 100%; // 继承父级高度
  font-size: 14px;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>
