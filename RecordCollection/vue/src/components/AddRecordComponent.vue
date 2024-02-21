<template>
    <div class="add-form">
        <form class="Form" id="AddRecordForm">
            <div class="form-body">
                <div class="field">
                    <label class="add-form-label" for="file-add">File as: </label>
                    <input class="add-form-input" type="text" id="file-add" v-model="record.file">
                </div>
                <div class="field">
                    <label class="add-form-label" for="artist-add">Artist: </label>
                    <input class="add-form-input" type="text" id="artist-add" v-model="record.artist">
                </div>
                <div class="field">
                    <label class="add-form-label" for="title-add">Title: </label>
                    <input class="add-form-input" type="text" id="title-add" v-model="record.title">
                </div>
                <div class="field">
                    <label class="add-form-label" for="released-add">Released: </label>
                    <input class="add-form-input" type="text" id="release-add" v-model="record.releaseYear">
                </div>
                <div class="field">
                    <label class="add-form-label" for="issued-add">Issued: </label>
                    <input class="add-form-input" type="text" id="issued-add" v-model="record.issueYear">
                </div>
                <div class="field">
                    <label class="add-form-label" for="label-add">Label: </label>
                    <input class="add-form-input" type="text" id="label-add" v-model="record.label">
                </div>
                <div class="field">
                    <label class="add-form-label" for="serial-add">Serial: </label>
                    <input class="add-form-input" type="text" id="serial-add" v-model="record.serialNumber">
                </div>
                <div class="field">
                    <label class="add-form-label" for="pressing-add">Pressing: </label>
                    <input class="add-form-input" type="text" id="pressing-add" v-model="record.pressing">
                </div>
                <div class="field">
                    <label class="add-form-label" for="disc-add">Disc #: </label>
                    <input class="add-form-input" type="text" id="disc-add" v-model="record.discNumber">
                </div>
                <div class="field">
                    <label class="add-form-label" for="color-add">Color: </label>
                    <input class="add-form-input" type="text" id="color-add" v-model="record.color">
                </div>
                <div class="field">
                    <label class="add-form-label" for="notes-add">Notes: </label>
                    <textarea class="add-form-input" id="notes-add" v-model="record.notes"></textarea>
                </div>
                <div class="field">
                    <label class="add-form-label" for="needle-add">Needle Info: </label>
                    <input class="add-form-input" type="text" id="needle-add" v-model="record.needleInfo">
                </div>
                <button class="add-button" @click="addRecord">Add</button>
            </div>
        </form>
    </div>
</template>

<script>
import RecordsService from '../services/RecordsService.js'

export default {
    data() {
        return {
            record: {
                id: 0,
                file: "",
                artist: "",
                title: "",
                releaseYear: "",
                label: "",
                issueYear: "",
                serialNumber: "",
                pressing: "",
                discNumber: "",
                color: "",
                notes: "",
                needleInfo: ""
            }
        }
    },
    methods: {
        addRecord() {
            RecordsService.addRecord(this.record)
                .then((response) => {
                    if (response.status === 200) {
                        return true;
                    }
                })
                .catch((error) => {
                    this.handleErrorResponse(error, "Record not added")
                })

        },
        handleErrorResponse(error, verb) {
            if (error.response) {
                console.log(
                    `Error ${verb} topic. Response received was "${error.response.statusText}".`
                );
            } else if (error.request) {
                console.log(`Error ${verb} topic. Server could not be reached.`);
            } else {
                console.log(`Error ${verb} topic. Request could not be created.`);
            }
        },

    }
}
</script>

<style>
.add-button {
width: 3%
}

.form-body {
    display: flex;
    flex-direction: column;
    margin-top: 1%;
}

.add-form-input {
    width: 10%
}

.add-form-label {
    margin-right: 1px;
}

.field {
    display: flex;
    flex-direction: row;
}
</style>