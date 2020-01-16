<template>
  <div class="app-container">
    <el-row :gutter="40" class="panel-group">
      <el-col
        v-for="(item, index) in list"
        :key="index"
        :xs="12"
        :sm="12"
        :lg="6"
        class="card-panel-col"
      >
        <div class="card-panel" @click="handleSetLineChartData('newVisitis')">
          <div :class="'card-panel-icon-wrapper icon-' + item.type">
            <i :class="'el-icon ' + item.icon" />
          </div>
          <div class="card-panel-description">
            <div class="card-panel-text">{{ item.title }}</div>
            <span>{{item.total}}</span>
          </div>
        </div>
      </el-col>
    </el-row>
    <div class="charts" ref="echarts"></div>
  </div>
</template>
<script lang="ts">
import Home from './home.component';
export default Home;
</script>

<style src="./home.scss" lang="scss" scoped></style>

 