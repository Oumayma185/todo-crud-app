import "./App.css";
import { useState } from "react";
import TacheTable from "./components/taches/TacheTable";
import TacheForm from "./components/taches/TacheForm";
import type { TacheDto } from "./models/TacheDto";

const DEFAULT_USER = "Oumaima";
const MOTIVATIONS = [
    "Belle journée pour avancer 🎯",
    "Chaque tâche cochée compte ✓",
    "Focus et efficacité aujourd'hui 💡",
    "Tu gères, continue comme ça 🚀",
    "Une chose à la fois, c'est suffisant",
];

function getGreeting() {
    const h = new Date().getHours();
    if (h < 12) return "Bonjour";
    if (h < 18) return "Bon après-midi";
    return "Bonsoir";
}

export default function App() {
    const [taches, setTaches] = useState<TacheDto[]>([]);
    const [showForm, setShowForm] = useState(false);
    const [search, setSearch] = useState("");

    const motivation = MOTIVATIONS[new Date().getDay() % MOTIVATIONS.length];

    const handleCreated = (newTache: TacheDto) => {
        setTaches(prev => [...prev, newTache]);
        setShowForm(false);
    };

    const handleUpdate = (updated: TacheDto) => {
        setTaches(prev => prev.map(t => t.id === updated.id ? updated : t));
    };

    const handleDelete = (id: number) => {
        setTaches(prev => prev.filter(t => t.id !== id));
    };

    const handleToggle = (id: number) => {
        setTaches(prev => prev.map(t => t.id === id ? { ...t, isDone: !t.isDone } : t));
    };

    return (
        <div className="page">

            <div className="page-header">
                <div className="header-left">
                    <div className="header-greeting">
                        {getGreeting()}, <span>{DEFAULT_USER}</span>
                    </div>
                    <div className="header-sub">{motivation}</div>
                </div>

                <div className="header-right">
                    <div className="search-box">
                        <input
                            type="text"
                            placeholder="Rechercher..."
                            value={search}
                            onChange={(e) => setSearch(e.target.value)}
                        />
                    </div>

                    <button className="btn-add" onClick={() => setShowForm(true)}>
                        Nouvelle tâche
                    </button>
                </div>
            </div>

            <TacheTable
                taches={taches}
                onDelete={handleDelete}
                onToggle={handleToggle}
                onUpdate={handleUpdate}
                search={search}
            />

            {showForm && <TacheForm
                onClose={() => setShowForm(false)}
                onCreated={handleCreated}
            />}

        </div>
    );
}