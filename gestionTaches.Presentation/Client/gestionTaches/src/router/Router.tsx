
import TacheForm from "../components/taches/TacheForm.tsx";
import App from "../App.tsx";
import TacheTable from "../components/taches/TacheTable.tsx";
import {createBrowserRouter, type RouteObject } from "react-router-dom";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'createTache', element: <TacheForm key='create' onCreated={() => {}} onClose={() => {}} /> },
            { path: 'editTache/:id', element: <TacheForm key='edit' onCreated={() => {}} onClose={() => {}} /> },
            { path: '*', element: <TacheTable /> },
        ],
    },
];

export const router = createBrowserRouter(routes)