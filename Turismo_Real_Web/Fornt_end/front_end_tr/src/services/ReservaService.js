import axios from "axios";


class reservaService{

    getReserva(id){
        
        return axios.get(`http://localhost:8080/api/v1/lista_reserva/${id}`);
    }
}

export default new reservaService()