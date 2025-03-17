import { useAddTask } from "../hooks/TaskHooks";
import { Task } from "../types/task";
import ValidationSummary from "../ValidationSummary";
import TaskForm from "./TaskForm";

const TaskAdd = () => {
  const addTaskMutation = useAddTask();

  const task: Task = {
    id: 0,
    title: "",
    description: "",
    status: "",
    taskStatusEntityId: 0,
    dueDate: "",
  };

  return (
    <>
      {addTaskMutation.isError && (
        <ValidationSummary error={addTaskMutation.error} />
      )}

      <TaskForm
        task={task}
        submitted={(task: Task) => {
          addTaskMutation.mutate(task);
        }}
      />
    </>
  );
};

export default TaskAdd;
