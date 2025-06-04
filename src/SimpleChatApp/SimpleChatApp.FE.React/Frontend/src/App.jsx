import { useState } from 'react'
import { useChat, } from './hooks/useSignalR'

function App() {
  const [name, setName] = useState("")
  const [content, setContent] = useState("")

  const { messages, sendMessage } = useChat([])

  const submitMessage = () => {
    sendMessage({
      sender: name,
      message: content
    })
  }

  const handleSubmitMessage = (e) => {
    const code = e.code
    if (code === "Enter")
      submitMessage()
  }

  return (
    <>
      <div className='mx-auto container min-h-screen flex flex-col'>

        <div className='grow-1'>

          {messages.map((msg, i) => (
            <p key={i}>
              {msg.sender}: {msg.message}
            </p>
          ))}
        </div>
        <footer className='py-20 flex gap-4'>
          <label htmlFor="">
            Name
            <input className='bg-slate-200 rounded px-2 w-40' type="text"
              onChange={(e) => setName(e.target.value)}
            />
          </label>
          <input className='bg-slate-200 rounded px-2 w-full' type="text"
            onChange={(e) => setContent(e.target.value)}
            onKeyDown={handleSubmitMessage}
          />
          <button className='bg-emerald-200 rounded px-8 py-2 hover:brightness-90' onClick={submitMessage}>
            Send
          </button>
        </footer>
      </div>
    </>
  )
}

export default App
