import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Chat } from "./components/Chat";
import { WordleGame } from "./components/Wordle";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/weather',
    element: <FetchData />
  },
  {
      path: '/chat',
      element: <Chat />
  },
  {
      path: '/wordle',
      element: <WordleGame />
  }
];

export default AppRoutes;
