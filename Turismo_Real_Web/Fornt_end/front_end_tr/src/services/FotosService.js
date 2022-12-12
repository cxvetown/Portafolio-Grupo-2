import axios from "axios";


class fotosService{

    getFotos(id_depto){
        
        return axios.get(`http://localhost:8080/api/v1/fotosDepartamento/${id_depto}`);
    }
}

export default new fotosService()