<template>
    <div class="loading" v-if="isLoading">
        <p>Loading single...</p>
    </div>
    <div v-else>
        <div class="random-single">
            <button @click="refreshPage()">Go Again</button>
            <p class="record-info"><span class="record-artist">{{ single.artist }}</span> - <span
                    class="record-title">{{
        single.title }}</span> ({{ single.releaseYear }})
            </p>
        </div>

        <div class="single-art">
            <img :src="this.imgPath" v-if="imgPath != ''">
        </div>

        <div class="random-single">
            <p class="record-info">{{ single.label }} <span v-if="single.issueYear != ''">|
                    {{ single.issueYear }}</span> | {{ single.serialNumber }}</p>
        </div>
    </div>

</template>

<script>
import SinglesService from '../services/SinglesService.js'
import APIService from '../services/APIService'

export default {
    data() {
        return {
            single: [],
            imgPath: '',
            isLoading: true
        }
    },
    methods: {
        getRandomSingle() {
            SinglesService.getRandomSingle()
                .then(response => {
                    this.single = response.data
                    this.getAlbumArt(this.single)
                    this.isLoading = false
                })
        },
        getAlbumArt(single) {
            APIService.searchDiscogsForRecord(single)
                .then(response => {
                    this.imgPath = this.imgPath + response.data
                })
        },
        refreshPage() {
            location.reload();
        }
    },
    created() {
        this.getRandomSingle();
    }
}
</script>

<style>
.record-title {
    font-style: italic;
}

.random-single {
    margin-left: 4px;
}

.single-art {
    /* margin-left: 4px;
    margin-top: 4px; */
    margin: 4px;
}
</style>