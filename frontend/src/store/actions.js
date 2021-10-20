export default {
    getMode(context) {
        const darkMode = localStorage.getItem('darkMode');
        if (darkMode)
            context.commit('setMode', darkMode);
        else
            context.commit('setMode', 'light');
    },
    setMode(context) {
        const theme = context.rootGetters['getMode']

        if (theme === 'light')
            context.dispatch('switchMode', 'dark')
        else
            context.dispatch('switchMode', 'light')
    },
    switchMode(context, mode) {
        localStorage.setItem('darkMode', mode)
        context.commit('setMode', mode);
    },
    setSocketConnection(context, connected) {
        context.commit('setSocketConnction', connected);
    },
    startWebsocket(context) {
        console.log('start');
        const IP = process.env.VUE_APP_WEBSOCKET_IP;
        const PORT = process.env.VUE_APP_WEBSOCKET_PORT;

        const wsClient = new WebSocket(`ws:${IP}:${PORT}/shortcuts`);
        wsClient.onopen = function () {
            this.send('hello from vue');
        };

        wsClient.onmessage = function (message) {
            if (message.data.includes('Connected'))
                context.dispatch('setSocketConnection', true);

            if (message.data.includes('{')) {
                const data = JSON.parse(message.data);
                context.commit('setActiveApp', data.Name);
                context.commit('setShortcutList', data.Shortcuts);
            }
        };

        wsClient.onclose = function () {
            context.dispatch('setSocketConnection', false);
        };

        wsClient.onerror = function () {
            context.dispatch('setSocketConnection', false);
        };
    },
    heartbeat() {
        clearTimeout(this.pingTimeout);

        this.pingTimeout = setTimeout(() => {
            this.terminate();
        }, 30000 + 1000);
    }
}