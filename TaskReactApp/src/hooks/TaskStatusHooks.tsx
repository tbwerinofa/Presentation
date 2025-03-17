import { TaskStatus } from "../types/taskStatus";
import config from "../config";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios, { AxiosError, AxiosResponse } from "axios";

const useFetchTaskStatusList = () => {
  return useQuery<TaskStatus[], AxiosError>({
    queryKey: ["taskstatus"],
    queryFn: () =>
      fetch(`${config.baseApiUrl}/taskstatus`).then((res) => res.json()),
  });
};

export default useFetchTaskStatusList;
