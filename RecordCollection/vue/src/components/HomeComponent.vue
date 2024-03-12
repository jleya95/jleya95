<template>
  <div class="home">
    <button @click="randomPagePush()">Random</button>
  </div>
</template>
  
<script>
import RecordsService from '../services/RecordsService';

export default {
  methods: {
    randomPagePush() {
      return this.$router.push({ name: "RandomRecord" })
    },
    // getAllRecords() {
    //   RecordsService.getAllRecords()
    //     .then((response) => {
    //       if (response.status === 200) {
    //         this.$store.commit("GET_LIST_OF_RECORDS", response.data)
    //       }
    //     })
    // }
  },
  // created() {
  //   this.getAllRecords();
  // }
};
</script>
  
<style>
.home {
  margin-left: 4px;
}
</style>