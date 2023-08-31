import { useState } from 'react';
import { Button, Card, Col, Form, ListGroup, Row } from 'react-bootstrap';
import Container from 'react-bootstrap/Container';
import { HotelModel } from '../models/HotelModel';
import { SearchHotelsResult } from '../models/SearchHotelsResult';
import { SearchService } from '../services';
import * as Icon from 'react-bootstrap-icons';
import DetailsModal from './DetailsModal';

export interface Hotel {
    id: string;
    name: string;
    description: string;
    addrees: { // FIX SPELLING?
        city: string,
        country: string,
        street: string,
        zipCode: string
    }
}

export const Search: React.FC = () => {
    const [term, setTerm] = useState<string>("");
    const [hotels, setHotels] = useState<HotelModel[]>([]);
    const [totalCount, setTotalCount] = useState<number>(0);
    const [showModal, setShowModal] = useState(false);
    const [selectedHotel, setSelectedHotel] = useState<Hotel | null>(null);

    const handleOpenModal = (hotel: Hotel) => {
        setSelectedHotel(hotel);
        setShowModal(true);
    };

    const handleCloseModal = () => {
        setSelectedHotel(null);
        setShowModal(false);
    };

    const handleSearch = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        SearchService.get<SearchHotelsResult>(`/search?term=${term}&skip=0&page=10`)
            .then((response) => {
                setHotels(response.data.hotels);
                setTotalCount(response.data.totalCount);
            })
    }

    const checkAvailibility = () => {
        alert("Not implemented yet");
    }

    return (
        <Container className="p-3" >
            <Container className="p-5 mb-4 bg-light rounded-3" >
                <Row>
                    <Col>
                        <h1 className="header mb-3"> Search </h1>
                        <Form onSubmit={handleSearch} className="mb-3">
                            <Form.Control type="text" value={term} onChange={(e) => setTerm(e.target.value)} />
                            <Button variant="primary" type="submit" className="mt-3">Search</Button>
                        </Form>
                    </Col>
                </Row>
                <Row><Col><hr /></Col></Row>                
                <Row>
                    {
                        hotels.map((hotel, index) => (
                            <Col key={hotel.id}>
                                <Card key={hotel.id}>
                                    <Card.Body style={{ display: 'flex', flexDirection: 'column'}}>
                                        <Card.Title onClick={() => handleOpenModal(hotel)} style={{cursor: 'pointer'}}>{hotel.name}</Card.Title>
                                        <Card.Text>
                                            {hotel.description}
                                        </Card.Text>
                                        <ListGroup className="list-group-flush">
                                            <ListGroup.Item><Icon.Coin /> Economy rooms: {hotel.economyRoomCount}</ListGroup.Item>
                                            <ListGroup.Item><Icon.House /> Standard rooms: {hotel.standardRoomCount}</ListGroup.Item>
                                            <ListGroup.Item><Icon.CashStack /> Deluxe rooms: {hotel.deluxeRoomCount}</ListGroup.Item>
                                        </ListGroup>
                                        <Button variant="primary" onClick={() => handleOpenModal(hotel)}>Check availability</Button>
                                    </Card.Body>
                                </Card>
                            </Col>
                        ))
                    }
                    <DetailsModal showModal={showModal} handleCloseModal={handleCloseModal} selectedHotel={selectedHotel} />
                </Row>
                <Row><Col><p>Found hotels: {totalCount}</p></Col></Row>
            </Container>
        </Container>
    )
}