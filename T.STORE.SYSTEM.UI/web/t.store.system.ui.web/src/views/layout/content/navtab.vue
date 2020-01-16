<template>
  <el-menu
    default-active="1-4-1"
    class="el-menu-vertical-demo main-aside-el-menu"
    :collapse="$store.state.isCollapse"
  >
    <el-menu-item index="1" @click="gotoPage('home')">
      <i class="el-icon-s-home"></i>
      <span slot="title">主页</span>
    </el-menu-item>
    <el-submenu index="2">
      <template slot="title">
        <i class="el-icon-location"></i>
        <span slot="title">PAGE-1</span>
      </template>
      <el-menu-item-group>
        <span slot="title">分组一</span>
        <el-menu-item index="2-1">选项1</el-menu-item>
        <el-menu-item index="2-2">选项2</el-menu-item>
      </el-menu-item-group>
      <el-menu-item-group title="分组2">
        <el-menu-item index="2-3">选项3</el-menu-item>
      </el-menu-item-group>
      <el-submenu index="2-4">
        <span slot="title">选项4</span>
        <el-menu-item index="1-4-1">选项1</el-menu-item>
      </el-submenu>
    </el-submenu>
    <el-menu-item index="3" @click="gotoPage('page')">
      <i class="el-icon-menu"></i>
      <span slot="title">PAGE-2</span>
    </el-menu-item>
    <el-menu-item index="4" disabled>
      <i class="el-icon-document"></i>
      <span slot="title">PAGE-3</span>
    </el-menu-item>
    <el-menu-item index="5">
      <i class="el-icon-setting"></i>
      <span slot="title">导航四</span>
    </el-menu-item>
  </el-menu>
</template>

<script lang="ts">
import { Vue, Component, Model } from 'vue-property-decorator';

@Component({
  name: 'navtab',
})
export default class NacTab extends Vue {
  private gotoPage(page: any) {
    this.$router.push({ name: page });
  }
}
</script>


<style lang="scss" scoped>
/* .main-aside-el-menu {
  border-right: solid 0px #e6e6e6 !important;
} */
</style>

