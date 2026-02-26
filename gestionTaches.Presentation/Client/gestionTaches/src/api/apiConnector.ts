import type { AxiosResponse } from "axios";
import type { TacheDto } from "../models/TacheDto";
import type { GetTachesResponse } from "../models/GetTachesResponse";
import axios from "axios";
import { API_BASE_URL } from "../config.ts";

const apiConnector = {
    getTaches: async (): Promise<TacheDto[]> => {
        try {
            const response: AxiosResponse<GetTachesResponse> = 
                await axios.get(`${API_BASE_URL}/taches`);

            console.log("Données reçues du backend :", response.data);

            const taches: TacheDto[] = response.data.tachesDtos.map(tache => ({
                ...tache,
                createdAt: tache.createdAt?.slice(0, 10) ?? ""
            }));

            return taches;
        } catch (error) {
            console.log("Erreur lors de chargement des taches", error);
            throw error;
        }
    },

    createTache: async (tache: TacheDto): Promise<void> => {
        try {
            await axios.post<number>(`${API_BASE_URL}/taches`, tache);
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    editTache: async (id: number, data: Partial<TacheDto>): Promise<TacheDto> => {
        try {
            await axios.put(`${API_BASE_URL}/taches/${id}`, data, {
                headers: { "Content-Type": "application/json" }
            });
            return { ...data, id } as TacheDto; 
        } catch (err) {
            console.error(err);
            throw err;
        }
    },
    

    deleteTache: async (tacheId: number): Promise<void> => {
        try {
            await axios.delete<number>(`${API_BASE_URL}/taches/${tacheId}`);
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    getTacheById: async (tacheId: number): Promise<TacheDto | undefined> => {
        try {
            const response = 
                await axios.get<{ tacheDto: TacheDto }>(`${API_BASE_URL}/taches/${tacheId}`);
            return response.data.tacheDto;
        } catch (error) {
            console.log(error);
            throw error;
        }
    }
};

export default apiConnector;