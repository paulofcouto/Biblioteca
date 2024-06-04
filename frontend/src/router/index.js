import { createRouter, createWebHistory } from 'vue-router';
import LivrosList from '../views/LivrosList.vue';
import UsuariosList from '../views/UsuariosList.vue';
import EmprestimosList from '../views/EmprestimosList.vue';

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
    },
    {
        path: '/emprestimos',
        name: 'EmprestimosList',
        component: EmprestimosList
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
