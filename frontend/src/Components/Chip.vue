<template>
  <span class="badge rounded-pill bg-secondary text-primary">
    {{ key }}
  </span>
</template>

<script>
export default {
  props: {
    keyString: {
      type: String,
      required: true
    }
  },
  computed: {
    key() {
      return this.keyString.toUpperCase();
    }
  }
};
</script>