<template>
  <h1>Shortcuts-Helper</h1>
  <h3>{{ activeApp || 'No active window' }}</h3>
  <shortcut
    v-for="shortcut in shortcutList"
    :key="shortcut.Description"
    :keys="shortcut.Keys"
    :description="shortcut.Description"
  />
</template>

<script>
import Shortcut from './Components/Shortcut';

export default {
  name: 'App',
  data() {
    return {
      activeApp: null,
      shortcutList: []
    };
  },
  components: { Shortcut },
  methods: {
    startWebsocket() {
      var _this = this;

      console.log('Starting connection to WebSocket Server');
      const wsClient = new WebSocket('ws:deathmachine.home:9119/shortcuts');
      wsClient.onopen = function () {
        console.log('Successfully connected to the echo websocket server...');
        this.send('hello from vue');
      };

      wsClient.onmessage = function (message) {
        console.log('Server response => ', message.data);

        if (message.data.includes('{')) {
          const data = JSON.parse(message.data);
          _this.activeApp = data.Name;
          _this.shortcutList = data.Shortcuts;
        }
      };
    },
    heartbeat() {
      clearTimeout(this.pingTimeout);

      this.pingTimeout = setTimeout(() => {
        this.terminate();
      }, 30000 + 1000);
    }
  },
  created() {
    this.startWebsocket();
  }
};
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Nunito&display=swap');

#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;

  font-family: 'Nunito', sans-serif;
  text-align: center;
  color: #2c3e50;

  margin-top: 60px;
  margin: 0;
  padding: 0;
}

h1 {
  font-size: 40px;
}
</style>
