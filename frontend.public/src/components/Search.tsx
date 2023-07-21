import { useState } from 'react';
import { Button, Card, Col, Form, ListGroup, Row } from 'react-bootstrap';
import Container from 'react-bootstrap/Container';
import { HotelModel } from '../models/HotelModel';
import { SearchHotelsResult } from '../models/SearchHotelsResult';
import { SearchService } from '../services';
import * as Icon from 'react-bootstrap-icons';

export const Search: React.FC = () => {
    const [term, setTerm] = useState<string>("");
    const [hotels, setHotels] = useState<HotelModel[]>([]);
    const [totalCount, setTotalCount] = useState<number>(0);

    const handleSearch = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        SearchService.get<SearchHotelsResult>(`/search?term=${term}&skip=0&page=10`)
            .then((response) => {
                setHotels(response.data.hotels);
                setTotalCount(response.data.totalCount);
            })
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
                        hotels.map((hotel) => (
                            <Col>
                                <Card key={hotel.id}>
                                    <Card.Body>
                                        <Card.Title>{hotel.name}</Card.Title>
                                        <Card.Text>
                                            {hotel.description}
                                        </Card.Text>
                                        <ListGroup className="list-group-flush">
                                            <ListGroup.Item><Icon.Coin /> {hotel.economyRoomCount}</ListGroup.Item>
                                            <ListGroup.Item><Icon.House /> {hotel.standardRoomCount}</ListGroup.Item>
                                            <ListGroup.Item><Icon.CashStack /> {hotel.deluxeRoomCount}</ListGroup.Item>
                                        </ListGroup>
                                        <Button variant="primary">Check availibility</Button>
                                    </Card.Body>
                                </Card>
                            </Col>
                        ))
                    }
                </Row>
                <Row><Col><p>Found hotels: {totalCount}</p></Col></Row>
            </Container>
        </Container>
    )
}