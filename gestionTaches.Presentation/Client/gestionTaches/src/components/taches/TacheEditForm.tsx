import { useState } from "react";
import type { TacheDto } from "../../models/TacheDto";
import apiConnector from "../../api/apiConnector";

interface Props {
    tache: TacheDto;
    onClose: () => void;
    onUpdated: (updated: TacheDto) => void;
}

export default function TacheEditForm({ tache, onClose, onUpdated }: Props) {
    const [title, setTitle]             = useState(tache.title);
    const [description, setDescription] = useState(tache.description ?? "");
    const [isDone, setIsDone]           = useState(tache.isDone);
    const [loading, setLoading]         = useState(false);
    const [error, setError]             = useState("");

    const handleSubmit = async () => {
        if (!title.trim()) { setError("Le titre est requis."); return; }
        setLoading(true);
        try {
            const updated = await apiConnector.editTache(tache.id, {
                title,
                description,
                isDone,
            });
            onUpdated(updated); 
        } catch (err) {
            console.error(err);
            setError("Erreur lors de la mise à jour.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="overlay" onClick={(e) => e.target === e.currentTarget && onClose()}>
            <div className="modal">

                <div className="modal-header">
                    <div className="modal-title">Modifier la tâche</div>
                    <button className="modal-close" onClick={onClose}>
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
                            <line x1="18" y1="6" x2="6" y2="18" />
                            <line x1="6" y1="6" x2="18" y2="18" />
                        </svg>
                    </button>
                </div>

                <div className="modal-body">
                    <div className="field">
                        <label>Titre *</label>
                        <input
                            type="text"
                            value={title}
                            onChange={(e) => { setTitle(e.target.value); setError(""); }}
                            autoFocus
                        />
                    </div>

                    <div className="field">
                        <label>Description</label>
                        <textarea
                            placeholder="Détails optionnels..."
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                        />
                    </div>

                    <div className="field">
                        <label>Statut</label>
                        <div className="status-toggle">
                            <button
                                type="button"
                                className={`toggle-option ${!isDone ? "selected" : ""}`}
                                onClick={() => setIsDone(false)}
                            >
                                <span className="toggle-dot active-dot" />
                                En cours
                            </button>
                            <button
                                type="button"
                                className={`toggle-option ${isDone ? "selected" : ""}`}
                                onClick={() => setIsDone(true)}
                            >
                                <span className="toggle-dot done-dot" />
                                Terminée
                            </button>
                        </div>
                    </div>

                    {error && <p className="field-error">{error}</p>}
                </div>

                <div className="modal-footer">
                    <button className="btn-cancel" onClick={onClose} disabled={loading}>
                        Annuler
                    </button>
                    <button className="btn-save" onClick={handleSubmit} disabled={loading}>
                        {loading ? "Enregistrement..." : "Enregistrer"}
                    </button>
                </div>

            </div>
        </div>
    );
}