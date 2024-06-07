<!-- src/views/LivrosList.vue -->
<template>
    <div>
        <h1>Lista de Livros</h1>
        <div class="pesquisa">
            <input  type="text" v-model="filtro" placeholder="Pesquisar por título ou autor" @input="filtrarLivros">
            <button class="botao-padrao" @click="carregarLivros">Pesquisar</button>
        </div>
        <div>
            <table>
                <thead>
                    <tr>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>ISBN</th>
                        <th>Ano de Publicação</th>
                        <th>Status</th>
                        <th style="width:100px">Ações</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="livro in livros" :key="livro.id">
                        <td>{{ livro.titulo }}</td>
                        <td>{{ livro.autor }}</td>
                        <td>{{ livro.isbn }}</td>
                        <td>{{ livro.anoDePublicacao }}</td>
                        <td>{{ livro.status }}</td>
                        <td v-if="!livro.possuiEmprestimo"><span class="icone-deletar" @click="deletarLivro(livro.id)"><i class="fas fa-trash-alt" title="Deletar"></i></span></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <button class="botao-adicionar" @click="abrirModal">+</button>

        <!-- Modal para Cadastrar Livro -->
        <div v-if="modalLivroAberta" class="modal">
            <div class="conteudo-modal">
                <span class="close" @click="fecharModal">&times;</span>
                <h3>Cadastrar Livro</h3>
                <form @submit.prevent="cadastrarLivro">
                    <div class="campo-cadastro">
                        <label for="titulo">Título:</label>
                        <input type="text" v-model="novoLivro.titulo" required />
                    </div>
                    <div class="campo-cadastro">
                        <label for="autor">Autor:</label>
                        <input type="text" v-model="novoLivro.autor" required />
                    </div>
                    <div class="campo-cadastro">
                        <label for="isbn">ISBN:</label>
                        <input type="text" v-model="novoLivro.isbn" required />
                    </div>
                    <div class="campo-cadastro">
                        <label for="anoDePublicacao">Ano de Publicação:</label>
                        <input type="number" v-model.number="novoLivro.anoDePublicacao" @input="validarAnoDePublicacao" required />
                    </div>
                    <button class="botao-padrao" type="submit">Cadastrar</button>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
    import livrosService from '../services/livrosService';

    export default {
        data() {
            return {
                livros: [],
                modalLivroAberta: false,
                novoLivro: {
                    titulo: '',
                    autor: '',
                    isbn: '',
                    anoDePublicacao: 0,
                    status : '',
                    possuiEmprestimo : false
                },
                filtro: ''
            };
        },
        async mounted() {
            await this.carregarLivros();
        },
        methods: {
            async carregarLivros() {
                try {
                    const response = await livrosService.obterTodos(this.filtro);
                    if (response.data && Array.isArray(response.data)) {
                        this.livros = response.data.filter(livro => livro && livro.id);
                    }
                    else {
                        console.error('Formato de dados inesperado:', response.data);
                    }
                }
                catch (error) {
                    console.error('Erro ao carregar livros:', error);
                }
            },
            async deletarLivro(id) {
                try {
                    await livrosService.deletar(id);
                    await this.carregarLivros();
                } 
                catch (error) {
                    console.error('Erro ao deletar livro:', error);
                }
            },
            abrirModal() {
                this.modalLivroAberta = true;
            },
            fecharModal() {
                this.modalLivroAberta = false;
            },
            async cadastrarLivro() {
                try {
                    await livrosService.cadastrar(this.novoLivro);
                    this.fecharModal();
                    this.novoLivro = {
                        titulo: '',
                        autor: '',
                        isbn: '',
                        anoDePublicacao: 0
                    };
                    await this.carregarLivros();
                } 
                catch (error) {
                    console.error('Erro ao cadastrar livro:', error);
                }
            },
            validarAnoDePublicacao() {
                if (this.novoLivro.anoDePublicacao < 0) {
                    this.novoLivro.anoDePublicacao = 0;
                }
            }
        }
    };
</script>

