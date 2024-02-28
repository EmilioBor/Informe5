import React, { useState, useEffect, Fragment } from "react";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { Container } from "react-bootstrap";
import NuevaNota from "./NuevaNota";
import Filter from "./Filter";

const ListaBonos = () => {
  const [showDetails, setShowDetails] = useState(false);
  const [showEdit, setShowEdit] = useState(false);
  //para el item seleccionado
  const [selectedItem, setSelectedItem] = useState(null);

  const [id, setId] = useState("");
  const [fecha, setFecha] = useState("");
  const [numero, setNumero] = useState("");
  const [idOdontologo, setIdOdontologo] = useState("");
  const [idObraSocial, setIdObraSocial] = useState("");
  const [idPractica, setIdPractica] = useState("");
  const [idPaciente, setIdPaciente] = useState("");

  const [editId, setEditId] = useState("");
  const [editFecha, setEditFecha] = useState("");
  const [editNumero, setEditNumero] = useState("");
  const [editIdOdontologo, setEditIdOdontologo] = useState("");
  const [editIdObraSocial, setEditIdObraSocial] = useState("");
  const [editIdPractica, setEditIdPractica] = useState("");
  const [editIdPaciente, setEditIdPaciente] = useState("");

  // Filter
  const [filteredData, setFilteredData] = useState([]);
  const handleFilterChange = (filteredData) => {
    setFilteredData(filteredData);
  };

  // Data
  const [data, setData] = useState([]);

  useEffect(() => {
    getData();
  }, []);
  const getData = async () => {
    const respuesta = await axios.get("https://localhost:7126/api/Bono");
    try {
      setData(respuesta.data);
    } catch (error) {
      console.log("Error al obtener la información de las notas");
    }
  };
  // Limpiar inputs
  const clear = () => {
    setFecha("");
    setNumero("");
    setIdOdontologo("");
    setIdObraSocial("");
    setIdPractica("");
    setIdPaciente("");

    setEditFecha("");
    setEditNumero("");
    setEditIdOdontologo("");
    setEditIdObraSocial("");
    setEditIdPractica("");
    setEditIdPaciente("");
    setEditId(0);
  };
  // Handle Show
  const handleShowDetails = (item) => {
    setShowDetails(true);
    setSelectedItem(item);
  };
  const handleShowEdit = (item) => {
    setShowEdit(true);
    setSelectedItem(item);
  };
  // Handle Close
  const handleCloseDetails = () => {
    setShowDetails(false);
    setSelectedItem(null);
  };
  const handleCloseEdit = () => {
    setShowEdit(false);
    setSelectedItem(null);
  };
  // Handle Eliminar - Editar - Actualizar
  const handleDelete = (id, numero) => {
    if (window.confirm("Are you sure to delete this note?") === true) {
      axios
        .delete(`https://localhost:7126/Bonos/${id}`)
        .then((result) => {
          if (result.status === 200) {
            toast.success(`${numero} has been deleted`);
            getData();
          }
        })
        .catch((error) => {
          console.log(id);
          console.error("Error deleting note:", error);
          toast.error("Error deleting note. Please try again.");
        });
    }
  };

  const handleEdit = (id) => {
    //para editar notas
    handleShowEdit(true);
    axios
      .get(`https://localhost:7126/Notes/${id}`)
      .then((result) => {
        setEditFecha(result.data.fecha);
        setEditNumero(result.data.numero);
        setEditIdOdontologo(result.data.idOdontologo);
        setEditIdObraSocial(result.data.idObraSocial);
        setEditIdPractica(result.data.idPractica);
        setEditIdPaciente(result.data.idPaciente);
        setEditId(id);
      })
      .catch((error) => {
        toast.error(error);
      });
  };

  const handleUpdate = (title) => {
    const url = `https://localhost:7126/Notes/${editId}`;
    const data = {
      id: editId,
      fecha: editFecha,
      fechaCarga: fechaCarga,
      numero: editNumero,
      idOdontologo: editIdOdontologo,
      idObraSocial: editIdObraSocial,
      idPractica: editIdPractica,
      idPaciente: editIdPaciente,
    };
    axios
      .put(url, data)
      .then((result) => {
        handleCloseEdit();
        getData();
        clear();
        toast.success("Note has been updated");
      })
      .catch((error) => {
        toast.error(error);
      });
  };

  const fechaCarga = new Date();

  return (
    <Fragment>
      {/* <NuevaNota></NuevaNota> */}
      <br />
      <br />

      <Container>
        <Row>
          <Col>
            <Table striped bordered hover>
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
                {data.length > 0
                  ? data.map((item, index) => {
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
                            <button
                              className="btn btn-primary"
                              onClick={() => handleShowDetails(item)}
                            >
                              Details
                            </button>{" "}
                            &nbsp;
                            <button
                              className="btn btn-primary"
                              onClick={() => handleEdit(item.id)}
                            >
                              Edit
                            </button>{" "}
                            &nbsp;
                            <button
                              className="btn btn-danger"
                              onClick={() => handleDelete(item.id, item.numero)}
                            >
                              Delete
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

      {/* // Modal Detalles */}
      {/* <Modal show={showDetails} onHide={handleCloseDetails}>
        <Modal.Header closeButton>
          <Modal.Title>Detalle</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {selectedItem && (
            <div>
              <h6>{selectedItem.description}</h6>
            </div>
          )}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseDetails}>
            Cerrar
          </Button>
        </Modal.Footer>
      </Modal>

        <Modal show={showEdit} onHide={handleCloseEdit}>
            <Modal.Header closeButton>
                <Modal.Title>Editar Bono</Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <Row>
                <Col md={4}>
                    <input type="text" className='form-control' placeholder='Enter Title'
                        value={editTitle} onChange={(e) => setEditTitle(e.target.value)}
                    />
                </Col>
                <Col md={4}>
                    <input type="text" className='form-control' placeholder='Enter Note'
                        value={editDescription} onChange={(e) => setEditDescription(e.target.value)}
                    />
                </Col>
                <Col md={4}>
                    <input type="checkbox" checked={editIsArchive === 1 ? true : false}
                        onChange={(e) => handleEditArchiveChange(e)} value={editIsArchive}
                    />
                    <label>isArchive</label>
                </Col>
            </Row>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleCloseEdit}>
                    Close
                </Button>
                <Button variant="primary" onClick={handleUpdate}>
                    Save Changes
                </Button>
            </Modal.Footer>
        </Modal> */}
    </Fragment>
  );
};
export default ListaBonos;
