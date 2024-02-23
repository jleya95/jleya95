<template>
  <div class="home">
    <button @click="randomPagePush()">Random</button>
  </div>
</template>
  
<script>
export default {
  methods: {
    randomPagePush() {
      return this.$router.push({ name: "RandomRecord" })
    }
  }
};
</script>
  
<style>
.home {
  margin-left: 4px;
}
</style>