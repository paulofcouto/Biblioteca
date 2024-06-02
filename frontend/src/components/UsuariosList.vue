<template>
    <div>
        <h1>Lista de Usuários</h1>
        <button @click="abrirModalUsuario">Cadastrar Usuário</button>
        <table>
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Email</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="usuario in usuarios" :key="usuario.id">
                    <td>{{ usuario.nome }}</td>
                    <td>{{ usuario.email }}</td>
                    <td>
                        <button @click="deletarUsuario(usuario.id)">Deletar</button>
                    </td>
                </tr>
            </tbody>
        </table>

        <!-- Modal para Cadastrar Usuário -->
        <div v-if="modalUsuarioAberta" class="modal">
            <div class="modal-content">
                <span class="close" @click="fecharModalUsuario">&times;</span>
                <h2>Cadastrar Usuário</h2>
                <form @submit.prevent="cadastrarUsuario">
                    <div>
                        <label for="nome">Nome:</label>
                        <input type="text" v-model="novoUsuario.nome" required />
                    </div>
                    <div>
                        <label for="email">Email:</label>
                        <input type="email" v-model="novoUsuario.email" required />
                    </div>
                    <button type="submit">Cadastrar</button>
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
                    } else {
                        console.error('Formato de dados inesperado:', response.data);
                    }
                } catch (error) {
                    console.error('Erro ao carregar usuários:', error);
                }
            },
            async deletarUsuario(id) {
                try {
                    await usuariosService.deletar(id);
                    await this.carregarUsuarios();
                } catch (error) {
                    console.error('Erro ao deletar usuário:', error);
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
    /* Estilos para a modal */
    .modal {
        display: flex;
        justify-content: center;
        align-items: center;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
    }

    .modal-content {
        background-color: #fff;
        padding: 20px;
        border-radius: 4px;
        width: 300px;
        max-width: 100%;
    }

    .close {
        position: absolute;
        top: 10px;
        right: 10px;
        cursor: pointer;
    }
</style>
