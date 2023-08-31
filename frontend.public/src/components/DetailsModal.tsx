import { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import { Hotel } from './Search';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { AvailabilityService } from '../services';

interface Props {
    showModal: boolean;
    handleCloseModal: () => void;
    selectedHotel: Hotel | null;
}

enum RoomType {
    Economy,
    Standard,
    Deluxe
}

interface Booking {
    RoomType: RoomType,
    Guid: string,
    Guests: number,
    GuestName: string,
    startDate: Date,
    endDate: Date
}

const DetailsModal = ({ showModal, handleCloseModal, selectedHotel }: Props) => {
    const [startDate, setStartDate] = useState<Date | null>(null);
    const [endDate, setEndDate] = useState<Date | null>(null);
    const [selectedRoomType, setSelectedRoomType] = useState<string | null>(null);

    const roomTypes = ['Economy', 'Standard', 'Deluxe'];

    const formatDate = (date: Date) => {
        let day: string | number = date.getDate();
        const month = date.getMonth() + 1;
        const year = date.getFullYear();

        if(day < 10) day =`0${day}`;

        const formatedDate = `${month}/${day}/${year} 00:00:00`;
        console.log(formatedDate)
        return formatedDate.replace(/\//g, '%2F').replace(/ /g, '%20').replace(/:/g, '%3A');

    }

    /**
     * @returns Array of rooms IDs
     * @throws Error if no hotel is selected
     */
    const checkAvailibility = async () => {
        const availibilityData = {
            startDate: formatDate(startDate!),
            endDate: formatDate(endDate!),
            type: selectedRoomType,
            hotelId: selectedHotel?.id
        }

        const url = `${availibilityData.hotelId}?type=${availibilityData.type}&startDate=${availibilityData.startDate}&endDate=${availibilityData.endDate}`
            
        try {
            if(!selectedHotel?.id) throw new Error("No hotel selected");
            const response = await AvailabilityService.get(url);
            return response.data;
        } catch (error) {
            console.error("Error checking available rooms:", error);
            throw error;
        }
    }

    return (
        <Modal show={showModal} onHide={handleCloseModal}>
            <Modal.Header closeButton>
                <Modal.Title>{selectedHotel?.name}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <p>{selectedHotel?.addrees.city}, {selectedHotel?.addrees.street}</p>
                {selectedHotel?.description}
                <div className="room-type-container">
                    <label>Room Type:</label>
                    <select 
                        value={selectedRoomType || ''}
                        onChange={(e) => setSelectedRoomType(e.target.value)}
                    >
                        <option value="" disabled>Select a room type</option>
                        {roomTypes.map((type, index) => (
                            <option key={index} value={type}>{type}</option>
                        ))}
                    </select>
                </div>
                <div className="date-picker-container">
                    <div>
                        <label>Check-in:</label>
                        <DatePicker 
                            selected={startDate}
                            onChange={(date: Date) => setStartDate(date)}
                            selectsStart
                            startDate={startDate}
                            endDate={endDate}
                            minDate={new Date()}
                        />
                    </div>
                    <div>
                        <label>Check-out:</label>
                        <DatePicker 
                            selected={endDate}
                            onChange={(date: Date) => setEndDate(date)}
                            selectsEnd
                            startDate={startDate}
                            endDate={endDate}
                            minDate={startDate}
                        />
                    </div>
                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleCloseModal}>
                    Close
                </Button>
                <Button variant="primary" disabled={!startDate || !endDate} onClick={checkAvailibility}>
                    Check availibility
                </Button>
            </Modal.Footer>
        </Modal>
    )
}

export default DetailsModal;
