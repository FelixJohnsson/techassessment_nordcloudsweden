import axios from "axios";

export const SearchService = axios.create(
    {
        baseURL: "https://localhost:7055/hotel/",
        headers: {
            "Content-type": "application/json"
        }
    });

export const AvailabilityService = axios.create(
    {
        baseURL: "https://localhost:7243/room/getavailablerooms/",
        headers: {
            "Content-type": "application/json"
        }
    });

export const PriceService = axios.create(
    {
        baseURL: "https://localhost:7197",
        headers: {
            "Content-type": "application/json"
        }
    });

export const BookService = axios.create(
    {
        baseURL: "https://localhost:7243",
        headers: {
            "Content-type": "application/json"
        }
    });