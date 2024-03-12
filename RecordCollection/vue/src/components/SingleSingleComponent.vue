<template>
    <div class="single-single">
        <p>{{ single.artist }} | <span class="record-title">{{ single.title }}</span> | {{ single.releaseYear }} | {{
            single.label }} <span v-if="single.issueYear != ''">|
                {{ single.issueYear }}</span> | {{ single.serialNumber }} <span v-if="single.needleInfo != ''">| {{
                    single.needleInfo
                }}</span>
        </p>
    </div>
    <div class="single-art">
        <img :src="this.imgPath" v-if="imgPath != ''">
    </div>
</template>

<script>
import APIService from '../services/APIService';

export default {
    data() {
        return {
            single: [],
            imgPath: ''
        }
    },
    methods: {
        getSingleArt(single) {
            APIService.searchDiscogsForRecord(single)
                .then(response => {
                    this.imgPath = response.data
                })
        },
        setSingle() {
            this.single = this.$store.state.currentSingle
        }
    },
    created() {
        this.setSingle();
        this.getSingleArt(this.single)
    }
}
</script>

<style>
.single-single, .single-art {
    margin-left: 4px;
}
</style>