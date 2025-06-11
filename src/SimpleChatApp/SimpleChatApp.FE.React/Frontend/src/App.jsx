import { useEffect, useRef, useState } from 'react'
import { useChat, } from './hooks/useSignalR'
import { marked } from 'marked'

function App() {
  const [name, setName] = useState("")
  const [content, setContent] = useState("")
  const scrollable = useRef(null)

  const { messages, sendMessage } = useChat([])

  useEffect(() => {
    scrollDown()
  })

  const scrollDown =() => {
    scrollable.current.scrollTo(0, scrollable.current.scrollHeight)
  }

  const submitMessage = () => {
    sendMessage({
      sender: name,
      message: content
    })
  }

  const handleSubmitMessage = (e) => {
    if (e.key === "Enter" && !e.shiftKey) {
      e.preventDefault(); // prevent newline
      submitMessage();
    }
  };

  return (
    <>
      <div className='mx-auto container min-h-screen flex flex-col'>

        <div ref={scrollable} className='grow-0 max-h-[45rem] overflow-y-scroll'>

          {messages.map((msg, i) => (
            <div className="marked flex gap-4 bg-amber-50 hover:brightness-95" key={i}>
              <div className="shrink-0">{msg.sender?.length == 0 ? "None" : msg.sender} [{new Date(msg.createdAt).toLocaleTimeString()}]</div><div dangerouslySetInnerHTML={{__html:marked.parse(msg.message)}}></div>
            </div>
          ))}
        
        </div>
        <footer className='py-20 flex gap-4'>
          <label htmlFor="">
            Name
            <input className='bg-slate-200 rounded px-2 w-40' type="text"
              onChange={(e) => setName(e.target.value)}
            />
          </label>
          <textarea className='bg-slate-200 rounded px-2 w-full' type="text"
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
