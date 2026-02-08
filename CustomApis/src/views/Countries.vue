<template>
  <h1>Ülke Bilgileri</h1>
  <div>
    <ul>
      <li v-for="c in countries" :key="id">
        <div>
          <img :src="c.media.flag" class="flag" />
          <span>{{ c.name }}</span> / <span>👪 {{ c.population }}</span>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'Countries',
  data() {
    return {
      countries: [],
    }
  },
  mounted() {
    fetch('https://api.sampleapis.com/countries/countries')
      .then((response) => response.json())
      .then((values) => {
        this.countries = values
      })
  },
}
</script>

<style scoped>
.flag {
  width: 30px;
  height: 20px;
}
</style>
