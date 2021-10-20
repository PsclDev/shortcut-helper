<template>
  <div class="d-flex align-items-center justify-content-center w-50 m-auto">
    <div class="d-flex text-end justify-content-end w-50">
      <chip class="me-2" v-for="key in keys" :key="key" :keyString="key" />
    </div>
    <div class="w-50 ms-5 mt-4 mb-4 text-start">
      <div class="fs-5">{{ description }}</div>
    </div>
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
    },
    wrap: {
      tye: Boolean
    }
  },
  components: { Chip }
};
</script>