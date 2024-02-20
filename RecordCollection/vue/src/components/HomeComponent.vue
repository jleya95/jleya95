<template>
    <div class="home">
      <h1>Select an Option:</h1>
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
  