<template>
    <div class="random-single">
        <p>{{ single.artist }} | <span class="record-title">{{ single.title }}</span> | {{ single.releaseYear }} | {{
            single.label }} <span v-if="single.issueYear != ''">|
                {{ single.issueYear }}</span> | {{ single.serialNumber }}
        </p>
        <button @click="refreshPage()">Go Again</button>
    </div>

    <div class="single-art">
        <img :src="this.imgPath" v-if="imgPath != ''">
    </div>
</template>

<script>
import SinglesService from '../services/SinglesService.js'
import APIService from '../services/APIService'

export default {
    data() {
        return {
            single: [],
            imgPath: '/'
        }
    },
    methods: {
        getRandomSingle() {
            SinglesService.getRandomSingle()
                .then(response => {
                    this.single = response.data
                    this.getAlbumArt(this.single)
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
    margin-left: 4px;
    margin-top: 4px;
}

</style>