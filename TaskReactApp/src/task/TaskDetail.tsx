import { Link, useParams } from "react-router-dom";
import { useDeleteTask, useFetchTask } from "../hooks/TaskHooks";
import ApiStatus from "../ApiStatus";

const TaskDetail = () => {
  const { id } = useParams();
  if (!id) throw Error("Task id not found");
  const taskId = parseInt(id);
  const { data, status, isSuccess } = useFetchTask(taskId);
  const deleteTaskMutation = useDeleteTask();

  if (!isSuccess) return <ApiStatus status={status} />;
  if (!data) return <div>Task not found</div>;

  return (
    <div className="row">
      <Link className="btn btn-primary w-100" to={`/task/edit/${data.id}`}>
        Edit
      </Link>
      <div className="col-6"></div>
      <div className="col-6">
        <h1>Task Detail</h1>
        <ul className="list-group">
          <li className="list-group-item">{data.title}</li>
          <li className="list-group-item">{data.status}</li>
          <li className="list-group-item">
            {data.dueDate ? data.dueDate.substring(0, 10) : ""}
          </li>
          <li className="list-group-item">
            <div className="col-12 mt-3">{data.description}</div>
          </li>
        </ul>
        <p>
          <button
            className="btn btn-danger w-100"
            onClick={() => {
              if (confirm("Are you sure you want to delete this task?")) {
                deleteTaskMutation.mutate(data);
              }
            }}
          >
            Delete
          </button>
        </p>
      </div>
    </div>
  );
  <div />;
};
export default TaskDetail;
