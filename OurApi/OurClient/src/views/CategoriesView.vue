<template>
  <h3>Kategoriler <span>({{ categoryCount }})</span></h3>
  <div class="category-container">
    <div>
      <ul>
        <li v-for="c in categories" @click="() => showDetail(c.id)">{{ c.name }}</li>
      </ul>
    </div>
    <div>
      <div v-if="hasDetail" class="image-container">
        <div>
          <img :src="imageUrl" />
        </div>
        <div>{{ description }}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Categories',
  data() {
    return {
      categories: [],
      hasDetail: false,
      description: null,
      imageUrl: null
    }
  },
  mounted() {
    fetch("http://localhost:5161/categories")
      .then(response => response.json())
      .then(content => {
        this.categories = content;
      });
  },
  methods: {
    showDetail(id) {
      this.hasDetail = false;
      this.imageUrl = `http://localhost:5161/categories/${id}/photo`;
      //Açıklama için
      fetch("http://localhost:5161/categories/" + id)
        .then(response => response.json())
        .then(content => {
          this.description = content.description;
          this.hasDetail = true;
        });
    }
  },
  computed: {
    categoryCount() {
      return this.categories.length;
    }
  }
}
</script>

<style scoped>
ul {
  margin: 0;
  padding: 0;
  list-style: none;
}

ul>li {
  margin-bottom: 10px;
  cursor: pointer;
}

.category-container {
  display: flex;
}

.category-container>div {
  flex: 1;
}

.category-container img {
  width: 100%;
}

.image-container {
  padding: 10px;
}
</style>