<template>
    <div class="records-or-singles-button">
        <div class="button1">
            <input id="record-button" type="radio" value="record" v-model="addItem">
            <label for="record-button">Record</label>
        </div>
        <div class="button2">
            <input id="singles-button" type="radio" value="single" v-model="addItem">
            <label for="singles-button">Single</label>
        </div>
    </div>
    <div class="records" v-if="addItem == 'record'">
        <h1 class="header">Add Record</h1>
        <add-record-component></add-record-component>
    </div>
    <div class="singles" v-if="addItem == 'single'">
        <h1 class="header">Add Single/EP</h1>
        <add-single-component></add-single-component>
    </div>
</template>

<script>
import AddRecordComponent from '../components/AddRecordComponent.vue';
import AddSingleComponent from '../components/AddSingleComponent.vue';

export default {
    components: {
        AddRecordComponent,
        AddSingleComponent
    },
    data(){
        return {
            addItem: "record"
        }
    }
}
</script>