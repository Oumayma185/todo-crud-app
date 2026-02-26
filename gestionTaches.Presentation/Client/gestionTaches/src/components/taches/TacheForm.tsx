import { useState } from "react";
import apiConnector from "../../api/apiConnector";

interface Props {
    onClose: () => void;
    onCreated: () => void;
}

export default function TacheForm({ onClose, onCreated }: Props) {
    const [title, setTitle]           = useState("");
    const [description, setDescription] = useState("");
    const [loading, setLoading]       = useState(false);
    const [error, setError]           = useState("");

    const handleSubmit = async () => {
        if (!title.trim()) { setError("Le titre est requis."); return; }
        setLoading(true);
        try {
            await apiConnector.createTache({title, description});
            onCreated();
        } catch (err) {
            console.error(err);
            setError("Erreur lors de la création.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="overlay" onClick={(e) => e.target === e.currentTarget && onClose()}>
            <div className="modal">

                <div className="modal-header">
                    <div className="modal-title">Nouvelle tâche</div>
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
                            placeholder="Ex : Refaire la page d'accueil..."
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
                    {error && <p className="field-error">{error}</p>}
                </div>

                <div className="modal-footer">
                    <button className="btn-cancel" onClick={onClose} disabled={loading}>
                        Annuler
                    </button>
                    <button className="btn-save" onClick={handleSubmit} disabled={loading}>
                        {loading ? "Création..." : "Créer"}
                    </button>
                </div>

            </div>
        </div>
    );
}