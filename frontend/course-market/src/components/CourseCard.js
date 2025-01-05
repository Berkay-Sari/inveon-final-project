import React from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

function CourseCard({ id, name, description, price, imageUrl }) {
    const truncateText = (text, maxLength) => {
        if (text.length > maxLength) {
            return text.substring(0, maxLength) + '...';
        }
        return text;
    };

    return (
        <div className="card h-100 position-relative">
            <Link to={`/course/${id}`} className="text-decoration-none text-dark">
                <img
                    src={`${axios.defaults.baseURL}/${imageUrl}`}
                    className="card-img-top"
                    alt={name}
                    style={{
                        height: '230px',
                        width: '100%',
                        objectFit: 'fill'
                    }}
                />
                <div className="card-body">
                    <h5 className="card-title">{name}</h5>
                    <p className="card-text">
                        {truncateText(description, 75)}
                    </p>
                    <p className="card-text">
                        <strong>Price:</strong> ${price}
                    </p>
                </div>
            </Link>
            <Link to={`/course/${id}`} className="btn btn-primary position-absolute"
                style={{ bottom: '10px', right: '10px' }}>
                Go to Details
            </Link>
        </div>
    );
}

export default CourseCard;
