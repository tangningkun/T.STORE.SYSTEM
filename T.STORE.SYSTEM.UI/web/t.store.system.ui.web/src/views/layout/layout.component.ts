import { Vue, Component, Model } from 'vue-property-decorator';
import NavHeader from './content/navheader.vue';
import NavTab from './content/navtab.vue';

@Component({
  name: 'home',
  components: { NavHeader, NavTab }
})
export default class Layout extends Vue {
  private created() {
    // console.log(this.$store.state.isCollapse);
  }
  private handleOpen(key: any, keyPath: any) {
    console.log(key, keyPath);
  }
  private handleClose(key: any, keyPath: any) {
    console.log(key, keyPath);
  }
  private controlNav() {
    this.$store.state.isCollapse = this.$store.state.isCollapse ? false : true;
  }
}
