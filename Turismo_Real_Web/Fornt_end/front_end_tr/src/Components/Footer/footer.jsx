import React from "react";
import './footer.css';
import insta from "../../Img/instagram.png"
import face from "../../Img/facebook.png"
import tw from "../../Img/gorjeo.png"

//creamos la funcion que se renderizara en otra ventana
const Footer = () => {

    return (
        <>
            <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'></link>

            <div id="footer" className="main-footer text-center">
                <div className="container" class="div1">
                    <div className="pt-4">
                        <h4>Turismo real</h4>
                    <h6>© derechos reservados 2022</h6>
                        <a href="https://www.instagram.com/" className="pt-5"><img src={insta}
                            height="50" width="50" alt="" /></a>
                        <a href="https://www.facebook.com/" className="px-3"><img src={face}
                            height="50" width="50" alt="" /></a>
                        <a href="https://www.twitter.com/" className="pt-5"><img src={tw}
                            height="50" width="50" alt="" /></a>                        
                    </div><br></br>
                <div style={{background: "#1687A7"}}>
                    
                </div>
                </div>
            </div>
        </>
    );
};
export default Footer;