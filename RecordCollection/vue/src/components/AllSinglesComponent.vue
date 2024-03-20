<template>
    <div class="loading" v-if="isLoading">
        <p>Loading singles...</p>
    </div>
    <div class="list" v-else>
        <p>--TOTAL: {{ items.length }}--</p>
        <ul class="singles">
            <li class="list-item" v-for="item in items" :key="item" @click="goToSinglePage(item)">{{ item.artist }} |
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
import SinglesService from '../services/SinglesService.js';

export default {
    data() {
        return {
            items: [],
            isLoading: true
        }
    },
    methods: {
        getAllSingles() {
            SinglesService.getAllSingles()
                .then((response) => {
                    if(response.status === 200) {
                        this.$store.commit("GET_LIST_OF_SINGLES", response.data)
                        this.items = this.$store.state.singles
                        this.isLoading = false
                    }
                })
        },
        goToSinglePage(item) {
            SinglesService.getSingleSingle1(item)
                .then((response) => {
                    if (response.status === 200) {
                        this.$store.commit('GET_SINGLE', item)
                        return this.$router.push(`/Singles/Single`)
                    }
                })
        }
    },
    created() {
        this.getAllSingles();
    }
}
</script>