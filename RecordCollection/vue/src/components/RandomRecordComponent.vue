<template>
    <div class="album-art" v-if="imgPath !=''">
        <img src={{ imgPath }} >
    </div>
    <div class="random-record">
        <p>{{ record.artist }} | <span class="record-title">{{ record.title }}</span> | {{ record.releaseYear }} | {{
            record.label }} |
            {{ record.issueYear }} | {{ record.serialNumber }} | {{ record.needleInfo }}
        </p>
        <button @click="refreshPage()">Go Again</button>
    </div>
</template>

<script>
import RecordsService from '@/services/RecordsService.js'
import APIService from '../services/APIService'

export default {
    data() {
        return {
            // record: {
            //     id: 0,
            //     file: "",
            //     artist: "",
            //     title: "",
            //     releaseYear: 0,
            //     label: "",
            //     issueYear: 0,
            //     serialNumber: "",
            //     pressing: "",
            //     discNumber: 0,
            //     color: "",
            //     notes: "",
            //     needleInfo: ""
            // }
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
</style>