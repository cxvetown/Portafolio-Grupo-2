import axios from "axios";


class servDeptoServicio{

    getServicios(id_foto){
        return axios.get(`http://localhost:8080/api/v1/lista_servicios_dpto/${id_foto}`);
    }
}

export default new servDeptoServicio()