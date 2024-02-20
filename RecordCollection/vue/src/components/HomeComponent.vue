<template>
    <div class="home">
      <h1>Record Selector</h1>
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
  