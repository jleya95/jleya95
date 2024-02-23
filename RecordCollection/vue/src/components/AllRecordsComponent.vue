<template>
    <table>Testing</table>
    <div>
        <p>{{ listOfRecords }}</p>
    </div>
</template>

<script>
import RecordsService from '../services/RecordsService';

export default {
    data() {
        return {
            listOfRecords: []
        }
    },
    methods: {
        getAllRecords() {
            RecordsService.getAllRecords()
            .then ((response) => {
                if (response.status === 200) {
                    this.listOfRecords = response.data
                }
            })
        }
    },
    created() {
        this.getAllRecords();
    }
}
</script>