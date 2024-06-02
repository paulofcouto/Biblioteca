import { createRouter, createWebHistory } from 'vue-router';
import LivrosList from '../components/LivrosList.vue';
import UsuariosList from '../components/UsuariosList.vue';

const routes = [
    {
        path: '/',
        name: 'LivrosList',
        component: LivrosList
    },
    {
        path: '/usuarios',
        name: 'UsuariosList',
        component: UsuariosList
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
