import { useEffect, useReducer, useState } from 'react'
import './App.css'

const API_URL = "http://localhost:5227"

function App() {
  const [fomrVisible, setFormVisible] = useState(true)
  const [enemies, setEnemies] = useState([]);

  const loadEnemies = async () => {
    const res = await fetch(`${API_URL}/api/enemy`)
    const data = await res.json();
    console.log(data)
    setEnemies(data)
  }

  useEffect(() => {
    loadEnemies()
  }, [])

  return (
    <>
      <div className='container grid gap-3 mx-auto my-12'>
        <header>
          <button
            onClick={() => setFormVisible(prev => !prev)}
            className='w-40 px-3 py-2 text-center transition-all rounded bg-emerald-500 hover:brightness-90'
          >{fomrVisible ? "Hide" : "Show"} Enemy Form
          </button>
        </header>
        {
          fomrVisible &&
          <FormNewEnemy loadEnemies={loadEnemies} />
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

const ENEMY_FORM_ACTIONS = {
  CHANGE_NAME: "CHANGE_NAME",
  CHANGE_HEALTH: "CHANGE_HEALTH",
  CHANGE_DAMAGE: "CHANGE_DAMAGE",
  CHANGE_ARMOR: "CHAGE_ARMOR",
  CHANGE_CRITICAL_CHANCE: "CHANGE_CRITICAL_CHANCE",
  CHANGE_CRITICAL_SCALER: "CHANGE_CRITICAL_SCALER",
  CLEAR: "CLEAR"
}

const INIT_STATE =  {
  name: "",
  health: "",
  damage: "",
  armor: "",
  criticalChance: "",
  criticalScaler: "",
}

const enemyFormReducer = (state, action) => {
  const action_cb = {
    [ENEMY_FORM_ACTIONS.CHANGE_NAME]: () => ({ ...state, name: action.event.target.value }),
    [ENEMY_FORM_ACTIONS.CHANGE_HEALTH]: () => ({ ...state, health: action.event.target.value }),
    [ENEMY_FORM_ACTIONS.CHANGE_DAMAGE]: () => ({ ...state, damage: action.event.target.value }),
    [ENEMY_FORM_ACTIONS.CHANGE_ARMOR]: () => ({ ...state, armor: action.event.target.value }),
    [ENEMY_FORM_ACTIONS.CHANGE_CRITICAL_CHANCE]: () => ({ ...state, criticalChance: action.event.target.value }),
    [ENEMY_FORM_ACTIONS.CHANGE_CRITICAL_SCALER]: () => ({ ...state, criticalScaler: action.event.target.value }),
    [ENEMY_FORM_ACTIONS.CHANGE_CRITICAL_SCALER]: () => ({ ...state, criticalScaler: action.event.target.value }),
    [ENEMY_FORM_ACTIONS.CLEAR]: () => INIT_STATE,
  }[action.type];
  
  return action_cb();
}

const FormNewEnemy = ({loadEnemies}) => {
  const [state, dispatch] = useReducer(enemyFormReducer, INIT_STATE)

  const postEnemy = async (e) => {
    e.preventDefault()
    const res = await fetch(`${API_URL}/api/enemy`, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      method: "POST",
      body: JSON.stringify(state)
    })
    dispatch({type: ENEMY_FORM_ACTIONS.CLEAR})
    loadEnemies()
  }

  return (
    <form onSubmit={postEnemy} className='px-3 py-4 rounded bg-linear-to-t from-lime-700 to-lime-600 max-w-96'>
      <div className='grid gap-1 mb-4'>
        <div className='flex flex-col'>
          <label className='text-white' htmlFor="enemy-name">Name</label>
          <input value={state.name} onChange={(event) => dispatch({event, type: ENEMY_FORM_ACTIONS.CHANGE_NAME})} required id="enemy-name" type="text" className='px-2 py-1 border-b-2 border-white rounded-sm outline-none focus:border-amber-300 bg-lime-600 text-slate-300 focus:text-slate-200' />
        </div>
        <div className='flex flex-col'>
          <label className='text-white' htmlFor="enemy-health">Health</label>
          <input value={state.health} onChange={(event) => dispatch({event, type: ENEMY_FORM_ACTIONS.CHANGE_HEALTH})} required id="enemy-health" type="text" className='px-2 py-1 border-b-2 border-white rounded-sm outline-none focus:border-amber-300 bg-lime-600 text-slate-300 focus:text-slate-200' />
        </div>
        <div className='flex flex-col'>
          <label className='text-white' htmlFor="enemy-damage">Damage</label>
          <input value={state.damage} onChange={(event) => dispatch({event, type: ENEMY_FORM_ACTIONS.CHANGE_DAMAGE})} required id="enemy-damage" type="text" className='px-2 py-1 border-b-2 border-white rounded-sm outline-none focus:border-amber-300 bg-lime-600 text-slate-300 focus:text-slate-200' />
        </div>
        <div className='flex flex-col'>
          <label className='text-white' htmlFor="enemy-armor">Armor</label>
          <input value={state.armor} onChange={(event) => dispatch({event, type: ENEMY_FORM_ACTIONS.CHANGE_ARMOR})} required id="enemy-armor" type="text" className='px-2 py-1 border-b-2 border-white rounded-sm outline-none focus:border-amber-300 bg-lime-600 text-slate-300 focus:text-slate-200' />
        </div>
        <div className='flex flex-col'>
          <label className='text-white' htmlFor="enemy-critical-chance">CriticalChance</label>
          <input value={state.criticalChance} onChange={(event) => dispatch({event, type: ENEMY_FORM_ACTIONS.CHANGE_CRITICAL_CHANCE})} required id="enemy-critical-chance" type="text" className='px-2 py-1 border-b-2 border-white rounded-sm outline-none focus:border-amber-300 bg-lime-600 text-slate-300 focus:text-slate-200' />
        </div>
        <div className='flex flex-col'>
          <label className='text-white' htmlFor="enemy-critical-scaler">CriticalScaler</label>
          <input value={state.criticalScaler} onChange={(event) => dispatch({event, type: ENEMY_FORM_ACTIONS.CHANGE_CRITICAL_SCALER})} required id="enemy-critical-scaler" type="text" className='px-2 py-1 border-b-2 border-white rounded-sm outline-none focus:border-amber-300 bg-lime-600 text-slate-300 focus:text-slate-200' />
        </div>
      </div>
      <div className='flex justify-end'>
        <button type="submit" className='px-3 py-2 text-sm rounded bg-slate-300'>Create Enemy</button>
      </div>
    </form>
  )
}

export default App
