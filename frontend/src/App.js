// import './App.css';
import { BrowserRouter as Router,Redirect, Switch, Route } from 'react-router-dom';
import { useSelector } from "react-redux";
import { useEffect } from "react";
import Wrapper from './Wrapper';
import HomePage from './Pages/Home/HomePage'

function App() {
  const locale = navigator.language;
  
  const siteOrientation = useSelector((state) => state.siteOrientation);
  useEffect(() => {
    document.getElementsByTagName("html")[0].setAttribute("dir", siteOrientation);
  }, [siteOrientation]);

  return (
    <Wrapper>
      <Router>
        <Switch>
          <Route path='/' exact component={HomePage} />
          <Redirect from="*" to="/" />
        </Switch>
      </Router>
    </Wrapper>
  );
}

export default App;
