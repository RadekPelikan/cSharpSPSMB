import { useEffect, useState } from 'react'
import { Route, Routes, useNavigate, Navigate } from 'react-router'
import './App.css'

export const SERVER_URL = "http://localhost:3000"

function App() {
  const navigate = useNavigate()

  return (
    <Routes>
      <Route index element={<Navigate to="/login" />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/restricted" element={<Restricted />} />
    </Routes>
  )
}

function Login() {

  const onSubmit = (e) => {
    e.preventDefault()
    const action = e.target.action
    const method = e.target.method

    const data = new FormData(e.target);
    const username = data.get("username")
    const password = data.get("password")

    console.log(username, password)
    fetch(action, {
      mode: "cors",
      origin: "*",
      credentials: "include",
      method: method,
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
      body: new URLSearchParams(data)
    })
  }

  return (
    <form method="post" action={`${SERVER_URL}/login`} onSubmit={onSubmit}>
      <p>
        <label for="username">Username:</label>
        <input type="text" name="username" id="username"></input>
      </p>
      <p>
        <label for="password">Password:</label>
        <input type="text" name="password" id="password"></input>
      </p>
      <p>
        <input type="submit" value="Login"></input>
      </p>
    </form>
  )
}

function Register() {

  return "Register"
}

function Restricted() {
  const [loading, setloading] = useState(true)
  const [isAuthorized, setAuthorized] = useState(false)
  const [error, setError] = useState(false)

  const authorized = () => {
    setAuthorized(true)
    setloading(false)
  }
  const notAuthorized = () => {
    setAuthorized(false)
    setloading(false)
  }

  useEffect(() => {
    fetch(`${SERVER_URL}/restricted`, {
      mode: "cors",
      origin: "*",
      credentials: "include"
    }).then(() => authorized()).catch((res) => {
      if (res.status == 304)
        setError(true)
      else
        notAuthorized()
    }
    )

  }, [])

  const logout = () => {

    fetch(`${SERVER_URL}/logout`, {
      mode: "cors",
      origin: "*",
      credentials: "include"
    }).then(() => notAuthorized())
  }

  if (loading) {
    return (<>
      <p>Loading...</p>
      <button onClick={logout}>Logout</button>
    </>)
  }
  else if (error) {
    return (<p>Error</p>)
  }
  else if (isAuthorized) {
    return (<>
      <p>Super secret</p>
      <button onClick={logout}>Logout</button>
    </>)
  }
  else {
    return <Navigate to="/login" />
  }

}

export default App
