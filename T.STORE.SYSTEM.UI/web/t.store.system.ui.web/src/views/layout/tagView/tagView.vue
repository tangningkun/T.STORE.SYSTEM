<!--
 * @Descripttion: 
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-05 16:58:43
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 02:24:31
-->
<template>
  <div class="tags-view-container" @contextmenu.prevent="openMenu('', $event)">
    <scroll-pane ref="scrollPane" class="tags-view-wrapper">
      <router-link
        v-for="tag in Array.from(visitedViews)"
        ref="tag"
        :key="tag.path"
        class="tags-view-item"
        :class="isActive(tag) ? 'active' : ''"
        :style="isActive(tag)"
        :to="tag"
        @contextmenu.prevent.native.stop="openMenu(tag, $event)"
      >
        {{ tag.title }}
        <span v-if="visitedViews.length > 1" class="el-icon-close" @click.prevent.stop="closeSelectedTag(tag)" />
      </router-link>
    </scroll-pane>
    <ul v-show="visible" class="contextmenu" :style="{ left: left + 'px', top: top + 'px' }">
      <li v-if="selectedTag && visitedViews.length > 1" @click="closeSelectedTag(selectedTag)">关闭</li>
      <li v-if="selectedTag" @click="closeOthersTags">关闭其他</li>
      <li @click="closeAllTags">关闭所有</li>
    </ul>
  </div>
</template>

<!--TypeScript -->
<script lang="ts">
import TagView from './tagView.component';
export default TagView;
</script>

<!--scss -->
<style src="./tagView.scss" lang="scss" scoped></style>
