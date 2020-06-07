<!--
 * @Descripttion: 
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-03 22:35:30
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-05 00:43:01
-->
<template>
  <transition>
    <template v-if="hasOneShowingChildren(item, item.children) && (!item.children[0].children || item.children[0].children.length === 0)">
      <router-link :to="resolvePath(item)">
        <el-menu-item :index="resolvePath(item)">
          <i v-if="item.children[0].meta && item.children[0].meta.icon" :class="'icon iconfont ' + item.children[0].meta.icon" />
          <span v-if="item.children[0].meta && item.children[0].meta.title" slot="title">{{ item.children[0].meta.title }}</span>
        </el-menu-item>
      </router-link>
    </template>
    <!-- 多级菜单的子项 -->
    <template v-else-if="!item.children.length">
      <router-link :to="item.path">
        <el-menu-item :index="item.path">
          <i v-if="item.meta && item.meta.icon" :class="'icon iconfont ' + item.meta.icon" />
          <span v-if="item.meta && item.meta.title" slot="title">{{ item.meta.title }}</span>
        </el-menu-item>
      </router-link>
    </template>
    <!-- 在这里循环多级菜单 -->
    <el-submenu v-else ref="subMenu" popper-append-to-body :index="item.path">
      <template slot="title">
        <i v-if="item.meta && item.meta.icon" :class="'icon iconfont ' + item.meta.icon" />
        <span v-if="item.meta && item.meta.title" slot="title">{{ item.meta.title }}</span>
      </template>
      <NavTabItem v-for="child in item.children" :key="child.path" :item="child" />
    </el-submenu>
  </transition>
</template>

<!--TypeScript -->
<script lang="ts">
import NavTabItem from './navTabItem.component';
export default NavTabItem;
</script>

<!--scss -->
<style src="./navTabItem.scss" lang="scss" scoped></style>
