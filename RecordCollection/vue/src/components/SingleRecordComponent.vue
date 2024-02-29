<template>
    <!-- <div class="album-art">
        <img :src="this.imgPath" v-if="imgPath != ''">
    </div>
    <div class="single-record">
        <p>{{ record.artist }} | <span class="record-title">{{ record.title }}</span> | {{ record.releaseYear }} | {{
            record.label }} <span v-if="record.issueYear != ''">|
                {{ record.issueYear }}</span> | {{ record.serialNumber }} <span v-if="record.needleInfo != ''">| {{
                    record.needleInfo
                }}</span>
        </p>
    </div> -->
    <h2>hi</h2>
</template>

<script>
import RecordsService from '../services/RecordsService';
import APIService from '../services/APIService';

export default {
    data() {
        return {
            record: [],
            imgPath: ''
        }
    }
}
</script>