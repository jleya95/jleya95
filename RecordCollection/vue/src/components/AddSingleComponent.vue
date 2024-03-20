<template>
    <div class="body">
        <div class="add-form">
            <form class="Form" id="AddSingleForm">
                <div class="form-body">
                    <div class="field">
                        <label class="add-form-label" for="file-add">File as: </label>
                        <input class="add-form-input" type="text" id="file-add" v-model="single.file">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="artist-add">Artist: </label>
                        <input class="add-form-input" type="text" id="artist-add" v-model="single.artist">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="title-add">Title: </label>
                        <input class="add-form-input" type="text" id="title-add" v-model="single.title">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="released-add">Released: </label>
                        <input class="add-form-input" type="text" id="release-add" v-model="single.releaseYear">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="issued-add">Issued: </label>
                        <input class="add-form-input" type="text" id="issued-add" v-model="single.issueYear">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="label-add">Label: </label>
                        <input class="add-form-input" type="text" id="label-add" v-model="single.label">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="serial-add">Serial: </label>
                        <input class="add-form-input" type="text" id="serial-add" v-model="single.serialNumber">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="pressing-add">Pressing: </label>
                        <input class="add-form-input" type="text" id="pressing-add" v-model="single.pressing">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="color-add">Color: </label>
                        <input class="add-form-input" type="text" id="color-add" v-model="single.color">
                    </div>
                    <div class="field">
                        <label class="add-form-label" for="notes-add">Notes: </label>
                        <textarea class="add-form-input" id="notes-add" v-model="single.notes"></textarea>
                    </div>
                    <button class="add-button" @click="addSingle">Add</button>
                </div>
            </form>
            <div class="popup" v-if="showPopUp">
                <add-record-pop-up-component></add-record-pop-up-component>
            </div>
        </div>
    </div>
</template>

<script>
import SinglesService from '../services/SinglesService.js'
import AddRecordPopUpComponent from './AddRecordPopUpComponent.vue'

export default {
    components: {
        AddRecordPopUpComponent
    },
    data() {
        return {
            single: {
                id: 0,
                file: "",
                artist: "",
                title: "",
                releaseYear: "",
                label: "",
                issueYear: "",
                serialNumber: "",
                pressing: "",
                color: "",
                notes: "",
            },
            showPopUp: false,
        }
    },
    methods: {
        addSingle(e) {
            e.preventDefault();
            SinglesService.addSingle1(this.single)
                .then((response) => {
                    if (response.status === 200) {
                        this.showPopUp = true
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

.add-form {
    margin-left: 4px;
}

.popup {
    margin: 4px
}
</style>