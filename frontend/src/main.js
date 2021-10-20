import { createApp } from 'vue'
import App from './App.vue'
import store from './store/index';

import '@/assets/styles/index.scss';

import { library } from '@fortawesome/fontawesome-svg-core'
import { faSync, faSun, faMoon } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

library.add(faSync);
library.add(faSun);
library.add(faMoon);

const app = createApp(App);

app.component('font-awesome-icon', FontAwesomeIcon);

app.use(store);
app.mount('#app');
