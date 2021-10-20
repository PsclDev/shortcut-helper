<template>
  <TheHeader />
  <div class="container-fluid">
    <div class="flex-wrap d-flex">
      <shortcut
        class=""
        v-for="shortcut in shortcutList"
        :key="shortcut.Description"
        :keys="shortcut.Keys"
        :description="shortcut.Description"
      />
    </div>
  </div>
</template>

<script>
import TheHeader from './Components/Layout/TheHeader';
import Shortcut from './Components/Shortcut';

export default {
  name: 'App',
  components: { TheHeader, Shortcut },
  created() {
    this.$store.dispatch('getMode');

    const darkMode = this.$store.getters.getMode;
    if (darkMode === 'dark')
      document.querySelector('body').classList.toggle('dark');

    this.$store.dispatch('startWebsocket');
  },
  computed: {
    shortcutList() {
      return this.$store.getters.shortcutList;
    }
  }
};
</script>