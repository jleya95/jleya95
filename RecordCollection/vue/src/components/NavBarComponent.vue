<template>
    <div id="nav">
        <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
        <router-link v-bind:to="{ name: 'AllRecords'}">All Records</router-link>&nbsp;|&nbsp;
        <router-link v-bind:to="{ name: 'AddRecord'}">Add Record</router-link>
        <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
</template>

<script></script>

<style>
#nav {
    margin-left: 4px;
}
</style>