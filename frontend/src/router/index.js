// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router';
import LivrosList from '../components/LivrosList.vue';

const routes = [
  {
    path: '/',
    name: 'LivrosList',
    component: LivrosList
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
