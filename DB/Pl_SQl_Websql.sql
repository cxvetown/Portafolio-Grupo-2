set serveroutput on 
/
CREATE OR REPLACE PACKAGE login_web AS
    PROCEDURE CREAR_USUARIO(email_c IN USUARIO.EMAIL%TYPE, pass IN USUARIO.CONTRASEÑA%TYPE, fono IN USUARIO.TELEFONO%TYPE, 
        rut IN CLIENTE.RUT_CLIENTE%TYPE, nombre IN CLIENTE.NOMBRES_CLIENTE%TYPE, apellido IN  CLIENTE.APELLIDOS_CLIENTE%TYPE, R OUT INT);
    PROCEDURE AUTENTIFICAR(email_aut IN USUARIO.email%type, psw_aut IN USUARIO.contraseña%type, R OUT INT);
END login_web;
/
CREATE OR REPLACE PACKAGE BODY login_web AS
    PROCEDURE CREAR_USUARIO(email_c IN USUARIO.EMAIL%TYPE, pass IN USUARIO.CONTRASEÑA%TYPE, fono IN USUARIO.TELEFONO%TYPE, 
        rut IN CLIENTE.RUT_CLIENTE%TYPE, nombre IN CLIENTE.NOMBRES_CLIENTE%TYPE, apellido IN  CLIENTE.APELLIDOS_CLIENTE%TYPE, R OUT INT) 
    IS 
        id_col rowid;
        identificador_usr USUARIO.ID_USUARIO%TYPE;
        identificador_cli CLIENTE.ID_CLIENTE%TYPE;
        v_pass VARCHAR2(40);
        error_crear_usuario EXCEPTION;
        PRAGMA EXCEPTION_INIT(error_crear_usuario, -20001);
        error_crear_cliente EXCEPTION;
        PRAGMA EXCEPTION_INIT(error_crear_cliente, -20101);
    BEGIN 
        SAVEPOINT A;
        v_pass:=GENERAR_CON(email_c, pass);
        INSERT INTO USUARIO(EMAIL, CONTRASEÑA, TELEFONO) VALUES(email_c, v_pass , fono) RETURNING rowid, ID_USUARIO INTO id_col, identificador_usr;
        IF id_col IS NOT NULL THEN
            INSERT INTO CLIENTE(RUT_CLIENTE,NOMBRES_CLIENTE,APELLIDOS_CLIENTE,ID_USUARIO) VALUES(rut, nombre, apellido, identificador_usr) 
                RETURNING rowid,ID_CLIENTE INTO id_col,identificador_cli;
            IF id_col IS NOT NULL THEN
                UPDATE USUARIO SET ID_CLIENTE = identificador_cli WHERE ID_USUARIO = identificador_usr RETURNING 1 INTO r;
                IF r = 1 THEN
                    COMMIT;        
                END IF;
            ELSE 
                RAISE error_crear_cliente;
            END IF;
        ELSE
            RAISE error_crear_usuario;
        END IF;
    EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            ROLLBACK TO A;
            R:= -1;
        WHEN error_crear_usuario THEN 
            ROLLBACK TO A;
            R:= -20001;
        WHEN error_crear_cliente THEN
            ROLLBACK TO A;
            R:= -20101;
    END;
    PROCEDURE AUTENTIFICAR(email_aut IN USUARIO.email%type, psw_aut IN USUARIO.contraseña%type, R OUT INT)
    IS
    v_count number;
    v_pass VARCHAR2(40);
    BEGIN 
        v_pass:=GENERAR_CON(email_aut, psw_aut);
        SELECT cli.id_cliente INTO R
            FROM CLIENTE cli JOIN USUARIO USR ON(cli.id_usuario = usr.id_usuario)
                WHERE usr.email = email_aut and usr.contraseña = v_pass;
    EXCEPTION 
        WHEN No_Data_Found THEN
            DBMS_OUTPUT.PUT_LINE('EL USUARIO NO EXISTE');
            R:= 0;
    END;
