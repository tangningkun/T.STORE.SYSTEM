<template>
  <el-menu
    :default-active="activeIndex"
    class="el-menu-demo main-header-el-menu"
    mode="horizontal"
    @select="handleSelect"
  >
    <el-submenu index="1" class="main-header-el-menu-item">
      <template slot="title">
        Admin
        <img src="@/assets/img/avatar-1.png" />
      </template>
      <el-menu-item index="2-1">修改密码</el-menu-item>
      <el-menu-item index="2-2">个人信息</el-menu-item>
    </el-submenu>
    <el-menu-item class="main-header-el-menu-item" index="2">
      <el-badge :value="12" class="item">
        <el-button size="small" class="item-el-button">消息</el-button>
      </el-badge>
    </el-menu-item>
    <el-menu-item class="main-header-el-menu-item" index="3" @click="goLogout">
      注销
      <i class="el-icon-switch-button" />
    </el-menu-item>
  </el-menu>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  name: 'NavHeader',
})
export default class NavHeader extends Vue {
  private activeIndex: any = '1';
  private handleSelect(key: any, keyPath: any) {
    console.log(key, keyPath);
  }
  private goLogout() {
    this.$router.push({ path: '/' });
  }
}
</script>

<style lang="scss" scoped>
.main-header-el-menu {
  height: 60px;
  border-bottom: 1px solid #e0e0f3 !important;
  //box-shadow: 5px 5px 1px #f8f8ff;
  float: right;
  .main-header-el-menu-item {
    font-size: 14px !important;
    img {
      width: 30px;
      margin: 15px 15px;
      border-radius: 15px;
      border: 1px solid #dcdfe6;
    }
    .item {
      margin-top: 15px;
      margin-right: 40px;
      .item-el-button {
        border: 0px solid #dcdfe6 !important;
        font-size: 14px !important;
        margin-top: -32px;
      }
    }
    i {
      width: 24px !important;
      font-size: 24px !important;
      color: red;
      margin-top: -1px;
      margin-right: 56px;
    }
  }
}
</style>


