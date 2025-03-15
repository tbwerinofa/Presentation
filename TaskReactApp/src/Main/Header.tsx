import logo from "./task_logo.png";

type Args = {
  subtitle: string;
};

const Header = ({ subtitle }: Args) => {
  return (
    <header className="row mb-4">
      <div className="col-5">
        <img className="logo" src={logo} alt="logo" />
      </div>
      <h1>Task Manager</h1>
      <div className="col-7 mt-5 subtitle">{subtitle}</div>
    </header>
  );
};
export default Header;
