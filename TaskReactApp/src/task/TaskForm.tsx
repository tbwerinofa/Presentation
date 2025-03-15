import { useState } from "react";
import { Task } from "../types/task";

type Args = {
  task: Task;
  submitted: (task: Task) => void;
};

const TaskForm = ({ task, submitted }: Args) => {
  const [taskState, setTaskState] = useState({ ...task });
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
          <input
            type="text"
            className="form-control"
            id="status"
            name="status"
            value={taskState.status}
            onChange={(e) =>
              setTaskState({ ...taskState, status: e.target.value })
            }
          />
        </div>
        <button
          type="submit"
          className="btn btn-primary mt-2"
          disabled={!taskState.title || !taskState.status}
          onClick={onSubmit}
        >
          Submit
        </button>
      </form>
    </div>
  );
};

export default TaskForm;
