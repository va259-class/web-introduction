<template>
  <p>
    Alışveriş sürecinde sizlere daha fazla yardımcı olmamız için verileriniz ve hareketlerizi kaydediyoruz!
  </p>

  <h3>Alışverişe Hazır Ürünler</h3>
  <div>
    <div class="product-container">
      <ProductCard :value="p" v-for="p in products" />
    </div>
    <div class="more-container" v-if="showMore">
      <span v-if="loading">Yükleniyor...</span>
      <a v-else @click="fetchMore">Daha Fazla</a>
    </div>
  </div>
</template>

<script>
import ProductCard from '@/components/ProductCard.vue';
export default {
  name: 'Home',
  components: {
    ProductCard
  },
  data() {
    return {
      products: [],
      page: 1,
      showMore: true,
      loading: false
    }
  },
  mounted() {
    fetch(`http://localhost:5161/products?page=${this.page}`)
      .then(response => response.json())
      .then(content => {
        this.products = content;
      });
  },
  methods: {
    fetchMore() {
      this.page++;
      this.loading = true;

      //Gecikmeli başlat
      setTimeout(() => {
        fetch(`http://localhost:5161/products?page=${this.page}`)
          .then(response => response.json())
          .then(content => {
            this.products = [...this.products, ...content];
            this.loading = false;
          }).catch(() => {
            this.showMore = false;
          });
      }, 1500);

    }
  }
}
</script>
<style scoped>
.product-container {
  display: flex;
  flex-wrap: wrap;
  /* Öğelerin alt satıra geçmesini sağlar */
  gap: 10px;
  /* Öğeler arasındaki boşluk */
  justify-content: flex-start;
  /* Öğeleri eşit dağıt */
  width: 100%;
  /* Container genişliğini %100 yap */
  max-width: 100%;
  /* Genişlik sınırlandırılmasın */
}

.more-container {
  text-align: center;
  margin-top: 20px;
}

.more-container a {
  cursor: pointer;
  font-weight: bold;
}
</style>