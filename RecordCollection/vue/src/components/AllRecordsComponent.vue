<template>
    <div class="loading" v-if="isLoading">
        <p>Loading records...</p>
    </div>
    <div class="list" v-else>
        <ul class="records">
            <p>--TOTAL: {{ items.length }}--</p>
            <li class="list-item" v-for="item in items" :key="item" @click="goToRecordPage(item)">{{ item.artist }} |
                <span class="record-title">{{ item.title }}</span> |
                <span id="release" v-if="item.releaseYear != 0">{{ item.releaseYear }}</span> <span v-else>n/a</span> |
                {{ item.label }} | <span v-if="item.issueYear != 0">{{ item.issueYear }}</span> <span v-else>n/a</span>
                |
                {{ item.serialNumber }}
            </li>
        </ul>
    </div>
</template>

<script>
// import { routerKey } from 'vue-router';
import RecordsService from '../services/RecordsService';

export default {
    data() {
        return {
            items: [],
            isLoading: true
        }
    },
    methods: {
        getAllRecords() {
            RecordsService.getAllRecords()
                .then((response) => {
                    if (response.status === 200) {
                        this.$store.commit("GET_LIST_OF_RECORDS", response.data)
                        this.items = this.$store.state.records
                        this.isLoading = false;
                    }
                })
        },
        // getRecordsFromStore() {
        //     this.items = this.$store.state.records
        // },
        goToRecordPage(item) {
            RecordsService.getSingleRecord1(item)
                .then((response) => {
                    if (response.status === 200) {
                        this.$store.commit('GET_RECORD', item)
                        return this.$router.push(`/Records/record`)
                    }
                })
        },

    },
    created() {
        this.getAllRecords();
        // this.getRecordsFromStore();
    }
}
</script>

<style>
.list {
    margin-left: 4px;
}

.list-item:hover {
    background-color: lightgray
}
</style>