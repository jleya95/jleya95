<template>
    <div class="body">
        <div class="add-form">
            <form class="Form" id="AddRecordForm">
                <div class="form-body">
                    <div class="field">
                        <label class="add-form-label" for="file-add">File As: </label>
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
                    <div class="field">
                        <label for="code-add" class="add-form-label">Access Code: </label>
                        <input type="text" id="code-add" class="add-form-input" v-model="code">
                    </div>
                    <button class="add-button" @click="addRecord">Add</button>
                </div>
            </form>
        </div>
        <div class="popup" v-if="showPopUp">
            <add-record-pop-up-component></add-record-pop-up-component>
        </div>
        <div class="code-error" v-if="codeError">
            <p>Wrong code!</p>
        </div>
    </div>
</template>

<script>
import RecordsService from '../services/RecordsService.js'
import AddRecordPopUpComponent from './AddRecordPopUpComponent.vue'

export default {
    components: {
        AddRecordPopUpComponent
    },
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
            },
            code: "",
            codeError: false,
            showPopUp: false,
        }
    },
    methods: {
        addRecord(e) {
            e.preventDefault();
            if (this.code === '0905') {
                this.removeAmpersands(this.record);
                RecordsService.addRecord(this.record)
                .then((response) => {
                    if (response.status === 200) {
                        this.codeError = false;
                        this.clearForm();
                        this.showPopUp = true
                        }
                    })
                    .catch((error) => {
                        this.handleErrorResponse(error, "Record not added")
                    })
            } else {
                this.codeError = true
            }

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
        removeAmpersands(record) {
            if (record.file.includes('&')){
                record.file = record.file.replace('&', '%26')
            }
            if (record.artist.includes('&')){
                record.artist = record.artist.replace('&', '%26')
            }
            if (record.title.includes('&')){
                record.title = record.title.replace('&', '%26')
            }
            if (record.label.includes('&')){
                record.label = record.label.replace('&', '%26')
            }
            return record;
        },
        clearForm(){
            this.record.file = '';
            this.record.artist = '';
            this.record.title = '';
            this.record.releaseYear = '';
            this.record.label = '';
            this.record.issueYear = '';
            this.record.serialNumber = '';
            this.record.pressing = '';
            this.record.discNumber = '';
            this.record.color = '';
            this.record.notes = '';
            this.record.needleInfo = '';
            this.code = '';
        }
    }
}
</script>

<style>
.body {
    width: auto;
    display: flex;
    flex-direction: column;
}

.add-button {
    width: auto;
    max-width: 10%
}

.form-body {
    display: flex;
    flex-direction: column;
    margin-top: 1%;
}

.add-form-input {
    width: auto;
    max-width: 20%
}

.add-form-label {
    margin-right: 1px;
}

.field {
    display: flex;
    flex-direction: row;
}

.add-form, .code-error {
    margin-left: 4px;
}

.popup {
    margin: 4px
}
</style>