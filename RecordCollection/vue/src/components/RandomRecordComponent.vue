<template>
    <div class="random-record">
        <p>{{ record.artist }} | <span id="record-title">{{ record.title }}</span> | {{ record.releaseYear }} | {{ record.label }} | 
            {{ record.issueYear }} | {{ record.serialNumber }} | {{ record.needleInfo }}
        </p>
        <button @click="refreshPage()">Go Again</button>    
    </div>
</template>

<script>
import RecordsService from '@/services/RecordsService.js'

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
            record: []
        }
    },
    methods: {
        getRandomRecord() {
            RecordsService.getRandomRecord()
            .then(response => {
                this.record = response.data
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
#record-title {
    font-style: italic;
}

.random-record {
    margin-left: 4px;
}
</style>