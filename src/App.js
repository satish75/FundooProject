import React from 'react';

import './App.css';

import LogInPage from './components/LogInPage'
import Register from './components/Register'
import ForgetPassword from './components/ForgetPassword'
import ResetPassword from './components/ResetPassword'
import DashBoard from './components/DashBoard'
import Notes from './components/Notes'
import Sample from './components/Sample'
import {BrowserRouter,Route,Switch} from 'react-router-dom'
import Demo from './components/demo';
import getAllNotes from './components/getAllNotes'
import faltu from './components/faltu'

function App() {
  return (
    <BrowserRouter>
    <div className="container"> 
    <Route path='/log' component={LogInPage}/>
    <Route path='/register' component={Register}/>
    <Route path='/forget' component={ForgetPassword}/>
    <Route path='/reset' component={ResetPassword}/>
    <Route path='/dash' component={DashBoard}/>
    <Route path='/note' component={Notes}/>
    <Route path='/demo' component={Demo}/>
    <Route path='/sam' component={Sample}/>
    <Route path='/dash/notes' component={getAllNotes}/>
    <Route path='/faltu' component={faltu}/>
 
    </div>
    </BrowserRouter>
  );
}

export default App;
