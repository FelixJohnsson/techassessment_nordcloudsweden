import Container from 'react-bootstrap/Container';

export const Home: React.FC = () => {

    return (
        <Container className="p-3">
            <Container className="p-5 mb-4 bg-light rounded-3">
                <h1 className="header">Welcome To Cloud hotels App</h1>
            </Container>
        </Container>
    )
}