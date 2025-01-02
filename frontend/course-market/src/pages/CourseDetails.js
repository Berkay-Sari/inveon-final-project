import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';

function CourseDetails() {
    const { id } = useParams();
    const [course, setCourse] = useState(null);

    useEffect(() => {
        // Fetch course details from API using Axios
        axios.get(`/api/courses/${id}`)
            .then((response) => setCourse(response.data))
            .catch((error) => console.error(error));
    }, [id]);

    if (!course) return <p>Loading...</p>;

    return (
        <div className="card">
            <div className="card-body">
                <h1 className="card-title">{course.name}</h1>
                <p className="card-text">{course.description}</p>
                <p className="card-text"><strong>{course.price} USD</strong></p>
                <button className="btn btn-success">Purchase</button>
            </div>
        </div>
    );
}

export default CourseDetails;