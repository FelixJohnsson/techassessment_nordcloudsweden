export interface HotelModel {
    id: string
    name: string
    description: string
    economyRoomCount: number
    standardRoomCount: number
    deluxeRoomCount: number
    addrees: AddressModel
}

export interface AddressModel {
    street: string
    street2: string
    zipCode: string
    city: string
    country: string
}