import React, { useState, useEffect } from 'react';
import { Form, Button, InputGroup, Dropdown, DropdownButton, Col, Row, Container, Modal } from 'react-bootstrap';
import DatePicker from "react-datepicker";
import { FaCalendarAlt } from 'react-icons/fa';
import 'bootstrap/dist/css/bootstrap.min.css';
import "react-datepicker/dist/react-datepicker.css";
import './PostBono.css';
import { toast, ToastContainer } from 'react-toastify';

import axios from 'axios';


function CustomImput({ value, onClick }) {
  return (
    <div className='input-group'>
      <input type='text' className='form-control' value={value} onClick={onClick} readOnly></input>
      <div className='input-group-append'>
        <span className='input-group-text'>
          <FaCalendarAlt />
        </span>
      </div>
    </div>
  )
}


const PostBono = () => {
  const[numeroBono, setNumeroBono] = useState("");

  const [selectedDate, setSelectedDate] = useState(null)
  const [fechaHoy, setFechaHoy] = useState(new Date());
  // Search Odontologos
  const [searchOdontologo, setSearchOdontologo] = useState("")

  const [dataOdontologo, setDataOdontologo] = useState([]);
  const [odontologoSeleccionado, setOdontologoSeleccionado] = useState(''); // Estado para el odontologo seleccionado
  const [idOdontologo, setIdOdontologo] = useState('')

  const [showOdontologos, setShowOdontologos] = useState(false);
  const handleCloseOdontologos = () => setShowOdontologos(false);
  const handleShowOdontologos = () => setShowOdontologos(true);
  // Search Pacientes
  const [searchPaciente, setSearchPaciente] = useState("")

  const [dataPaciente, setDataPaciente] = useState([]);
  const [pacienteSeleccionado, setPacienteSeleccionado] = useState(''); // Estado para el odontologo seleccionado
  const [idPaciente, setIdPaciente] = useState('')

  const [showPacientes, setShowPacientes] = useState(false);
  const handleClosePacientes = () => setShowPacientes(false);
  const handleShowPacientes = () => setShowPacientes(true);
  //
  const [dataObraSocial, setDataObraSocial] = useState([]);
  const [obraSocialSeleccionada, setObraSocialSeleccionada] = useState(''); // Estado para el odontologo seleccionado
  const [idObraSocial, setIdObraSocial] = useState('')
  const [showObraSociales, setShowObraSociales] = useState(false);

  const [dataPractica, setDataPractica] = useState([]);
  const [practicaSeleccionada, setPracticaSeleccionada] = useState(''); // Estado para el odontologo seleccionado
  const [idPractica, setIdPractica] = useState('')
  useEffect(() => {
    getDataOdontologos();
    getDataObraSocial();
    getDataPractica();
    getDataPaciente();
    // Obtener la fecha actual
    const today = new Date();
    setFechaHoy(today);
  }, [])

  const getDataOdontologos = () => {
    axios.get('https://localhost:7126/api/Odontologo')
      .then((result) => {
        const dataWithIdsOdontologos = result.data.map((odontologo, indexOdontologo) => ({ id: indexOdontologo + 1, apellido: odontologo.apellido }));
        setDataOdontologo(dataWithIdsOdontologos);
      })
      .catch((error) => {
        console.log("Error al obtener la información de los odontologos");
      });
  }
  const getDataObraSocial = () => {
    axios.get('https://localhost:7126/api/ObraSocial')
      .then((result) => {
        const dataWithIdsObraSocial = result.data.map((obraSocial, indexObraSocial) => ({ id: indexObraSocial + 1, nombre: obraSocial.nombre }));
        setDataObraSocial(dataWithIdsObraSocial);
      })
      .catch((error) => {
        console.log("Error al obtener la información de la obra social");
      });
  }
  const getDataPractica = () => {
    axios.get('https://localhost:7126/api/Practica')
      .then((result) => {
        const dataWithIdsPractica = result.data.map((practica, indexPractica) => ({ id: indexPractica + 1, nombre: practica.nombre }));
        setDataPractica(dataWithIdsPractica);
      })
      .catch((error) => {
        console.log("Error al obtener la información de las practicas");
      });
  }
  const getDataPaciente = () => {
    axios.get('https://localhost:7126/api/Paciente')
      .then((result) => {
        const dataWithIdsPaciente = result.data.map((paciente, indexPaciente) => ({ id: indexPaciente + 1, nombre: paciente.nombre }));
        setDataPaciente(dataWithIdsPaciente);
      })
      .catch((error) => {
        console.log("Error al obtener la información de los pacientes");
      });
  }

// ODONTOLOGO
  const handleChangeIdOdontologo = (odontologo) => {
    setIdOdontologo(odontologo.id);
    handleOdontologoSeleccionado(odontologo.nombre);
    console.log("Este id es del odontologo:", odontologo.id)
  };
  // Para que el nombre del dropdown cambie cuando se selecciona el odontologo
  // Más visual que otra cosa
  const handleOdontologoSeleccionado = (odontologo) => {
    setOdontologoSeleccionado(odontologo)
  }
// OBRA SOCIAL
  const handleChangeIdObraSocial = (obraSocial) => {
    setIdObraSocial(obraSocial.id);
    handleObraSocialSeleccionada(obraSocial.nombre);
    console.log("Este id es de la obra social:", obraSocial.id)
  };
  // Para que el nombre del dropdown cambie cuando se selecciona la obra social
  // Más visual que otra cosa
  const handleObraSocialSeleccionada = (obraSocial) => {
    setObraSocialSeleccionada(obraSocial)
  }
// PRACTICA
  const handleChangeIdPractica = (practica) => {
    setIdPractica(practica.id);
    handlePracticaSeleccionada(practica.nombre);
    console.log("Este id es del practica:", practica.id)
  };
  // Para que el nombre del dropdown cambie cuando se selecciona el practica
  // Más visual que otra cosa
  const handlePracticaSeleccionada = (practica) => {
    setPracticaSeleccionada(practica)
  }
// PACIENTE
  const handleChangeIdPaciente = (paciente) => {
    setIdPaciente(paciente.id);
    handlePacienteSeleccionada(paciente.nombre);
    console.log("Este id es del paciente:", paciente.id)
  };
  // Para que el nombre del dropdown cambie cuando se selecciona el practica
  // Más visual que otra cosa
  const handlePacienteSeleccionada = (paciente) => {
    setPacienteSeleccionado(paciente)
  }

  //FUNCION DE BUSQUEDA ODONTOLOGO----------
  const searcherOdontologo = (e) => {
    setSearchOdontologo(e.target.value)
    console.log(e.target.value)
  }
  //MÉTODO FILTRADO ODONTOLOGO----------
  let resultsOdontologo = [];
  if (!searchOdontologo) {
    resultsOdontologo = dataOdontologo
  } else {
    resultsOdontologo = dataOdontologo.filter((dato) =>
      dato.nombre.toLowerCase().includes(searchOdontologo.toLowerCase())
    )
  }

   //FUNCION DE BUSQUEDA PACIENTE----------
   const searcherPaciente = (e) => {
    setSearchPaciente(e.target.value)
    console.log(e.target.value)
  }
  //MÉTODO FILTRADO PACIENTE----------
  let resultsPaciente = [];
  if (!searchPaciente) {
    resultsPaciente = dataPaciente
  } else {
    resultsPaciente = dataPaciente.filter((dato) =>
      dato.nombre.toLowerCase().includes(searchPaciente.toLowerCase())
    )
  }

  const handleDateChange = (date) => {

    const formattedDateSelected = date.toISOString();
    console.log("Fecha seleccionada:", formattedDateSelected);
    setSelectedDate(date.toISOString());
    const formattedDateToday = fechaHoy.toISOString()
    setFechaHoy(fechaHoy.toISOString())
    console.log("Fecha de hoy:", formattedDateToday);

  };
//FUNCION PARA CANCELAR LA CARGA BONO----------
const CancelarCarga = () => {
  window.history.back();
}

  //funcion para manejar cambios en el campo de entrada del bono
  const handleChangeNumeroBono = async (e) => {
    const nuevoNumeroBono = e.target.value; //almaceno el bono que escribi
    setNumeroBono(nuevoNumeroBono); //modifico el valor del bono
  };

  const realizarCargaBono = async () =>{
    const dataBono = {
      Id:0,
      Fecha: selectedDate,
      FechaCarga: fechaHoy,
      Numero: numeroBono,
      IdOdontologo: idOdontologo,
      IdObraSocial: idObraSocial,
      IdPractica: idPractica,
      IdPaciente : idPaciente,
      IdBonoEstado: 4
    }
    console.log(dataBono);
    try {
      const response = await axios.post('https://localhost:7126/api/Bono',dataBono);
      console.log('Respuesta del bono:', response.data);

      // Muestra un mensaje de éxito utilizando react-toastify
      toast.success('Carga de bono realizada con éxito')
    } catch (error) {
      console.error('Error al realizar la carga:', error.message);
      // Muestra un mensaje de error utilizando react-toastify
      toast.error('Error al realizar la carga');
    }
  }

  return (
    <div>
      <ToastContainer></ToastContainer>
      <div className='container'>
        <div className='row'>
          <div className='col'>
            <Form  >
              <Form.Group as={Col} controlId="validationCustom02">
                <Form.Label>Número de Bono</Form.Label>
                <Form.Control
                  type="number"
                  placeholder="Ingrese el número del bono"
                  name="numero"
                  value={numeroBono}
                  onChange={handleChangeNumeroBono}
                  required
                />
                <br></br>
                <label>
                  Fecha
                  <br></br>
                  <DatePicker selected={selectedDate} onChange={handleDateChange} customInput={<CustomImput />} />
                </label>
              </Form.Group>
              <br></br>
              <Form.Group as={Col} controlId="validationCustom01">
                <Form.Label>Odontólogo</Form.Label>
                <Form.Group as={Col} controlId='validationCustom01'>
                  <Button variant="outline-secondary" id="button-addon2" onClick={handleShowOdontologos}>
                    Buscar odontologos
                  </Button>
                  <Modal show={showOdontologos} onHide={handleCloseOdontologos}>
                    <Modal.Header closeButton>
                      <Container>
                        <Row>
                          <Col>
                            <Modal.Title>Odontologos</Modal.Title>
                          </Col>
                          <Col>
                            <InputGroup className="">
                              <Form.Control
                                value={searchOdontologo}
                                onChange={searcherOdontologo}
                                placeholder="Buscar odontologo"
                                aria-label="Buscar odontologo"
                                aria-describedby="basic-addon1"
                              />
                            </InputGroup>
                          </Col>
                        </Row>
                      </Container>

                    </Modal.Header>
                    <Modal.Body className="grid-example">
                      <Container>
                        {/* results son los resultados del filtrado en el searchOdontologo */}
                        {resultsOdontologo.map((item, index) => (
                          <Row key={index}>
                            <Col xs={12} md={6}>
                              {item.apellido}
                            </Col>
                            <Col xs={6} md={6} className='d-flex justify-content-end'>
                              {<Button className='mb-2' variant="success" size="sm" onClick={() => {
                                handleChangeIdOdontologo(item)

                                handleCloseOdontologos();
                              }}
                              >
                                Seleccionar</Button>}&nbsp;
                            </Col>
                            <hr></hr>
                          </Row>
                        ))}
                      </Container>
                    </Modal.Body>
                    <Modal.Footer>
                      <Button variant="secondary" onClick={handleCloseOdontologos}>
                        Close
                      </Button>
                    </Modal.Footer>
                  </Modal>
                </Form.Group>
              </Form.Group>
              <br></br>
              <Form.Group as={Col} controlId="validationCustom01">
                <Form.Label>Obra Social</Form.Label>
              </Form.Group>
              <Form.Group as={Col} controlId='validationCustom01'>
                <DropdownButton id="dropdown-basic-button" title={obraSocialSeleccionada || 'Seleccionar Obra Social'}>
                  {dataObraSocial.map((obraSocial, index) => (
                    <Dropdown.Item key={index} onClick={() => handleChangeIdObraSocial(obraSocial)}>
                      {obraSocial.nombre}
                    </Dropdown.Item>
                  ))}
                </DropdownButton>
              </Form.Group>
            </Form>
          </div>
          <div className='col'>
            <Form>

              <label>
                Fecha de carga
                <br></br>
                <DatePicker
                  selected={fechaHoy}
                  disabled={true} // Deshabilitar el cambio de fecha
                />
              </label>
              <br></br>

              <Form.Group as={Col} controlId="validationCustom02">
                <br></br>
                <Form.Label>Estado</Form.Label>
                <br></br>
                <select disabled>
                  <option value="ingresado">Ingresado</option>
                  <option value="otroValor">Otro Valor</option>
                  {/* Agrega más opciones según sea necesario */}
                </select>

              </Form.Group>
              <br></br>
              <Form.Group as={Col} controlId="validationCustom01">
                <Form.Label>Practica</Form.Label>
                <DropdownButton id="dropdown-basic-button" title={practicaSeleccionada || 'Seleccionar Práctica'}>
                  {dataPractica.map((practica, index) => (
                    <Dropdown.Item key={index} onClick={() => handleChangeIdPractica(practica)}>
                      {practica.nombre}
                    </Dropdown.Item>
                  ))}
                </DropdownButton>
                <Form.Control.Feedback type="invalid">
                  Por favor, ingrese una referencia.
                </Form.Control.Feedback>
                <Form.Control.Feedback type="valid">
                  Looks good!
                </Form.Control.Feedback>
              </Form.Group>
              <br></br>
              <Form.Group as={Col} controlId="validationCustom01">
                <Form.Label>Paciente</Form.Label>
              </Form.Group>
              <Form.Group as={Col} controlId='validationCustom01'>
                  <Button variant="outline-secondary" id="button-addon2" onClick={handleShowPacientes}>
                    Buscar pacientes
                  </Button>
                  <Modal show={showPacientes} onHide={handleClosePacientes}>
                    <Modal.Header closeButton>
                      <Container>
                        <Row>
                          <Col>
                            <Modal.Title>Pacientes</Modal.Title>
                          </Col>
                          <Col>
                            <InputGroup className="">
                              <Form.Control
                                value={searchPaciente}
                                onChange={searcherPaciente}
                                placeholder="Buscar odontologo"
                                aria-label="Buscar odontologo"
                                aria-describedby="basic-addon1"
                              />
                            </InputGroup>
                          </Col>
                        </Row>
                      </Container>

                    </Modal.Header>
                    <Modal.Body className="grid-example">
                      <Container>
                        {/* results son los resultados del filtrado en el searchOdontologo */}
                        {resultsPaciente.map((item, index) => (
                          <Row key={index}>
                            <Col xs={12} md={6}>
                              {item.nombre}
                            </Col>
                            <Col xs={6} md={6} className='d-flex justify-content-end'>
                              {<Button className='mb-2' variant="success" size="sm" onClick={() => {
                                handleChangeIdPaciente(item)

                                handleClosePacientes();
                              }}
                              >
                                Seleccionar</Button>}&nbsp;
                            </Col>
                            <hr></hr>
                          </Row>
                        ))}
                      </Container>
                    </Modal.Body>
                    <Modal.Footer>
                      <Button variant="secondary" onClick={handleCloseOdontologos}>
                        Close
                      </Button>
                    </Modal.Footer>
                  </Modal>
                </Form.Group>
                <div className="botonesAlPie mb-2">
          <Button className="Btn2" variant="secondary" size="lg" onClick={CancelarCarga}>
            Cancelar
          </Button>{' '}
          <Button
            onClick={realizarCargaBono}
            className="Btn1"
            type="submit"
            variant="primary"
            size="lg"
          >
            Cargar
          </Button>
        </div>
            </Form>
          </div>
        </div>
      </div>
    </div>
  )
}

export default PostBono