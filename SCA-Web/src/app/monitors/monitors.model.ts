export interface Monitor{
    id: number,
    damId: DamId,
    metricId: number,
    date: Date,
    value: number
}

export enum DamId{
    Brumadinho = 1,
    Xingó = 2,
    FozdoAreia = 3
}