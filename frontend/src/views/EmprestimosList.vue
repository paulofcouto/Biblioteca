<template>
    <div>
        <h1>Empréstimos</h1>
        <table>
            <thead>
                <tr>
                    <th>Livro</th>
                    <th>Usuário</th>
                    <th>Data de Devolução</th>
                    <th style="width:100px">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="emprestimo in emprestimos" :key="emprestimo.id">
                    <td>{{ emprestimo.tituloLivro }}</td>
                    <td>{{ emprestimo.nomeUsuario }}</td>
                    <td>{{ emprestimo.dataDeDevolucaoLimite }}</td>
                    <td><span class="devolver-livro" @click="devolverEmprestimo(emprestimo.id)"><i class="fa fa-undo" aria-hidden="true"></i></span></td>
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
                        <select v-model="novoEmprestimo.idLivro" required>
                            <option v-for="livro in livros" :key="livro.id" :value="livro.id">{{ livro.titulo }}</option>
                        </select>
                    </div>
                    <div class="campo-cadastro">
                        <label for="usuario">Usuário:</label>
                        <select v-model="novoEmprestimo.idUsuario" required>
                            <option v-for="usuario in usuarios" :key="usuario.id" :value="usuario.id">{{ usuario.nome }}</option>
                        </select>
                    </div>
                    <div class="campo-cadastro">
                        <label for="dataDeDevolucaoLimite">Data de Empréstimo:</label>
                        <input type="date" v-model="novoEmprestimo.dataDeDevolucaoLimite"/>
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
                    idLivro: '', 
                    idUsuario: '',
                    dataDeDevolucaoLimite: ''
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
                    console.log(this.novoEmprestimo.IdLivro);
                    console.log(this.novoEmprestimo);
                    
                    await emprestimosService.cadastrar(this.novoEmprestimo);
                   
                    this.fecharModal();
                    
                    this.novoEmprestimo = {
                        idLivro: '',
                        idUsuario: '',
                        dataDeDevolucaoLimite: ''
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
