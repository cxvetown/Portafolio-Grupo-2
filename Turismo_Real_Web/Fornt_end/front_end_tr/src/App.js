import './App.css';
import { Navigation } from "./Components/navbar/navbar";
import { Inicio } from "./Pages/Inicio";
import { FormularioLogin } from "./Components/formulario/form_login";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { FormularioRegistrarse } from './Components/formulario/form_registrarse';
import Footer from './Components/Footer/footer';
import clienteContext from './Contexts/ClienteContext';
import { useEffect, useState } from 'react';
import DeptoVista from './Components/DeptoComponent/DeptoCompVista';
import ReservaComponente from './Components/ReservaComponent/ReservaComponente';
import Pago_web from './Components/ReservaComponent/paginaPago';
import ServExtraComponente from './Components/DeptoComponent/ServExtraComponente';
import EditarAcom from './Components/ReservaComponent/editarAcompañantes';
import Deptofotos from './Components/DeptoComponent/fotosDeptoComponente';
import TourComponent from './Components/DeptoComponent/TourComponente';
import DeptoFiltro from './Components/DeptoComponent/DeptoFiltrado';

const getData = () => {
  return localStorage.getItem('correo_usuario')
}
const getDataid = () => {
  return  localStorage.getItem('id_cliente')
}

const initialUsuario = null;

function App() {

  useEffect(() => {
    setUsuario(getData())
    setId(getDataid())
  }, [])

  const logout = () => {
    localStorage.removeItem('correo_usuario')
    localStorage.removeItem('id_cliente')
    setUsuario(null);
    setId(null)
  }

  const [usuario, setUsuario] = useState(initialUsuario)
  const [id, setId] = useState(initialUsuario)

  const data = { usuario, setUsuario, id, setId,  logout }


  return (
    <>
      <div className='page-container'>
        <Router>
          <clienteContext.Provider value={data}>
            <div className='content-warp'>
              <Navigation />
              <Routes>
                <Route path='/ListaReserva' element={<ReservaComponente />}></Route>
                <Route path='/DeptoFiltrado' element={<DeptoFiltro />}></Route>
                <Route path='/Inicio' element={<Inicio />}></Route>
                <Route path='/' exact element={<Inicio />}></Route>
                <Route path='/ReservaDepto/:id_depto' element={<DeptoVista />}></Route>
                <Route path='/portalPago/:id_reserva' element={<Pago_web />}></Route>
                <Route path='/editarAcompanantes/:id_reserva' element={<EditarAcom />}></Route>
                <Route path='/mostrartour/:id_reserva' element={<TourComponent />}></Route>
                <Route path='/mostrarFotos/:id_depto' element={<Deptofotos />}></Route>   
                <Route path='/ListaServExtra/:id_reserva' element={<ServExtraComponente />}></Route>
                <Route path="/Login" element={<FormularioLogin />}></Route>
                <Route path="/Registrarse" element={<FormularioRegistrarse />}></Route>
              </Routes>
            </div>
          </clienteContext.Provider>
        </Router >
        <Footer />
      </div>
      
    </>
  );
}
export default App;
