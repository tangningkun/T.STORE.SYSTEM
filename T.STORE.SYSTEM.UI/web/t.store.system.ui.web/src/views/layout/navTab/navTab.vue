<!--
 * @Descripttion: 
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-03 22:25:31
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 15:18:05
-->
<template>
  <el-menu
    :default-active="$route.path"
    :collapse="collapsed"
    :style="collapsed ? 'width:64px;' : 'width:200px;'"
    class="el-menu-vertical-demo  fade-enter-active fade-leave-active"
    mode="vertical"
    unique-opened
  >
    <NavTabItem v-for="(route, index) in menu" :key="index" :item="route"></NavTabItem>
  </el-menu>
</template>

<!--TypeScript -->
<script lang="ts">
import NavTab from './navTab.component';
export default NavTab;
</script>

<!--scss -->
<style src="./navTab.scss" lang="scss" scoped></style>
