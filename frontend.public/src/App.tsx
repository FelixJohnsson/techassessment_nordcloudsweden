import './App.css';
import { NavigationBar } from './navigation/bar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Home } from './components/Home';
import { Search } from './components/Search';
import { Hotel } from './components/Hotel';

function App() {
    return (
        <BrowserRouter>
            <NavigationBar />            
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/search" element={<Search />} />
                <Route path="/hotel/ :id" element={<Hotel />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
