<template>
    <div class="list">
        <ul class="records">
            <li class="list-item" v-for="item in items" :key="item">{{ item.artist }} | <span class="record-title">{{ item.title }}</span> |
                <span id="release" v-if="item.releaseYear != 0">{{ item.releaseYear }}</span> <span v-else>n/a</span> |
                {{ item.label }} | <span v-if="item.issueYear != 0">{{ item.issueYear }}</span> <span v-else>n/a</span> |
                {{ item.serialNumber }}
            </li>
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

.list-item:hover{
    background-color: lightgray
}
</style>