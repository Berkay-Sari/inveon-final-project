import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import LoadingSpinner from '../components/LoadingSpinner';
import PaymentModal from '../components/PaymentModal';
import axios from 'axios';
import alertify from 'alertifyjs';

const Basket = () => {
    const [courses, setCourses] = useState([]);
    const [loading, setLoading] = useState(true);
    const [showModal, setShowModal] = useState(false);
    const [totalAmount, setTotalAmount] = useState(0);
    const [showSuccessMessage, setShowSuccessMessage] = useState(false);
    const [orderCode, setOrderCode] = useState('');

    useEffect(() => {
        const fetchBasket = async () => {
            try {
                const response = await axios.get('/api/Baskets');
                setCourses(response.data.data);
            } catch (error) {
                console.error('Error fetching basket data:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchBasket();
    }, []);

    const handleCheckout = async () => {
        const amount = courses.reduce((sum, course) => sum + course.price, 0);
        setTotalAmount(amount);

        try {
            await axios.post('/api/Orders', null, {
                params: { totalAmount: amount },
                headers: { 'Content-Type': 'application/json' },
            });

            setShowModal(true);
        } catch (error) {
            console.error('Error creating order:', error);
            alertify.error("An error occurred while creating the order.");
        }
    };

    const handleRemove = async (courseId) => {
        try {
            await axios.delete(`/api/Baskets/${courseId}`);
            setCourses((prevCourses) =>
                prevCourses.filter((course) => course.courseId !== courseId)
            );
        } catch (error) {
            console.error('Error removing course from basket:', error);
        }
    };

    if (loading) {
        return <LoadingSpinner />;
    }

    return (
        <div className="container mt-5">
            <h1 className="text-center mb-4">Basket</h1>
            {showSuccessMessage && (
                <div className="alert alert-success text-center" role="alert">
                Your order was successful! Your order code is:{" "}
                <Link
                    to={`/Orders/${orderCode}`}
                    className="text-decoration-none fw-bold"
                    style={{ color: "inherit" }}
                >
                    {orderCode}
                </Link>
                . Happy learning!
                <div className="mt-3">
                    <Link to="/" className="btn btn-primary">
                        Continue Exploring Courses
                    </Link>
                </div>
            </div>
            )}
            {!showSuccessMessage && courses.length === 0 ? (
                <div className="text-center">
                    <p className="lead">
                        Your basket is empty.{' '}
                        <Link to="/" className="text-primary">
                            Discover courses
                        </Link>{' '}
                        to add some excitement to your learning journey!
                    </p>
                </div>
            ) : (
                <>
                    <div className="row">
                        {courses.map((course) => (
                            <div className="col-md-4 mb-4" key={course.courseId}>
                                <div className="card h-100 shadow-sm">
                                    <img
                                        src={`${axios.defaults.baseURL}/${course.imageUrl}`}
                                        className="card-img-top"
                                        alt={course.courseName}
                                        style={{ height: '200px', objectFit: 'cover' }}
                                    />
                                    <div className="card-body d-flex flex-column">
                                        <h5 className="card-title">{course.courseName}</h5>
                                        <p className="card-text">Price: ${course.price}</p>
                                        <button
                                            className="btn btn-danger mt-auto"
                                            onClick={() => handleRemove(course.courseId)}
                                        >
                                            Remove from Basket
                                        </button>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
        {!showSuccessMessage && courses.length > 0 && (
            <div className="text-center mt-4">
                <button className="btn btn-success btn-lg" onClick={handleCheckout}>
                    Complete Order
                </button>
            </div>
        )}
                </>
            )}

            <PaymentModal
                show={showModal}
                totalAmount={totalAmount}
                onClose={() => setShowModal(false)}
                onPaymentSuccess={() => {
                    setCourses([]);
                    setShowSuccessMessage(true);
                    setShowModal(false);
                }}
                setOrderCode={setOrderCode}
            />
        </div>
    );
};

export default Basket;
