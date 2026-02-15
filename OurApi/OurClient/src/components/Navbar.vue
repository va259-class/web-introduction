<template>
  <nav class="navbar">
    <div class="logo">Northwind</div>

    <button class="menu-btn" @click="toggleMenu">☰</button>

    <ul :class="{ open: isOpen }">
      <li><router-link to="/">Ana Sayfa</router-link></li>
      <li><router-link to="/products">Ürünler</router-link></li>
      <li><router-link to="/categories">Kategoriler</router-link></li>
    </ul>
  </nav>
</template>

<script>
export default {
  data() {
    return {
      isOpen: false,
    }
  },
  methods: {
    toggleMenu() {
      this.isOpen = !this.isOpen
    },
  },
}
</script>

<style scoped>
.navbar {
  display: flex;
  align-items: center;
  justify-content: space-between;
  background: white;
  padding: 1rem;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
}

.logo {
  font-weight: bold;
}

.menu-btn {
  font-size: 1.5rem;
  background: none;
  border: none;
  display: none;
}

ul {
  display: flex;
  gap: 1rem;
  list-style: none;
  padding: 0;
  margin: 0;
}

a {
  text-decoration: none;
  color: #333333;
}

.router-link-active {
  font-weight: bold;
  color: #42b883;
}

/* 📱 Mobile */
@media (max-width: 768px) {
  .menu-btn {
    display: block;
  }

  ul {
    position: absolute;
    top: 64px;
    right: 0;
    background: white;
    flex-direction: column;
    width: 200px;
    padding: 1rem;
    display: none;
  }

  ul.open {
    display: flex;
  }
}
</style>
