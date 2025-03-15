import useFetchTasks from "../hooks/TaskHooks";
import { Task } from "../types/task";
import ApiStatus from "../ApiStatus";
import { Link, useNavigate } from "react-router-dom";

const TaskList = () => {
  const nav = useNavigate();
  const { data, status, isSuccess } = useFetchTasks();

  if (!isSuccess) return <ApiStatus status={status} />;

  return (
    <div>
      <div className="row mb-2">
        <h5 className="themeFontColor text-center">
          Task currently in the system
        </h5>
      </div>
      <table className="table table-hover table-striped">
        <thead>
          <tr>
            <th>Name</th>
            <th>Status</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {data &&
            data.map((t: Task) => (
              <tr key={t.id} onClick={() => nav(`/task/${t.id}`)}>
                <td>{t.title}</td>
                <td>{t.status}</td>
                <td>{t.description}</td>
              </tr>
            ))}
        </tbody>
      </table>
      <Link className="btn btn-primary" to="/task/add">
        Add
      </Link>
    </div>
  );
};

export default TaskList;
