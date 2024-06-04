import axios from 'axios';

const baseURL = 'http://localhost:5000/api/usuarios';

const usuariosService = {
    obterTodos() {
        return axios.get(baseURL);
    },
    cadastrar(usuario) {
        return axios.post(baseURL, usuario);
    }
};

export default usuariosService;
