import React from "react";
import TodosBonos from "./screens/TodosBonos"
import './App.css';
import { BrowserRouter as Router, Route, Routes, Navigate} from "react-router-dom";
import NuevoBono from "./screens/NuevoBono";

function App() {
  return (
    <Router>
      <Routes>
        <Route element={<TodosBonos/>} path="/Bonos" />
        <Route element={<NuevoBono/>} path="/Bonos/NuevoBono" />
        <Route path="/" element={<Navigate to="/Bonos" />} />
        
      </Routes>
    </Router>

  );
}

export default App;
