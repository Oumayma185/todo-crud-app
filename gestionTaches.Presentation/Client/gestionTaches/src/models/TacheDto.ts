export interface TacheDto {
    id: number | undefined;
    title: string;
    description: string;
    isDone: boolean;
    userId: number;
    createdAt: string| undefined;
}