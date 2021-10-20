<template>
  <div class="row">
    <div class="col-2">
      <div class="m-2 mb-0 h1 clickable" @click="toggleTheme">
        <font-awesome-icon :icon="darkMode ? 'sun' : 'moon'" />
      </div>
    </div>
    <div class="col-8">
      <h1 class="fw-bold">Shortcuts-Helper</h1>
      <h4>{{ activeApp || 'No active window' }}</h4>
    </div>
    <div class="col-2">
      <div class="m-2 mb-0 clickable">
        <p
          class="mb-0"
          :class="socketConnected ? 'text-success' : 'text-danger'"
        >
          {{ socketConnected ? 'Socket Connected' : 'Socket not connected' }}
        </p>
      </div>
      <div
        class="m-0 text-danger"
        v-if="!socketConnected"
        @click="restartWebsocket"
      >
        <font-awesome-icon icon="sync" />
      </div>
    </div>
  </div>
</template>


<script>
export default {
  methods: {
    toggleTheme() {
      this.$store.dispatch('setMode');
      document.querySelector('body').classList.toggle('dark');
    },
    restartWebsocket() {
      this.$store.dispatch('startWebsocket');
    }
  },
  computed: {
    darkMode() {
      return this.$store.getters.getMode === 'dark';
    },
    socketConnected() {
      return this.$store.getters.socketConnection;
    },
    activeApp() {
      return this.$store.getters.activeApp;
    }
  }
};
</script>

<style scoped>
.relative {
  position: relative;
}

.index {
  z-index: 2000;
}

.left {
  position: absolute;
  top: 0px;
  left: 0px;
}

.right {
  position: absolute;
  top: 0px;
  right: 0px;
}

.clickable {
  cursor: pointer;
}
</style>