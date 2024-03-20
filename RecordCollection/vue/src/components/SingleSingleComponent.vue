<template>
    <div class="single-single">
        <p class="record-info"><span class="record-artist">{{ single.artist }}</span> - <span class="record-title">{{
            single.title }}</span> ({{ single.releaseYear }})
        </p>
    </div>
    <div class="single-art">
        <img :src="this.imgPath" v-if="imgPath != ''">
    </div>
    <div class="single-single">
        <p class="record-info">{{ single.label }} <span v-if="single.issueYear != ''">|
                {{ single.issueYear }}</span> | {{ single.serialNumber }}</p>
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
                    this.imgPath = this.imgPath + response.data
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
.single-single {
    margin-left: 4px;
    margin-top: 4px
}
</style>