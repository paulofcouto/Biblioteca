<!-- src/App.vue -->
<template>
    <div id="app">
        <MenuSuperior />
        <router-view />
    </div>
</template>

<script>
    import MenuSuperior from './components/MenuSuperior.vue';

    export default {
        name: 'App',
        components: {
            MenuSuperior
        }
    };
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        padding-top: 60px;
    }
</style>
