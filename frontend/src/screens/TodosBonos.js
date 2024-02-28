import React from "react";
import ListaBonos from "../components/ListaBonos";

const TodosBonos = () => {
  return (
    <div>
      <div className="container text-center">
        <div className="row align-items-center">
          <p class="fs-3">Bonos</p>
          <div className="col">
            <a class="btn btn-primary" href="./Bonos/NuevoBono" role="button">
              Nuevo Bono
            </a>
          </div>
          <br></br>
          <div className="container text-center">
            <ListaBonos></ListaBonos>
          </div>
        </div>
      </div>
    </div>
  );
};

export default TodosBonos;
