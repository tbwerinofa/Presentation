import { Task } from "../types/task";
import config from "../config";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios, { AxiosError, AxiosResponse } from "axios";
import { useNavigate } from "react-router-dom";
import Problem from "../types/problem";

const useFetchTasks = () => {
  return useQuery<Task[], AxiosError>({
    queryKey: ["tasks"],
    queryFn: () =>
      fetch(`${config.baseApiUrl}/tasks`).then((res) => res.json()),
  });
};

const useFetchTask = (id: number) => {
  return useQuery<Task, AxiosError>({
    queryKey: ["task", id],
    queryFn: () =>
      fetch(`${config.baseApiUrl}/task/${id}`).then((res) => res.json()),
  });
};

const useAddTask = () => {
  const nav = useNavigate();
  const queryClient = useQueryClient();
  return useMutation<AxiosResponse, AxiosError<Problem>, Task>({
    mutationFn: (h) => axios.post(`${config.baseApiUrl}/tasks`, h),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["tasks"] });
      nav("/");
    },
  });
};

const useUpdateTask = () => {
  const nav = useNavigate();
  const queryClient = useQueryClient();
  return useMutation<AxiosResponse, AxiosError<Problem>, Task>({
    mutationFn: (h) => axios.put(`${config.baseApiUrl}/tasks`, h),
    onSuccess: (_, task) => {
      queryClient.invalidateQueries({ queryKey: ["tasks"] });
      nav("/");
    },
  });
};

const useDeleteTask = () => {
  const nav = useNavigate();
  const queryClient = useQueryClient();
  return useMutation<AxiosResponse, AxiosError, Task>({
    mutationFn: (h) => axios.delete(`${config.baseApiUrl}/tasks/${h.id}`),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["tasks"] });
      nav("/");
    },
  });
};

export default useFetchTasks;
export { useFetchTask, useAddTask, useUpdateTask, useDeleteTask };
