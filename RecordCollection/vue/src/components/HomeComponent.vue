<template>
    <div class="home">
      <button @click="randomPagePush()">Random</button>
      <button>All</button>
    </div>
  </template>
  
  <script>
  export default {
    methods: {
      randomPagePush(){
        return this.$router.push({ name: "RandomRecord" })
      }
    }
  };
  </script>
  