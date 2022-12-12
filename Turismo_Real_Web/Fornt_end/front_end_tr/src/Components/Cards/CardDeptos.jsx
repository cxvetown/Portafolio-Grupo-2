import { Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import "../Cards/card.css"
//exportamos el componente con los parametros de cada depto
export const CardComponent = ({ idDepto, nombreDepto, NumeroDepto, capacidad, tarifa, direccion, comuna, foto_path }) => {

  const handleload = (id_dpto) =>{
    window.location.replace(`/ReservaDepto/${idDepto}`);
  }
  //devolvemos el codigo HTML con la Card por defecto que sera llenada con los parametros de la funcion
  return (
    <>
    <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'></link>
      <button class="btn" onClick={() => handleload(idDepto)}><Col>
        <div className="card mt-3" style={{background: "#F6F5F5"}}>
          <img src={require(`../../imagenes_Dpto/${foto_path}.jpg`)} alt=".." className="card-img-top" style={{ maxWidth: "100%", height: "18rem"}} />
          <div className="card-body text text-right">
            <b style={{color: "#1687A7"}}><h4>{nombreDepto}, {direccion}</h4></b>
            <p className="card-text">
              <p style={{color: "#1687A7"}}>
                <b>${tarifa} CLP </b>
                <font style={{fontSize:"17px"}}>noche</font>
              </p>
            </p>
          </div>
        </div>
      </Col></button>
    </>
  );
};
