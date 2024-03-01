import React, { useState, useEffect, Fragment } from "react";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { Container } from "react-bootstrap";

const ListaBonos = () => {
  const [data, setData] = useState([]);
  const [filteredData, setFilteredData] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    getData();
  }, []);

  const getData = async () => {
    try {
      const respuesta = await axios.get("https://localhost:7126/api/Bono");
      setData(respuesta.data);
    } catch (error) {
      console.log("Error al obtener la información de las notas");
    }
  };

  useEffect(() => {
    setFilteredData(
      data.filter(item =>
        item.numero.toString().toLowerCase().includes(searchTerm.toLowerCase())
      )
    );
    
  }, [searchTerm, data]);

  const handleSearchTermChange = (e) => {
    setSearchTerm(e.target.value);
  };

  return (
    <Fragment>
      <br />
      <Container>
        <Row>
          <Col>
            <input
              type="text"
              placeholder="Busqueda por numero"
              value={searchTerm}
              onChange={handleSearchTermChange}
              className=" form-control mt-2"
              style={{ width: '400px' }}
            />
            <Table striped bordered hover className="mt-5">
              <thead>
                <tr>
                  <th>Numero</th>
                  <th>Odontologo</th>
                  <th>Obra Social</th>
                  <th>Paciente</th>
                  <th>Practica</th>
                  <th>Fecha</th>
                  <th>Fecha de Carga</th>
                  <th>Estado</th>
                  <th>Acciones</th>
                </tr>
              </thead>
              <tbody>
                {filteredData.length > 0
                  ? filteredData.map((item, index) => {
                      return (
                        <tr key={index}>
                          <td>{item.numero}</td>
                          <td>{item.nombreOdontologo}</td>
                          <td>{item.nombreObraSocial}</td>
                          <td>{item.nombrePaciente}</td>
                          <td>{item.nombrePractica}</td>
                          <td>{item.fecha}</td>
                          <td>{item.fechaCarga}</td>
                          <td>{item.nombreBonoEstado}</td>
                          <td colSpan={2}>
                          <button className="btn btn-primary btn-sm">
                              Detalles
                            </button>{" "}
                            &nbsp;
                            <button className="btn btn-primary btn-sm">
                              Editar
                            </button>{" "}
                            &nbsp;
                            <button className="btn btn-danger btn-sm">
                              Eliminar
                            </button>{" "}
                            &nbsp;
                          </td>
                        </tr>
                      );
                    })
                  : "Cargando bonos..."}
              </tbody>
            </Table>
          </Col>
        </Row>
      </Container>
    </Fragment>
  );
};

export default ListaBonos;
