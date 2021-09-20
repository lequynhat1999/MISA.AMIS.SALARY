import Vue from 'vue'
import App from './App.vue'
import axios from 'axios';
import VueAxios from 'vue-axios';
import 'devextreme/dist/css/dx.light.css';
import { ValidationProvider, ValidationObserver, extend } from 'vee-validate'; 
import * as rules from 'vee-validate/dist/rules';
import { messages } from 'vee-validate/dist/locale/vi.json';
import money from 'v-money';
import Paginate from 'vuejs-paginate'
import Pagination from 'vue-pagination-2';
Object.keys(rules).forEach(rule => {
  extend(rule, {
    ...rules[rule], // copies rule configuration
    message: messages[rule] // assign message
  });
});

// Register it globally
Vue.component('ValidationProvider', ValidationProvider); // validate field
Vue.component('ValidationObserver', ValidationObserver); // validate form
Vue.component('pagination', Pagination);
Vue.config.productionTip = false
Vue.use(VueAxios, axios)
Vue.use(money)
Vue.component('paginate', Paginate)
new Vue({
  render: h => h(App),
}).$mount('#app')
