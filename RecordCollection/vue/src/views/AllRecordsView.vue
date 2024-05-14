<template>
    <div class="records-or-singles-button">
        <div class="button1">
            <input id="record-button" type="radio" value="records" v-model="listItems">
            <label for="record-button">Records</label>
        </div>
        <div class="button2">
            <input id="singles-button" type="radio" value="singles" v-model="listItems">
            <label for="singles-button">Singles</label>
        </div>
    </div>
    <div class="records" v-if="listItems=='records'">
        <h1 class="header">All Records</h1>
        <all-records-component></all-records-component>
    </div>
    <div class="singles" v-if="listItems=='singles'">
        <h1 class="header">All Singles/EPs</h1>
        <all-singles-component></all-singles-component>
    </div>
</template>

<script>
import AllRecordsComponent from '../components/AllRecordsComponent.vue';
import AllSinglesComponent from '../components/AllSinglesComponent.vue';

export default {
    components: {
        AllRecordsComponent,
        AllSinglesComponent
    },
    data() {
        return {
            listItems: "records"
        }
    }
}
</script>

<style>
.records-or-singles-button {
    margin-left: 4px;
    display: flex;
    flex-direction: row;
}
.button2 {
    margin-left: 4px;
}
/* .button1, .button2 {
    background-color: lightslategray;
} */
</style>