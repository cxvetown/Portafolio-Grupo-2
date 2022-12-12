import axios from "axios";


class TourServicio{

    getTours(id_reserva){
        
        return axios.get(`http://localhost:8080/api/v1/tours/${id_reserva}`);
    }
}

export default new TourServicio()