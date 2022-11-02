import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { NavLink } from "react-router-dom";
import NavDropdown from "react-bootstrap/NavDropdown";
import NavbarBrand from "react-bootstrap/esm/NavbarBrand";
import '../navbar/navbar.css'
import { useContext } from "react";
import clienteContext from "../../Contexts/ClienteContext";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";


export const Navigation = () => {
  let timerInterval
  const MySwal = withReactContent(Swal);

  const handleSwal = () => {
    MySwal.fire({
      title: "¿Desea cerrar sesión?",
      showDenyButton: true,
      confirmButtonText: 'Si',
      denyButtonText: `No`,
    }).then((respuesta) => {
      if (respuesta.isConfirmed) {
        MySwal.fire({
          title: "Cerrando Sesion...",
          timer: "3000",
          showCancelButton: false,
          showConfirmButton: false,
          allowOutsideClick: false,
          didOpen: () => {
            Swal.showLoading()
            const b = Swal.getHtmlContainer().querySelector('b')
            timerInterval = setInterval(() => {
              b.textContent = Swal.getTimerLeft()
            }, 100)
          },
          willClose: () => {
            clearInterval(timerInterval)
          }
        })
        logout()
      }
    })
  }
  const { usuario, logout } = useContext(clienteContext);
  return (
    <Navbar
      className="sticky-top"
      collapseOnSelect
      expand="lg"
      bg=""
      variant="dark"
    >
      <Container>
        <NavbarBrand href="/Inicio"> Turismo Real</NavbarBrand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
          </Nav>
          <Nav>

            {usuario
              ? <NavDropdown
                title={usuario}
                id="collasible-nav-dropdown"
              >
                <NavDropdown.Item href="/ListaReserva">Reservas</NavDropdown.Item>
                <NavDropdown.Item onClick={handleSwal}>Cerrar Sesion</NavDropdown.Item>
              </NavDropdown>

              : <NavLink className="nav-link" to="/Login">
                Iniciar sesión
              </NavLink>
            }
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};