<!-- src/views/UsuariosList.vue -->
<template>
    <div>
        <h1>Lista de Usuários</h1>
        <div class="conteudo-tabela">
            <table>
                <thead class="cabecalho-tabela">
                    <tr>
                        <th>Nome</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="usuario in usuarios" :key="usuario.id">
                        <td>{{ usuario.nome }}</td>
                        <td>{{ usuario.email }}</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <button class="botao-adicionar" @click="abrirModalUsuario">+</button>


        <!-- Modal para Cadastrar Usuário -->
        <div v-if="modalUsuarioAberta" class="modal">
            <div class="conteudo-modal">
                <span class="close" @click="fecharModalUsuario">&times;</span>
                <h3>Cadastrar Usuário</h3>
                <form @submit.prevent="cadastrarUsuario">
                    <div class="campo-cadastro">
                        <label for="nome">Nome:</label>
                        <input type="text" v-model="novoUsuario.nome" required />
                    </div>
                    <div class="campo-cadastro">
                        <label for="email">Email:</label>
                        <input type="email" v-model="novoUsuario.email" required />
                    </div>
                    <button class="botao-padrao" type="submit">Cadastrar</button>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
    import usuariosService from '../services/usuariosService';

    export default {
        data() {
            return {
                usuarios: [],
                modalUsuarioAberta: false,
                novoUsuario: {
                    nome: '',
                    email: ''
                }
            };
        },
        async mounted() {
            await this.carregarUsuarios();
        },
        methods: {
            async carregarUsuarios() {
                try {
                    const response = await usuariosService.obterTodos();
                    if (response.data && Array.isArray(response.data)) {
                        this.usuarios = response.data.filter(usuario => usuario && usuario.id);
                    } 
                    else {
                        console.error('Formato de dados inesperado:', response.data);
                    }
                } 
                catch (error) {
                    console.error('Erro ao carregar usuários:', error);
                }
            },
            abrirModalUsuario() {
                this.modalUsuarioAberta = true;
            },
            fecharModalUsuario() {
                this.modalUsuarioAberta = false;
            },
            async cadastrarUsuario() {
                try {
                    await usuariosService.cadastrar(this.novoUsuario);
                    this.fecharModalUsuario();
                    this.novoUsuario = {
                        nome: '',
                        email: ''
                    };
                    await this.carregarUsuarios();
                } catch (error) {
                    console.error('Erro ao cadastrar usuário:', error);
                }
            }
        }
    };
</script>

<style>
    .close {
        position: absolute;
        top: 10px;
        right: 10px;
        cursor: pointer;
    }
</style>
