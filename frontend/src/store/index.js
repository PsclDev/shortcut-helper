import { createStore } from 'vuex';
import mutations from './mutations';
import actions from './actions';
import getters from './getters';

const store = createStore({
    state() {
        return {
            theme: String,
            socketConnected: Boolean,
            activeApp: null,
            shortcutList: []
        };
    },
    mutations,
    actions,
    getters
});

export default store;