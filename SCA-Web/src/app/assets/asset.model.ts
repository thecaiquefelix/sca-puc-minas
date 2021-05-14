export interface Asset{
    id: number,
    name: string,
    manufacturer: number,
    category: number,
    manufactureDate: Date,
    serial: string,
    active: boolean
}

export enum Manufacturer {
    Cat,
    Vaisala,
    Volkswagen,
    Tratorparts,
    Domaq
}

export enum Category {
    Maquina,
    Ferramenta
}
