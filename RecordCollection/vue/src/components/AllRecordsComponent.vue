<template>
    <div class="list">
        <ul class="records">
            <li v-for="item in items" :key="item">{{ item.artist }} | {{ item.title }} | {{ item.releaseYear }} |
                {{ item.label }} | {{ item.issueYear }} | {{ item.serialNumber }}</li>
        </ul>
    </div>
</template>

<script>
import RecordsService from '../services/RecordsService';

export default {
    data() {
        return {
            items: []
        }
    },
    methods: {
        getAllRecords() {
            RecordsService.getAllRecords()
                .then((response) => {
                    if (response.status === 200) {
                        this.items = response.data
                    }
                })
        }
    },
    created() {
        this.getAllRecords();
    }
}
</script>

<style>
.list {
    margin-left: 4px;
}
</style>