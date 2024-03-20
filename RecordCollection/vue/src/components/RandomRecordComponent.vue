<template>
    <div class="loading" v-if="isLoading">
        <p>Loading record...</p>
    </div>
    <div v-else>
        <div class="random-record">
            <button @click="refreshPage()">Go Again</button>
            <p class="record-info"><span class="record-artist">{{ record.artist }}</span> - <span
                    class="record-title">{{
        record.title }}</span> ({{ record.releaseYear }})
            </p>
        </div>
        <div class="album-art">
            <img :src="this.imgPath" v-if="imgPath != ''">
        </div>
        <div class="random-record">
            <p class="record-info">
                {{ record.label }} <span v-if="record.issueYear != ''">|
                    {{ record.issueYear }}</span> | {{ record.serialNumber }}
                <span v-if="record.needleInfo != ''">| {{ record.needleInfo }}</span>
            </p>
        </div>
    </div>

</template>

<script>
import RecordsService from '../services/RecordsService.js'
import APIService from '../services/APIService'

export default {
    data() {
        return {
            record: [],
            imgPath: '',
            isLoading: true
        }
    },
    methods: {
        getRandomRecord() {
            RecordsService.getRandomRecord()
                .then(response => {
                    this.record = response.data
                    this.getAlbumArt(this.record)
                    this.isLoading = false
                })
        },
        getAlbumArt(record) {
            APIService.searchDiscogsForRecord(record)
                .then(response => {
                    this.imgPath = this.imgPath + response.data
                })
        },
        refreshPage() {
            location.reload();
        }
    },
    created() {
        this.getRandomRecord();
    }
}
</script>

<style>
.record-title {
    font-style: italic;
}

.record-artist {
    font-weight: bold;
}

.record-info {
    text-wrap: nowrap;
}

.random-record {
    margin-left: 4px;
}

.album-art {
    /* margin-left: 4px;
    margin-top: 4px; */
    margin: 4px
}
</style>