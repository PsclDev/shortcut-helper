<template>
  <div class="chip">
    <p>{{ keyString }}</p>
  </div>
</template>

<script>
export default {
  props: {
    keyString: {
      type: String,
      required: true
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
  background-color: #f1f1f1;
}
</style>