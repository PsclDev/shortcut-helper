export default {
    setMode(state, theme) {
        state.theme = theme;
    },
    setSocketConnction(state, connected) {
        state.socketConnected = connected;
    },
    setActiveApp(state, app) {
        state.activeApp = app;
    },
    setShortcutList(state, list) {
        state.shortcutList = list
    }
};