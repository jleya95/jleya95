<template>
    <div class="random-record">
        <p>{{ record.artist }} | <span class="record-title">{{ record.title }}</span> | {{ record.releaseYear }} | {{
            record.label }} <span v-if="record.issueYear != ''">|
                {{ record.issueYear }}</span> | {{ record.serialNumber }} <span v-if="record.needleInfo != ''">| {{
                    record.needleInfo
                }}</span>
        </p>
        <button @click="refreshPage()">Go Again</button>
    </div>

    <div class="album-art">
        <img :src="this.imgPath" v-if="imgPath != ''">
    </div>
</template>

<script>
import RecordsService from '@/services/RecordsService.js'
import APIService from '../services/APIService'

export default {
    data() {
        return {
            record: [],
            imgPath: ''
        }
    },
    methods: {
        getRandomRecord() {
            RecordsService.getRandomRecord()
                .then(response => {
                    this.record = response.data
                    this.getAlbumArt(this.record)
                })
        },
        getAlbumArt(record) {
            APIService.searchDiscogsForRecord(record)
                .then(response => {
                    this.imgPath = response.data
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

.random-record {
    margin-left: 4px;
}

.album-art {
    margin-left: 4px;
    margin-top: 4px;
}
</style>