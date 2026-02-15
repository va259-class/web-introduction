<template>
  <h1>Ürünler</h1>
  <table>
    <thead>
      <tr>
        <th>Ürün Adı</th>
        <th>Fiyatı</th>
        <th>Stok Miktarı</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="p in products">
        <td>{{ p.productName }}</td>
        <td>{{ p.unitPrice }}</td>
        <td>{{ p.unitsInStock }}</td>
      </tr>
    </tbody>
  </table>
  <hr />
  <div class="navigation">
    <button @click="previous" :disabled="page == 1">&lt;</button>
    <button @click="next" :disabled="!canNext">&gt;</button>
  </div>
</template>

<script>
export default {
  name: 'Products',
  data() {
    return {
      products: [],
      page: 1,
      canNext: true
    }
  },
  mounted() {
    this.load();
  },
  methods: {
    load() {
      fetch(`http://localhost:5161/products?page=${this.page}`)
        .then(response => response.json())
        .then(content => {
          this.products = content;
        }).catch(() => {
          this.canNext = false;
          this.page--;
        });
    },
    previous() {
      this.page--;
      this.load();
      this.canNext = true;
    },
    next() {
      this.page++;
      this.load();
    }
  }
}
</script>
<style scoped>
table {
  width: 100%;
}

table th {
  text-align: left;
}

.navigation {
  display: flex;
  justify-content: flex-end;
}

.navigation button {
  margin-right: 10px;
}
</style>