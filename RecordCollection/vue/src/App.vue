<template>
  <div id="record-app">
    <nav-bar-component></nav-bar-component>
    <router-view />
  </div>
</template>

<script>
import NavBarComponent from '@/components/NavBarComponent.vue'

export default {
components: {
  NavBarComponent
}
}
</script>