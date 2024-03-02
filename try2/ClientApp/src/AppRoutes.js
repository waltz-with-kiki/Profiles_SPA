
import { Home } from "./components/Home";
import UserCreator from "./components/UserCreator.jsx";
import ProfilesPage from "./components/ProfilesPage.jsx"

const AppRoutes = [
    {

    index: true,
    element: <Home />
  },
    {
        path: '/user-creator',
        element: <UserCreator />
    },
    {
        path: '/myProfiles',
        element: <ProfilesPage />
    }

];

export default AppRoutes;
