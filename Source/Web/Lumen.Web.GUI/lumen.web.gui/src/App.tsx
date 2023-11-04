import React from 'react';
import { styled, alpha } from "@mui/material/styles";
import Box from "@mui/material/Box";
import logo from './assets/lightbulb-placeholder.png';
import './App.css';

const Container = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "row",
    alignItems: "center"
}));

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <Container>
                    <img src={logo} style={{ maxHeight: "80px" }} />
                    <h1>Lumen</h1><h5>©</h5>
                </Container>
            </header>
        </div>
    );
}

export default App;
