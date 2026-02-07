<template>
  <div class="container">
    <h1>Firmalar</h1>
    <div>
      <table class="table">
        <thead>
          <tr>
            <th>Firma Adı</th>
            <th>İrtibat Numarası</th>
            <th>Ülkesi</th>
            <th>Hizmet Yılı</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="company in companies" :key="company.id">
            <td>{{ company.name }}</td>
            <td>{{ company.phone }}</td>
            <td>{{ company.country }}</td>
            <td>{{ company.year }}</td>
            <td>
              <button @click="() => remove(company.id)">Sil</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
export default {
  name: "Companies",
  data() {
    return {
      companies: [],
    }
  },
  mounted() {
    this.companies.push({ id: 1, name: "Can Nakliyat", country: "Türkiye", phone: "+903125554477", year: 13});
    this.companies.push({ id: 2, name: "Kübra Nakliyat", country: "Yunanistan", phone: "+903333354477", year: 21});
    this.companies.push({ id: 3, name: "Kenan Nakliyat", country: "Bulgaristan", phone: "+909999954477", year: 3});
    this.companies.push({ id: 4, name: "Akif Nakliyat", country: "Irak", phone: "+901111154477", year: 8});
    this.companies.push({ id: 5, name: "Sude Nakliyat", country: "İran", phone: "+902222254477", year: 12});
  },
  methods: {
    remove(id) {
      this.companies = this.companies.filter(f => f.id != id);
    }
  }
}
</script>

<style scoped>
.table {
  width: 100%;
  border-collapse: collapse;
}

.table thead th {
  font-weight: bold;
  font-size: 14px;
  text-align: left;
}

.table tr {
  border-bottom: 1px solid #999999;
}

.table tr td, th {
  padding: 5px;
}
</style>