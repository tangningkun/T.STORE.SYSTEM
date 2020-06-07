<!--
 * @Descripttion: 
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-04-12 10:30:44
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 23:50:52
-->
<!-- VUE -->
<template>
  <el-container class="layout-wapper">
    <el-header class="navHeader-wapper">
      <NavHeader></NavHeader>
    </el-header>
    <el-container class="container-wapper">
      <el-aside class="container-wapper-aside">
        <NavTab></NavTab>
      </el-aside>
      <el-main class="container-main-wapper">
        <div class="container-main-wapper-header">
          <TagsView></TagsView>
        </div>
        <div class="container-main-wapper-content">
          <router-view />
        </div>
      </el-main>
    </el-container>
  </el-container>
</template>

<!--TypeScript -->
<script lang="ts">
import Layout from './layout.component';
export default Layout;
</script>

<!--scss -->
<style src="./layout.scss" lang="scss" scoped></style>
