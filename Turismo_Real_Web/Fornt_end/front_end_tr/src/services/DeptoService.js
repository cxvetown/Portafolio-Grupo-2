import axios from "axios";

const Depto_Rest_Api_Url = "http://localhost:8080/api/v1/listadoDepto";

class deptoService {

    getDeptos(){
        return axios.get(Depto_Rest_Api_Url);
    }

    getDeptoFiltrado(id_com, check_in1, check_out1){
        return axios.get("http://localhost:8080/api/v1/deptoFiltrados", {
            id_comuna: id_com, check_in: check_in1, check_out: check_out1
        })
    }
}

export default new deptoService()