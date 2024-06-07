<template>
    <div>
        <h1>Empréstimos</h1>
        <table>
            <thead>
                <tr>
                    <th>Livro</th>
                    <th>Usuário</th>
                    <th>Data de Retirada</th>
                    <th>Data de Devolução</th>
                    <th style="width:100px">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="emprestimo in emprestimos" :key="emprestimo.id">
                    <td>{{ emprestimo.tituloLivro }}</td>
                    <td>{{ emprestimo.nomeUsuario }}</td>
                    <td>{{ formatDate(emprestimo.dataDeRetirada) }}</td>
                    <td>{{ formatDate(emprestimo.dataDeDevolucao) }}</td>
                    <span v-if="!emprestimo.dataDeDevolucao" class="devolver-livro" @click="devolverEmprestimo(emprestimo.id)">
                        <i class="fa fa-undo" aria-hidden="true" title="Devolver"></i>
                    </span>
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
        <div v-if="erroModalAberta" class="modal">
            <div class="conteudo-modal">
                <span class="close" @click="fecharModalMensagemRetorno">&times;</span>
                <p style="padding-top: 10px">{{ mensagemErro }}</p>
            </div>
        </div>
    </div>
</template>


<script>
    import emprestimosService from '../services/emprestimosService';
    import usuariosService from '../services/usuariosService';

    export default {
        data() {
            return {
                emprestimos: [],
                usuarios: [],
                livros: [],
                modalAberta: false,
                erroModalAberta : false,
                mensagemErro : '',
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
                    const response = await emprestimosService.obterLivrosDisponiveis();

                    this.livros = response.data || [];
                }
                catch (error) {
                    console.error('Erro ao carregar livros:', error);
                }
            },
            async cadastrarEmprestimo() {
                try {
                    const model = {}

                    model.idLivro = this.novoEmprestimo.idLivro;
                    model.idUsuario = this.novoEmprestimo.idUsuario;

                    if(this.novoEmprestimo.dataDeDevolucaoLimite){
                        model.dataDeDevolucaoLimite = this.novoEmprestimo.dataDeDevolucaoLimite;
                    }

                    await emprestimosService.cadastrar(model);
                   
                    this.fecharModal();
                    
                    this.novoEmprestimo = {
                        idLivro: '',
                        idUsuario: '',
                        dataDeDevolucaoLimite: ''
                    };
                    await this.carregarEmprestimos();
                    await this.carregarLivros();
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
                    var retorno = await emprestimosService.devolver(id);
                    await this.carregarEmprestimos();
                    await this.carregarLivros();
                    
                    this.mostrarMensagemRetorno(retorno.data);
                }
                catch (error) {
                    console.error('Erro ao devolver empréstimo:', error);
                }
            },
            formatDate(dateString) {
                if (!dateString) return ''; 
                const options = { year: 'numeric', month: 'numeric', day: 'numeric' };
                return new Date(dateString).toLocaleDateString(undefined, options);
            },
            mostrarMensagemRetorno(mensagem) {
                this.mensagemErro = mensagem;
                this.erroModalAberta = true;
            },
            fecharModalMensagemRetorno() {
                this.erroModalAberta = false;
                this.mensagemErro = '';
            }
        }
    };
</script>
