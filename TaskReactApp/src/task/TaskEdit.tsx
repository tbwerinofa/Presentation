import { useParams } from "react-router-dom";
import { useFetchTask, useUpdateTask } from "../hooks/TaskHooks";
import { Task } from "../types/task";
import TaskForm from "./TaskForm";
import ApiStatus from "../ApiStatus";
import ValidationSummary from "../ValidationSummary";

const TaskEdit = () => {
  const { id } = useParams();
  if (!id) throw Error("Task id not found");
  const taskId = parseInt(id);
  const { data, status, isSuccess } = useFetchTask(taskId);
  const updateTaskMutation = useUpdateTask();

  if (!isSuccess) return <ApiStatus status={status} />;

  return (
    <>
      {updateTaskMutation.isError && (
        <ValidationSummary error={updateTaskMutation.error} />
      )}
      <TaskForm
        task={data}
        submitted={(task: Task) => {
          updateTaskMutation.mutate(task);
        }}
      />
    </>
  );
};

export default TaskEdit;
