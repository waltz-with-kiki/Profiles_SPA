import React, { useState, useEffect } from "react";
import CreateUser from "./Components/CreateUser";

function UserCreator() {

    const [users, setUsers] = useState([]);
  const [login, setLogin] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  useEffect(() => {
    // Вызов метода GET при монтировании компонента
    fetchUsers();
  }, []);

  const fetchUsers = async () => {
      try {
          fetch('https://localhost:7150/api/accounts/user')
              .then(response => response.json())
              .then(data => console.log(data))
              .catch(error => console.error('Error fetching data:', error));
        const response = await fetch('https://localhost:7150/api/accounts/user'); // Путь к вашему методу GET
      const data = await response.json();
      setUsers(data);
    } catch (error) {
      console.error("Error fetching users:", error);
    }
  };

  const handleAddUser = async () => {
    try {
        const response = await fetch('https://localhost:7150/api/accounts/user/registration', {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ 
          Login: login, Email: email, Password: password }),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      console.log("User added successfully!");
      fetchUsers();
    } catch (error) {
      console.error("Error adding user:", error);
    }
  };


  return (
    <div>
      <CreateUser/>
          <div>
              <ul>
                  {users.map(user => (
                      <li>{user.id} {user.login}</li>
                  ))}
              </ul>
      </div>
      <input
        type="text"
        placeholder="Login"
        value={login}
        onChange={(e) => setLogin(e.target.value)}
      />
      <input
        type="text"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button onClick={handleAddUser}>Add User</button>
    </div>
  );

}

export default UserCreator;