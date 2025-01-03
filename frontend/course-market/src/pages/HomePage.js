import React, { useContext, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { AppContext } from '../context/AppContext';
import axios from 'axios';

function HomePage() {
    const { courses, setCourses } = useContext(AppContext);

    /*
    useEffect(() => {
        // Fetch courses from API using Axios
        axios.get('/api/courses')
            .then((response) => setCourses(response.data))
            .catch((error) => console.error(error));
    }, [setCourses]);
    */

    return (
        <div>
            <h1 className="mb-4">Courses</h1>
            <div className="row">
                
            </div>
        </div>
    );
}

export default HomePage;