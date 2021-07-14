import { Link } from 'react-router-dom';

import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        
        <h1>CZBooks</h1>

        <Link to="login">Faça Login</Link> 
      </header>
    </div>
  );
}

export default App;
