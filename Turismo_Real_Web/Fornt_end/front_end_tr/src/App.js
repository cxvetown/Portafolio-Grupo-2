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
                <Route path='/Inicio' element={<Inicio />}></Route>
                <Route path='/' exact element={<Inicio />}></Route>
                <Route path='/ReservaDepto/:id_depto' element={<DeptoVista />}></Route> 
                <Route path="/Login" element={<FormularioLogin />}></Route>
                <Route path="/Registrarse" element={<FormularioRegistrarse />}></Route>
              </Routes>
              <Footer />
            </div>
          </clienteContext.Provider>
        </Router >
      </div>

    </>
  );
}
export default App;
