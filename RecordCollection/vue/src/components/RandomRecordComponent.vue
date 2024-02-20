<template>
    <p>{{ record.artist }}</p>
</template>

<script>
import RecordsService from '@/services/RecordsService.js'

export default {
    data() {
        return {
            record: {
                id: 0,
                file: "",
                artist: "",
                title: "",
                releaseYear: 0,
                label: "",
                issueYear: 0,
                serialNumber: "",
                pressing: "",
                discNumber: 0,
                color: "",
                notes: "",
                needleInfo: ""
            }
        }
    },
    methods: {
        getRandomRecord() {
            let object = RecordsService.getRandomRecord();
            this.record.artist = object.artist;

            return this.record;
        }
    },
    created() {
        this.getRandomRecord();
    }
}
</script>