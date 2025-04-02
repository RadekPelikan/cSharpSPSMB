import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

const API_URL = "http://localhost:5227"

function App() {
  const [fomrVisible, setFormVisible] = useState(false)
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
  }, [])

  return (
    <>
      <div className='container mx-auto my-12'>
        <header>
          <button
            onClick={() => setFormVisible(prev => !prev)}
            className='w-40 px-3 py-2 text-center transition-all rounded bg-emerald-500 hover:brightness-90'
          >{fomrVisible ? "Hide" : "Show"} Enemy Form
          </button>
        </header>
        {
          fomrVisible &&
          <FormNewEnemy />
        }
        <div className="grid gap-4 md:grid-cols-4">
          {
            enemies.map((enemy, i) => (
              <EnemyCard enemyData={enemy} key={i} />
            ))
          }
        </div>
      </div>
    </>
  )
}

const EnemyCard = ({ enemyData }) => {


  return (
    <div className='px-4 py-3 transition-transform rounded-lg bg-linear-to-t from-lime-700 to-lime-600 hover:scale-105'>
      <h2 className='text-xl font-bold text-center text-gray-100'>{enemyData.name}</h2>
      <table className='w-full'>
        <tr>
          <td className='text-gray-200 '>Hp</td>
          <td className='text-gray-200 '>{enemyData.health}</td>
        </tr>
        <tr>
          <td className='text-gray-200 '>Damage</td>

          <td className='text-gray-200 '>{enemyData.damage}</td>
        </tr>
        <tr>
          <td className='text-gray-200 '>Armor</td>

          <td className='text-gray-200 '>{enemyData.armor}</td>
        </tr>
        <tr>
          <td className='text-gray-200 '>Critical Chance</td>

          <td className='text-gray-200 '>{enemyData.criticalChance}</td>
        </tr>
        <tr>
          <td className='text-gray-200 '>Critical Scaler</td>

          <td className='text-gray-200 '>{enemyData.criticalScaler}</td>
        </tr>
      </table>
    </div>
  )
}

const FormNewEnemy = () => {

  const postEnemy = (e) => {
    e.preventDefault()
  }
  return (
    <form action="" onSubmit={postEnemy}>
      <button type="submit">AA</button>
    </form>
  )
}

export default App
