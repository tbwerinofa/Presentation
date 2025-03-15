type Args = {
  status: "success" | "error" | "pending";
};
const ApiStatus = ({ status }: Args) => {
  switch (status) {
    case "error":
      return (
        <div className="alert alert-danger">
          Error communicating with data backend
        </div>
      );
      break;
    case "pending":
      return <div className="alert alert-warning">Loading...</div>;
      break;

    default:
      throw Error("Unknown API State");
      break;
  }
};

export default ApiStatus;
