<template>
  <h1 class="header">Record Collection</h1>
  <home-component></home-component>
</template>

<script>
import HomeComponent from '../components/HomeComponent.vue';

export default {
  components: {
    HomeComponent
  }
}
;
</script>

<style>
.header {
  font-size: 110%;
  font-weight: bold;
  margin-left: 4px;
}
</style>
