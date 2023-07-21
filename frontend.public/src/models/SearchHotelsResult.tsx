import { HotelModel } from "./HotelModel";

export interface SearchHotelsResult {
    hotels: HotelModel[]
    totalCount: number
}