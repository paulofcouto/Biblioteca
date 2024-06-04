<template>
    <div>
        <h1>Empréstimos</h1>
        <table>
            <thead>
                <tr>
                    <th>Livro</th>
                    <th>Usuário</th>
                    <th>Data de Devolução</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="emprestimo in emprestimos" :key="emprestimo.id">
                    <td>{{ emprestimo.livro }}</td>
                    <td>{{ emprestimo.usuario }}</td>
                    <td>{{ emprestimo.DataDeDevolucaoLimite }}</td>
                    <td>
                        <button @click="devolverEmprestimo(emprestimo.id)">Devolver</button>
                    </td>
                </tr>
            </tbody>
        </table>

        <button class="botao-adicionar" @click="abrirModal">+</button>

        <!-- Modal para Cadastrar Empréstimo -->
        <div v-if="modalAberta" class="modal">
            <div class="conteudo-modal">
                <span class="close" @click="fecharModal">&times;</span>
                <h3>Cadastrar Empréstimo</h3>
                <form @submit.prevent="cadastrarEmprestimo">
                    <div class="campo-cadastro">
                        <label for="livro">Livro:</label>
                        <select v-model="novoEmprestimo.livro" required>
                            <option v-for="livro in livros" :key="livro.id" :value="livro.id">{{ livro.titulo }}</option>
                        </select>
                    </div>
                    <div class="campo-cadastro">
                        <label for="usuario">Usuário:</label>
                        <select v-model="novoEmprestimo.usuario" required>
                            <option v-for="usuario in usuarios" :key="usuario.id" :value="usuario.id">{{ usuario.nome }}</option>
                        </select>
                    </div>
                    <div class="campo-cadastro">
                        <label for="DataDeDevolucaoLimite">Data de Empréstimo:</label>
                        <input type="date" v-model="novoEmprestimo.DataDeDevolucaoLimite"/>
                    </div>
                    <button class="botao-padrao" type="submit">Cadastrar</button>
                </form>
            </div>
        </div>
    </div>
</template>


<script>
    import emprestimosService from '../services/emprestimosService';
    import usuariosService from '../services/usuariosService';
    import livrosService from '../services/livrosService';

    export default {
        data() {
            return {
                emprestimos: [],
                usuarios: [],
                livros: [],
                modalAberta: false,
                novoEmprestimo: {
                    livro: '',
                    usuario: '',
                    DataDeDevolucaoLimite: ''
                }
            };
        },
        async mounted() {
            await this.carregarEmprestimos();
            await this.carregarUsuarios();
            await this.carregarLivros();
        },
        methods: {
            async carregarEmprestimos() {
                try {
                    const response = await emprestimosService.obterTodos();

                    console.log(response.data)
                    this.emprestimos = response.data || [];
                }
                catch (error) {
                    console.error('Erro ao carregar empréstimos:', error);
                }
            },
            async carregarUsuarios() {
                try {
                    const response = await usuariosService.obterTodos();

                    this.usuarios = response.data || [];
                }
                catch (error) {
                    console.error('Erro ao carregar usuários:', error);
                }
            },
            async carregarLivros() {
                try {
                    const response = await livrosService.obterTodos();

                    this.livros = response.data || [];
                }
                catch (error) {
                    console.error('Erro ao carregar livros:', error);
                }
            },
            async cadastrarEmprestimo() {
                try {
                    await emprestimosService.cadastrar(this.novoEmprestimo);
                    this.fecharModal();
                    this.novoEmprestimo = {
                        livro: '',
                        usuario: '',
                        DataDeDevolucaoLimite: ''
                    };
                    await this.carregarEmprestimos();
                }
                catch (error) {
                    console.error('Erro ao cadastrar empréstimo:', error);
                }
            },
            abrirModal() {
                this.modalAberta = true;
            },
            fecharModal() {
                this.modalAberta = false;
            },
            async devolverEmprestimo(id) {
                try {
                    await emprestimosService.devolver(id);
                    await this.carregarEmprestimos();
                }
                catch (error) {
                    console.error('Erro ao devolver empréstimo:', error);
                }
            }
        }
    };
</script>

<style>


    input {
        border: 1px solid #CCCCCC;
        padding: .5em;
        font-size: 1em;
        width: 100%;
        box-sizing: border-box;
    }

    .close {
        position: absolute;
        top: 10px;
        right: 10px;
        cursor: pointer;
    }

    select {
        border: 1px solid #CCCCCC;
        padding: .5em;
        font-size: 1em;
        width: 100%;
        box-sizing: border-box;
    }
</style>
