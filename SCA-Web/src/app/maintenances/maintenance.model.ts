export interface Maintenance{
    id: number,
    assetId: number,
    assetName: string,
    type: Type,
    status: Status,
    date: Date,
    active: boolean
}

export enum Type{
    Preventivo,
    Corretivo
}

export enum Status{
    Agendada,
    Iniciada, 
    Concluída
}