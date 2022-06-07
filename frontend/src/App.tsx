import React from 'react';
import logo from './logo.svg';
import './App.css';
import NewsFeed from './pages/NewsFeed';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h2>Awesome news</h2>
      </header>
      <NewsFeed />
      <footer>
        <p>some information</p>
      </footer>
    </div>
  );
}

export default App;
