import axios from 'axios';

const baseURL = 'http://localhost:5000/api/usuarios'; // Altere para a URL correta da sua API

const usuariosService = {
    obterTodos() {
        return axios.get(baseURL);
    },
    cadastrar(usuario) {
        return axios.post(baseURL, usuario);
    },
    deletar(id) {
        return axios.delete(`${baseURL}/${id}`);
    }
};

export default usuariosService;
