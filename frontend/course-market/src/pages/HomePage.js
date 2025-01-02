import React, { useContext, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { AppContext } from '../context/AppContext';
import axios from 'axios';

function HomePage() {
    const { courses, setCourses } = useContext(AppContext);

    useEffect(() => {
        // Fetch courses from API using Axios
        axios.get('/api/courses')
            .then((response) => setCourses(response.data))
            .catch((error) => console.error(error));
    }, [setCourses]);

    return (
        <div>
            <h1 className="mb-4">Courses</h1>
            <div className="row">
                {courses.map((course) => (
                    <div className="col-md-4 mb-4" key={course.id}>
                        <div className="card h-100">
                            <div className="card-body">
                                <h5 className="card-title">{course.name}</h5>
                                <p className="card-text">{course.description}</p>
                                <p className="card-text"><strong>{course.price} USD</strong></p>
                                <Link className="btn btn-primary" to={`/course/${course.id}`}>Details</Link>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default HomePage;