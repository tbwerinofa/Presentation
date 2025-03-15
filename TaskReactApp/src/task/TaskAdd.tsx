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
    dueDate: new Date(),
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
