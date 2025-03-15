import { BrowserRouter, Route, Routes } from "react-router-dom";
import TaskList from "../task/TaskList";
import "./App.css";
import Header from "./Header";
import TaskDetail from "../task/TaskDetail";
import TaskAdd from "../task/TaskAdd";
import TaskEdit from "../task/TaskEdit";

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <Header subtitle="Task Manager" />
        <Routes>
          <Route path="/" element={<TaskList />}></Route>
          <Route path="/task/:id" element={<TaskDetail />}></Route>
          <Route path="/task/add" element={<TaskAdd />}></Route>
          <Route path="/task/edit/:id" element={<TaskEdit />}></Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
