import React from 'react'
import ListadoNotas from '../components/ListaBonos'

const Notes = () => {
  return (
    <div>
        <div className='container text-center'>
        <div className='row align-items-center'>
          <div className='col'>
            <p class="fs-3">Bonos</p>           
          </div>
          <br></br>
          <div className='container text-center'>
            <ListadoNotas></ListadoNotas>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Notes