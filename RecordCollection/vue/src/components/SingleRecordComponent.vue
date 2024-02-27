<template>
    <div class="album-art">
        <img :src="this.imgPath" v-if="imgPath != ''">
    </div>
    <div class="random-record">
        <p>{{ record.artist }} | <span class="record-title">{{ record.title }}</span> | {{ record.releaseYear }} | {{
            record.label }} <span v-if="record.issueYear != ''">|
                {{ record.issueYear }}</span> | {{ record.serialNumber }} <span v-if="record.needleInfo != ''">| {{
                    record.needleInfo
                }}</span>
        </p>
    </div>
</template>

<script>
export default {
    data() {
        return {
            record: []
        }
    }
}
</script>