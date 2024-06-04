<!-- src/components/MenuSuperior.vue -->
<template>
    <nav class="menu-superior">
        <div class="logo">
            <img src="@/assets/logo.png" alt="Logo" />
        </div>
        <div class="menu-links">
            <router-link to="/" exact>Livros</router-link>
            <router-link to="/usuarios">Usuários</router-link>
            <router-link to="/emprestimos">Empréstimos</router-link>
        </div>
    </nav>
</template>

<style scoped>
    .menu-superior {
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 1em;
        background-color: #ffffff;
        border-bottom: 1px solid #e0e0e0;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        z-index: 1000;
    }

    .logo img {
        height: 40px;
    }

    .menu-links a {
        font-weight: bold;
        color: #888888;
        margin: 0 15px;
        text-decoration: none;
        transition: color 0.3s;
    }

    .menu-links a.router-link-exact-active {
        color: #007bff;
    }

    .menu-links a:hover {
        color: #007bff;
    }
</style>
