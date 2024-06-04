<!-- src/views/LivrosList.vue -->
<template>
    <div>
        <h1>Lista de Livros</h1>
        <div class="conteudo-tabela">
            <table>
                <thead class="cabecalho-tabela">
                    <tr>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>ISBN</th>
                        <th>Ano de Publicação</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="livro in livros" :key="livro.id">
                        <td>{{ livro.titulo }}</td>
                        <td>{{ livro.autor }}</td>
                        <td>{{ livro.isbn }}</td>
                        <td>{{ livro.anoDePublicacao }}</td>
                        <td><button @click="deletarLivro(livro.id)">Deletar</button></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <button class="botao-adicionar" @click="abrirModal">+</button>

        <!-- Modal para Cadastrar Livro -->
        <div v-if="modalAberta" class="modal">
            <div class="conteudo-modal">
                <div class="close" @click="fecharModal">&times;</div>
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
                        <input type="number" v-model="novoLivro.anoDePublicacao" required />
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
                modalAberta: false,
                novoLivro: {
                    titulo: '',
                    autor: '',
                    isbn: '',
                    anoDePublicacao: 0
                }
            };
        },
        async mounted() {
            await this.carregarLivros();
        },
        methods: {
            async carregarLivros() {
                try {
                    const response = await livrosService.obterTodos();
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
                } catch (error) {
                    console.error('Erro ao deletar livro:', error);
                }
            },
            abrirModal() {
                this.modalAberta = true;
            },
            fecharModal() {
                this.modalAberta = false;
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
                } catch (error) {
                    console.error('Erro ao cadastrar livro:', error);
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

    table {
        width: calc(100% - 8em);
        margin: 8em 4em;
        border-collapse: collapse;
    }

    thead th, tbody td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: left;
    }

    thead th {
        background-color: #f2f2f2;
    }

    .cabecalho-tabela {
        border: none;
        border: 2px solid gray;
        border-top-right-radius: 20px;
    }
</style>
