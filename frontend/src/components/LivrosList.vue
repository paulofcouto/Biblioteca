<template>
    <div class="tela-padrao">
        <h1>Lista de Livros</h1>
        <div class="conteudo-tabela">
            <table>
                <thead>
                    <tr class="cabecalho-tabela">
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

        <button class="cadastrar-button" @click="abrirModal">+</button>

        <!-- Modal para Cadastrar Livro -->
        <div v-if="modalAberta" class="modal">
            <div class="modal-content">
                <span class="close" @click="fecharModal">&times;</span>
                <h2>Cadastrar Livro</h2>
                <form @submit.prevent="cadastrarLivro">
                    <div>
                        <label for="titulo">Título:</label>
                        <input type="text" v-model="novoLivro.titulo" required />
                    </div>
                    <div>
                        <label for="autor">Autor:</label>
                        <input type="text" v-model="novoLivro.autor" required />
                    </div>
                    <div>
                        <label for="isbn">ISBN:</label>
                        <input type="text" v-model="novoLivro.isbn" required />
                    </div>
                    <div>
                        <label for="anoDePublicacao">Ano de Publicação:</label>
                        <input type="number" v-model="novoLivro.anoDePublicacao" required />
                    </div>
                    <button type="submit">Cadastrar</button>
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
        if (response.data && Array.isArray(response.data.result)) {
          this.livros = response.data.result.filter(livro => livro && livro.id);
        } else {
          console.error('Formato de dados inesperado:', response.data);
        }
      } catch (error) {
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

    .cadastrar-button {
        position: fixed;
        bottom: 2em;
        right: 2em;
        width: 50px;
        height: 50px;
        background-color: #007bff;
        color: #fff;
        font-size: 24px;
        border: none;
        border-radius: 50%;
        cursor: pointer;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }

    .cadastrar-button:hover,
    .cadastrar-button:focus {
            background-color: #0056b3;
            outline: none;
        }

    .conteudo-tabela{
        margin : 1em 4em
    }

    .cabecalho-tabela {
        border: 10px solid green;
        border-radius: 5px;
    }

    /* Estilos para a tabela */
    table thead th {
        margin: 0px;
        width: 100%;
    }

    th, td {
        text-align: left;
        padding: 10px;

    }

    th {
        background-color: #f2f2f2;
    }
</style>
