// src/services/emprestimoService.js
import axios from 'axios';

const API_URL = 'http://localhost:5000/api/emprestimos';

export default {
    obterTodos() {
        return axios.get(`${API_URL}/obterTodos`);
    },
    obterLivrosDisponiveis() {
        return axios.get(`${API_URL}/obterLivrosDisponiveis`);
    },
    cadastrar(emprestimo) {
        return axios.post(API_URL, emprestimo);
    },
    devolver(id) {
        return axios.put(`${API_URL}/${id}/devolver`);
    }
};
