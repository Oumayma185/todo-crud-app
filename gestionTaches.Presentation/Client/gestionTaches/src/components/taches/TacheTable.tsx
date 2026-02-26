import type { TacheDto } from "../../models/TacheDto";
import { useEffect, useState } from "react";
import apiConnector from "../../api/apiConnector";
import TacheTableItem from "./TacheTableItem";

type FilterType = "all" | "active" | "done";

interface Props {
    search?: string;
}

export default function TacheTable({ search = "" }: Props) {
    const [taches, setTaches]   = useState<TacheDto[]>([]);
    const [loading, setLoading] = useState(true);
    const [filter, setFilter]   = useState<FilterType>("all");

    useEffect(() => {
        (async () => {
            try {
                const data = await apiConnector.getTaches();
                setTaches(data);
            } catch (err) {
                console.error(err);
            } finally {
                setLoading(false);
            }
        })();
    }, []);

    const handleToggle = (id: number) =>
        setTaches((prev) => prev.map((t) => (t.id === id ? { ...t, isDone: !t.isDone } : t)));

    const handleDelete = (id: number) =>
        setTaches((prev) => prev.filter((t) => t.id !== id));

    const handleUpdate = (updated: TacheDto) =>
        setTaches((prev) => prev.map((t) => (t.id === updated.id ? updated : t)));

    const done  = taches.filter((t) => t.isDone).length;
    const total = taches.length;

    const filtered = taches.filter((t) => {
        const matchFilter =
            filter === "all" ? true : filter === "done" ? t.isDone : !t.isDone;
        const matchSearch =
            t.title.toLowerCase().includes(search.toLowerCase()) ||
            (t.description ?? "").toLowerCase().includes(search.toLowerCase());
        return matchFilter && matchSearch;
    });

    if (loading) return <div className="loading">Chargement</div>;

    return (
        <>
            <div className="stats-row">
                <div className="stat-pill">
                    <strong>{total}</strong> tâches
                </div>
                <div className="stat-pill s-active">
                    <strong>{total - done}</strong> en cours
                </div>
                <div className="stat-pill s-done">
                    <strong>{done}</strong> terminées
                </div>
            </div>

            <div className="toolbar">
                <div className="filters">
                    {(["all", "active", "done"] as FilterType[]).map((f) => (
                        <button
                            key={f}
                            className={`filter-btn ${filter === f ? "active" : ""}`}
                            onClick={() => setFilter(f)}
                        >
                            {f === "all" ? "Toutes" : f === "active" ? "En cours" : "Terminées"}
                        </button>
                    ))}
                </div>
                <span className="results-count">
          {filtered.length} résultat{filtered.length !== 1 ? "s" : ""}
        </span>
            </div>

            <div className="table-wrapper">
                {filtered.length === 0 ? (
                    <div className="empty-state">
                        <div className="empty-text">Aucune tâche trouvée</div>
                        <div className="empty-sub">Modifiez le filtre ou créez une nouvelle tâche</div>
                    </div>
                ) : (
                    <table className="task-table">
                        <thead>
                        <tr>
                            <th style={{ width: 40 }} />
                            <th>Tâche</th>
                            <th style={{ width: 130 }}>Date</th>
                            <th style={{ width: 110 }}>Statut</th>
                            <th style={{ width: 70 }} />
                        </tr>
                        </thead>
                        <tbody>
                        {filtered.map((tache) => (
                            <TacheTableItem
                                key={tache.id}
                                tache={tache}
                                onDelete={handleDelete}
                                onToggle={handleToggle}
                                onUpdate={handleUpdate}
                            />
                        ))}
                        </tbody>
                    </table>
                )}
            </div>
        </>
    );
}