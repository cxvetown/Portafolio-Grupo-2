import axios from "axios";

const Depto_Rest_Api_Url = "http://localhost:8080/api/v1/listadoDepto";

class deptoService {

    getDeptos(){
        return axios.get(Depto_Rest_Api_Url);
    }
}

export default new deptoService()