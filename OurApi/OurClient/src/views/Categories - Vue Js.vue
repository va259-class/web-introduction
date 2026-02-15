<template>
  <h3>Kategoriler <span>({{ categoryCount }})</span></h3>
  <p v-if="lastUpdated">
    Son Ekleme Tarihi : <span>{{ lastUpdated }}</span>
  </p>
<ul v-if="lastUpdated">
  <li v-for="c in categories">{{ c.name }}</li>
</ul>

<button @click="addCategory">Ekle</button>
</template>

<script>
export default {
  name: 'Categories',
  data() {
    return {
      categories: [],
      lastUpdated: null
    }
  },
  methods: {
    addCategory() {
      let tick = new Date().getTime();
      this.categories.push({ id: tick, name: "Category " + tick});

      this.lastUpdated = new Date();
    }
  },
  computed: {
    categoryCount() {
      return this.categories.length;
    }
  }
}
</script>
