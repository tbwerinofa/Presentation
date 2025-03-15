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
        <p>{data.title}</p>

        <p>{data.status}</p>
        <div className="row">
          <div className="col-12 mt-3">{data.description}</div>
        </div>
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
