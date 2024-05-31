import apiClient from './axios';

export default {
  obterTodos(query = '') {
    return apiClient.get(`/livros${query ? `?query=${query}` : ''}`);
  },
  obterPorId(id) {
    return apiClient.get(`/livros/${id}`);
  },
  cadastrar(livro) {
    return apiClient.post('/livros', livro);
  },
  deletar(id) {
    return apiClient.delete(`/livros/${id}`);
  }
};