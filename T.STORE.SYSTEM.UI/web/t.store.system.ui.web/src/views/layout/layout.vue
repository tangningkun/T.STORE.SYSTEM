<!-- VUE -->
<template>
  <el-container class="main">
    <el-aside :class="$store.state.isCollapse ? 'main-aside-false' : 'main-aside-true'">
      <transition>
        <NavTab></NavTab>
      </transition>
    </el-aside>
    <el-container class="main-container">
      <el-header class="main-container-header">
        <el-row>
          <el-col :span="24" class="main-container-header-col-top">
            <div class="grid-content bg-purple-dark">
              <el-button
                class="main-container-header-button"
                icon="el-icon-s-operation"
                @click="controlNav"
              ></el-button>
              <NavHeader></NavHeader>
            </div>
          </el-col>
          <el-col :span="24" class="main-container-header-col-buttom"></el-col>
        </el-row>
      </el-header>
      <el-main class="main-container-main">
        <transition>
          <router-view />
        </transition>
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
