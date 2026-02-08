import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/bitcoin-history',
      name: 'bitcoin-history',
      component: () => import('../views/BitcoinHistory.vue'),
    },
    {
      path: '/contact',
      name: 'contact',
      component: () => import('../views/Contact.vue'),
    },
    {
      path: '/countries',
      name: 'countries',
      component: () => import('../views/Countries.vue'),
    },
  ],
})

export default router