END login_web;
/
CREATE OR REPLACE PROCEDURE AGREGAR_RESERVA(idDepto IN RESERVA.ID_DPTO%TYPE, idCli RESERVA.ID_CLIENTE%TYPE,  estadoRes RESERVA.ESTADO_RESERVA%TYPE, 
        estadoPag RESERVA.ESTADO_PAGO%TYPE, checkIn RESERVA.CHECK_IN%TYPE, checkOut RESERVA.CHECK_OUT%TYPE, firmaRes RESERVA.FIRMA%TYPE, cant_acomp RESERVA.CANTIDAD_ACOMPAÑANTES%TYPE, transporte_reserva RESERVA.TRANSPORTE%TYPE, valorTotal RESERVA.VALOR_TOTAL%TYPE, R OUT INTEGER)
    IS
        id_col rowid;
        identificador_RES RESERVA.ID_RESERVA%TYPE;
    BEGIN
        INSERT INTO RESERVA(ID_DPTO, ID_CLIENTE, ESTADO_RESERVA, ESTADO_PAGO, CHECK_IN, CHECK_OUT, FIRMA, CANTIDAD_ACOMPAÑANTES, TRANSPORTE, VALOR_TOTAL) 
            VALUES(idDepto, idCli, estadoRes, estadoPag, checkIn, checkOut, firmaRes, cant_acomp, transporte_reserva,    valorTotal) RETURNING rowid, ID_RESERVA INTO id_col, identificador_RES;
        IF id_col IS NOT NULL THEN
            r:= identificador_RES;
            COMMIT;        
        END IF;
    END;
/
CREATE OR REPLACE PROCEDURE AGREGAR_SERV_EXTRA(ID_RESERVA IN RESERVA_SERVICIOS_EXTRAS.ID_RESERVA%TYPE, ID_SVC IN RESERVA_SERVICIOS_EXTRAS.ID_SVC_EX%TYPE, 
    DPTO RESERVA_SERVICIOS_EXTRAS.ID_DPTO%TYPE, CLIENTE RESERVA_SERVICIOS_EXTRAS.ID_CLIENTE%TYPE, R OUT INTEGER)
    IS
        id_col rowid;
    BEGIN 
        INSERT INTO RESERVA_SERVICIOS_EXTRAS VALUES(ID_RESERVA, ID_SVC, DPTO, CLIENTE) RETURNING rowid INTO id_col;
        IF id_col IS NOT NULL THEN
            r:= 1;
            COMMIT;
        END IF;
    END;
/
CREATE OR REPLACE PROCEDURE AGREGAR_TOUR_RES( id_resv TOUR_RESERVA.ID_RESERVA%TYPE,  id_Tour TOUR_RESERVA.ID_TOUR%TYPE, 
    id_fecha TOUR_RESERVA.FECHA_TOUR%TYPE, id_dpto TOUR_RESERVA.ID_DPTO%TYPE , id_cli TOUR_RESERVA.ID_CLIENTE%TYPE, R OUT INTEGER)
    IS
        id_col rowid;
    BEGIN 
        INSERT INTO TOUR_RESERVA VALUES(id_resv, id_Tour, id_fecha, id_dpto, id_cli) RETURNING rowid INTO id_col;
        IF id_col IS NOT NULL THEN
            r:= 1;
            COMMIT;
        END IF;
    END;
/
DECLARE 
    r integer;
BEGIN
    login_web.CREAR_USUARIO('crisCid12@gmail.com','Turismo_Real22',947347431,'15454761-4', 'Cristian Jonathan','Cid Cid', r);
END;
/
SELECT NOMBRE_DPTO, CHECK_IN, CHECK_OUT, ESTADO_PAGO, VALOR_TOTAL FROM RESERVA RES JOIN DEPARTAMENTO DPTO USING(ID_DPTO);

/*Generar una reserva*/
DECLARE 
    R INTEGER;
BEGIN
    AGREGAR_RESERVA(1, 1,'T','L' ,TO_DATE('06-12-2022', 'DD-MM-YYYY'), TO_DATE('15-12-2022', 'DD-MM-YYYY'), '1',2, 'y', 100000, R);
END;