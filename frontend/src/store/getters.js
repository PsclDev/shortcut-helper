export default {
    getMode(state) {
        return state.theme;
    },
    socketConnection(state) {
        return state.socketConnected;
    },
    activeApp(state) {
        return state.activeApp;
    },
    shortcutList(state) {
        return state.shortcutList
    }
};
