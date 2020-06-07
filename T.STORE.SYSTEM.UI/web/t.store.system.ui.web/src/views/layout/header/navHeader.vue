<!--
 * @Descripttion: 
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-02 00:06:42
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 15:20:39
-->
<template>
  <div class="header">
    <!-- 头部 -->
    <!-- 折叠按钮 -->
    <div class="collapse-btn">
      <img src="../../../assets/img/logo.png" />
      <!-- <i :class="collapse?'el-icon-s-fold':'el-icon-s-unfold'" style="width:40px"></i> -->
    </div>
    <div class="logo  fade-enter-active fade-leave-active font-14" :style="collapsed ? 'width:0px;' : 'width:152px;'">
      <span v-if="!collapsed">商店系统</span>
      <div class="logoicon" @click="collapseChage">
        <i :class="collapsed ? 'iconfont icon-indent' : 'iconfont icon-outdent'" style="width:40px"></i>
      </div>
    </div>
    <div class="header-right">
      <div class="header-user-con">
        <!-- 用户头像 -->
        <div class="user-avator"></div>
        <div class="btn-time">admin</div>
        <!-- 时间 -->
        <div class="btn-time">
          <i class="el-icon-time">
            <span>{{ currentTime }}</span>
          </i>
        </div>
        <div class="btn-time">
          <i class="el-icon-warning-outline" @click="help()">
            <span>帮助</span>
          </i>
        </div>
        <div class="btn-time">
          <i class="iconfont icon-poweroff" @click="logout()">
            <span>退出</span>
          </i>
        </div>
        <!-- 全屏显示 -->
        <div class="btn-fullscreen" @click="handleFullScreen">
          <el-tooltip effect="dark" :content="fullscreen ? `取消全屏` : `全屏`" placement="bottom">
            <i :class="fullscreen ? 'iconfont icon-fullscreen-exit' : 'iconfont icon-fullscreen'"></i>
          </el-tooltip>
        </div>
      </div>
    </div>
  </div>
</template>

<!--TypeScript -->
<script lang="ts">
import NavHeader from './navHeader.component';
export default NavHeader;
</script>

<!--scss -->
<style src="./navHeader.scss" lang="scss" scoped></style>
