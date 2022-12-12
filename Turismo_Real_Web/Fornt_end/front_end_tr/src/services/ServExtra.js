import axios from "axios";


class servExtraService{

    getServExtra(id_reserva){
        
        return axios.get(`http://localhost:8080/api/v1/allService/${id_reserva}`);
    }
}

export default new servExtraService()