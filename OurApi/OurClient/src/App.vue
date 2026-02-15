<template>
  <Navbar />
  <main class="container">
    <router-view />
  </main>
</template>

<script>
import Navbar from "./components/Navbar.vue";

export default {
  components: { 
    Navbar 
  }
}
</script>