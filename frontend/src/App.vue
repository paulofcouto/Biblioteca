<template>
  <div id="app">
    <nav>
        <router-link to="/">Livros</router-link>
        <router-link to="/usuarios">Usuários</router-link>
    </nav>
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'App'
};
</script>

<style>
/* Estilos globais da aplicação */
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

nav {
  padding: 15px;
}

nav a {
  font-weight: bold;
  color: #42b983;
  margin: 0 15px;
}

nav a.router-link-exact-active {
  color: #35495e;
}
</style>
