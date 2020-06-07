<!--
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-05-18 11:15:37
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-06 01:58:49
-->

# 详细可自行了解 VUEX 的使用，注意 VUEX 在 JS 与 TS 的差别

## VUEX 外部调用时，导出函数中加入 namespaced: true, // 配合 module 使用

## dispatch：含有异步操作，例如向后台提交数据，写法：

```TS
this.$store.dispatch('mutations 方法名',值)
```

## commit：同步操作

```TS
his.$store.commit('mutations 方法名',值)
```

## getters 中赋予的值怎样页面中怎样去获取

网站示例：https://www.jianshu.com/p/08ff82cf4616

```TS

// 这里主要介绍关于页面：
import { Getter } from 'vuex-class';

export default class 类名 extends Vue {
  @Getter('menu') menu: any;
  private created() {
    console.log(this.menu);
  }
}
```

```TS
// 注：这个写法在TS中会有提示错误，不建议这样使用
import { Vue, Component, Inject } from 'vue-property-decorator';
import { mapGetters } from 'vuex';


@Component({
  computed: {
    ...mapGetters(['menu']),
  },
  components: { NavTabItem },
})
export default class 类名 extends Vue {
  @Getter('menu') menu: any;
  private created() {
    console.log(this.menu);
  }
}
```

##
