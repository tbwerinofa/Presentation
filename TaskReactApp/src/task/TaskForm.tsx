import { useState } from "react";
import { Task } from "../types/task";
import useFetchTaskStatusList from "../hooks/TaskStatusHooks";
import ApiStatus from "../ApiStatus";

type Args = {
  task: Task;
  submitted: (task: Task) => void;
};

const TaskForm = ({ task, submitted }: Args) => {
  const [taskState, setTaskState] = useState({ ...task });
  const { data, status, isSuccess } = useFetchTaskStatusList();
  if (!isSuccess) return <ApiStatus status={status} />;

  const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
    e.preventDefault();
    submitted(taskState);
  };

  return (
    <div className="mt-2">
      <form>
        <div className="mb-3">
          <label htmlFor="title" className="form-label">
            Title
          </label>
          <input
            type="text"
            className="form-control"
            id="title"
            name="title"
            value={taskState.title}
            onChange={(e) =>
              setTaskState({ ...taskState, title: e.target.value })
            }
          />
        </div>
        <div className="form-group mb-3">
          <label htmlFor="description" className="form-label">
            Description
          </label>
          <input
            type="text"
            className="form-control"
            id="description"
            name="description"
            value={taskState.description}
            onChange={(e) =>
              setTaskState({ ...taskState, description: e.target.value })
            }
          />
        </div>
        <div className="mb-3">
          <label htmlFor="status" className="form-label">
            Status
          </label>
          <select
            className="form-control"
            id="status"
            name="status"
            defaultValue={taskState.taskStatusEntityId}
            onChange={(e) => {
              const statusId = data.find(
                (status) => status.id === parseInt(e.target.value)
              );
              setTaskState({
                ...taskState,
                taskStatusEntityId: parseInt(e.target.value),
              });
              //setTaskStatusState(e.target.value)
              console.log(statusId);
            }}
          >
            {data.map((status) => (
              <option key={status.id} value={status.id}>
                {status.name}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-3">
          <label htmlFor="dueDate" className="form-label">
            Due Date
          </label>
          <input
            type="date"
            className="form-control"
            id="dueDate"
            name="dueDate"
            value={taskState.dueDate ? taskState.dueDate.substring(0, 10) : ""}
            onChange={(e) =>
              setTaskState({ ...taskState, dueDate: e.target.value })
            }
          />
        </div>
        <button
          type="submit"
          className="btn btn-primary mt-2"
          disabled={!taskState.title || taskState.taskStatusEntityId == 0}
          onClick={onSubmit}
        >
          Submit
        </button>
      </form>
    </div>
  );
};

export default TaskForm;
