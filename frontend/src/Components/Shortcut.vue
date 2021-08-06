<template>
  <div class="center">
    <div class="flex">
      <chip class="space" v-for="key in keys" :key="key" :keyString="key" />
    </div>
    <p class="description">{{ description }}</p>
  </div>
</template>

<script>
import Chip from './Chip';

export default {
  props: {
    keys: {
      type: Array,
      required: true
    },
    description: {
      type: String,
      required: true
    }
  },
  components: { Chip }
};
</script>

<style scoped>
.center {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 50%;
  margin: auto;
}

.flex {
  display: flex;
  text-align: right;
  width: 50%;
  justify-content: flex-end;
}

.space {
  margin: 0px 5px;
}

.description {
  margin-left: 50px;
  font-size: 20px;
  text-align: left;
  width: 50%;
}
</style>