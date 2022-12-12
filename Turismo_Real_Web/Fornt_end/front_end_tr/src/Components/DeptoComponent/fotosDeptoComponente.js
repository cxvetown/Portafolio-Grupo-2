import React from "react";
import fotosServ from "../../services/FotosService"

//creamos la clase de depto fotos
class FotosComponente extends React.Component {

    //creamos el constructor con la lista de fotos
    constructor(props) {
        super(props)
        this.state = {
            fotos: []
        }
    }

    //cargamos las fotos
    componentDidMount() {
        let id_fotos = localStorage.getItem("idDeptoFotos")
        fotosServ.getFotos(id_fotos).then((Response) => {
            this.setState({ fotos: Response.data })
            console.log (Response.data)
        });
    }

    render() {

        return (
            <>
                <div class="container">
                    <h1 className="text-center">Fotos del departamento</h1>
                    <table class="table table-fixed">
                        <thead class="table-dark">
                        </thead>
                        <tbody>
                            {
                                this.state.fotos.map(
                                    fotos =>
                                        <tr key={fotos}>
                                            <td><img src={require(`../../imagenes_Dpto/${fotos}.jpg`)} alt={""} style={{ width: "100%", height: "100%", borderRadius: "35px" }}></img></td>
                                       </tr>
                                )
                            }
                        </tbody>
                    </table>
                </div>

            </>
        );

    }
}

export default FotosComponente