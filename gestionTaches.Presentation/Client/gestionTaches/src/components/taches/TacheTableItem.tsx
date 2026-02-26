import { useState } from "react";
import type { TacheDto } from "../../models/TacheDto";
import apiConnector from "../../api/apiConnector";
import TacheEditForm from "./TacheEditForm";

interface Props {
    tache: TacheDto;
    onDelete: (id: number) => void;
    onToggle: (id: number) => void;
    onUpdate: (updated: TacheDto) => void;
}

export default function TacheTableItem({ tache, onDelete, onToggle, onUpdate }: Props) {
    const [showEdit, setShowEdit] = useState(false);

    const handleDelete = async () => {
        try {
            await apiConnector.deleteTache(tache.id);
            onDelete(tache.id);
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <>
            <tr className={`table-row ${tache.isDone ? "done-row" : ""}`}>

                <td className="td-check">
                    <button
                        className={`check-btn ${tache.isDone ? "checked" : ""}`}
                        onClick={() => onToggle(tache.id)}
                    >
                        {tache.isDone && (
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="3">
                                <polyline points="20 6 9 17 4 12" />
                            </svg>
                        )}
                    </button>
                </td>

                <td>
                    <div className="task-title-text">{tache.title}</div>
                    {tache.description && (
                        <div className="task-desc-text">{tache.description}</div>
                    )}
                </td>

                <td className="date-cell">
                    {new Date(tache.createdAt).toLocaleDateString("fr-FR", {
                        day: "numeric",
                        month: "short",
                        year: "numeric",
                    })}
                </td>

                <td>
          <span className={`status-badge ${tache.isDone ? "done" : "active"}`}>
            <span className="dot" />
              {tache.isDone ? "Terminée" : "En cours"}
          </span>
                </td>

                <td className="td-actions">
                    <div className="actions-cell">
                        <button
                            className="icon-btn"
                            title="Modifier"
                            onClick={() => {
                                console.log("Edit tache id:", tache.id);
                                setShowEdit(true);
                            }}
                        >
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
                                <path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7" />
                                <path d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z" />
                            </svg>
                        </button>
                        <button className="icon-btn del" onClick={handleDelete} title="Supprimer">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
                                <polyline points="3 6 5 6 21 6" />
                                <path d="M19 6l-1 14H6L5 6" />
                                <path d="M10 11v6M14 11v6" />
                                <path d="M9 6V4h6v2" />
                            </svg>
                        </button>
                    </div>
                </td>

            </tr>

            {showEdit && (
                <TacheEditForm
                    tache={tache}
                    onClose={() => setShowEdit(false)}
                    onUpdated={(updated) => {
                        onUpdate(updated);
                        setShowEdit(false);
                    }}
                />
            )}
        </>
    );
}