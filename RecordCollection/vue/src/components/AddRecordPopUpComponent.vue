<template>
    <div class="popup-container">
        <div class="text">
            <h1 class="header">RECORD ADDED</h1>
        </div>
        <button @click="closePopup">Close</button>
    </div>
</template>

<script>
export default {
    methods: {
        closePopup() {
            return location.reload();
        }
    }
}

</script>

<style>
.popup-container {
    /* background-color: rgba(138, 189, 157); */
    background-color: rgba(255, 255, 255);
    display: flex;
    flex-direction: column;
    align-items: center;
    align-content: center;
    text-align: center;
    padding: 1%;
    width: 40%;
    border-radius: 20px;
}
</style>