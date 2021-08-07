<template>
  <div class="status">
    <p :style="socketConnected ? 'color: #7dbf00' : 'color: #db122f'">
      {{ socketConnected ? 'Socket Connected' : 'Socket not connected' }}
    </p>
  </div>

  <h1>Shortcuts-Helper</h1>
  <h3>{{ activeApp || 'No active window' }}</h3>

  <div :class="shortcutList.length > 7 ? 'flex' : ''">
    <shortcut
      v-for="shortcut in shortcutList"
      :key="shortcut.Description"
      :keys="shortcut.Keys"
      :description="shortcut.Description"
    />
  </div>
</template>

<script>
import Shortcut from './Components/Shortcut';

export default {
  name: 'App',
  data() {
    return {
      socketConnected: false,
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
        if (message.data.includes('Connected')) _this.socketConnected = true;

        if (message.data.includes('{')) {
          const data = JSON.parse(message.data);
          _this.activeApp = data.Name;
          _this.shortcutList = data.Shortcuts;
        }
      };

      wsClient.onclose = function () {
        _this.socketConnected = false;
      };

      wsClient.onerror = function () {
        _this.socketConnected = false;
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

html,
body {
  background-color: #f8f8ff;
  color: #090c10;
}

#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;

  font-family: 'Nunito', sans-serif;
  text-align: center;

  margin-top: 60px;
  margin: 0;
  padding: 0;
}

h1 {
  font-size: 40px;
  margin-bottom: 0;
}

.flex {
  display: flex;
  flex-wrap: wrap;
}

.status {
  position: absolute;
  top: 0;
  right: 15px;
}
</style>
