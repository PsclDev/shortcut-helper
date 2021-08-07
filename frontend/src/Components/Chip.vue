<template>
  <div class="chip">
    <p>{{ key }}</p>
  </div>
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

<style scoped>
.chip {
  display: inline-block;
  padding: 0 25px;
  height: 50px;
  font-size: 16px;
  font-weight: bold;
  border-radius: 15px;
  background-color: #cdd4df;
}
</style>