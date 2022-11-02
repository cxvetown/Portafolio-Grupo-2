import { Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export const CardComponent = ({ idDepto, nombreDepto, NumeroDepto, capacidad, tarifa, direccion, comuna, foto_path }) => {

  return (
    <>
      <Col>
        <div className="card mt-3" >
          <img src={require(`../../imagenes_Dpto/${foto_path}.jpg`)} alt=".." className="card-img-top" style={{ maxWidth: "100%", height: "20rem" }} />
          <div className="card-body text text-right">
            <h5>{nombreDepto}</h5>
            <p className="card-text">
              Capacidad: {capacidad} <br />
              Tarifa diaria: {tarifa} <br />
              Numero Departamento: {NumeroDepto} <br />
              Direccion: {direccion} <br />
              Comuna: {comuna}  <br />
              <br />
              <Link to={`/ReservaDepto/${idDepto}`} >
                <a className="btn btn-primary">Reserva</a>
              </Link>
              <br />
            </p>
          </div>
        </div>
      </Col>
    </>
  );
};
