import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

const API_URL = "http://localhost:5227"

function App() {
  const [enemies, setEnemies] = useState([]);

  const loadEnemies = async () => {
    const res = await fetch(`${API_URL}/api/enemy`)
    console.log(`${API_URL}/api/enemy`)
    console.log(res)
    const data = await res.json();
    console.log(data)
    setEnemies(data)
  }

  useEffect(() => {
    loadEnemies()
    // fetch(`${API_URL}/api/enemy`, {
    //   mode: 'no-cors',
    //   headers: {
    //     'Access-Control-Allow-Origin':'*'
    //   }
    // })
    // .then(res => {
    //   return res.json()
    // })
    // .then(data => {
    //   console.log(data)
    //   setEnemies(data)
    // })
  }, [])

  return (
    <>
      <pre>
        {JSON.stringify(enemies)}
      </pre>
    </>
  )
}

export default App
