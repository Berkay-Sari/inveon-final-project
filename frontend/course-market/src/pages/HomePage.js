import React, { useContext, useEffect, useState } from 'react';
import { AppContext } from '../context/AppContext';
import axios from 'axios';
import CourseCard from '../components/CourseCard';

function HomePage() {
    const { courses, setCourses } = useContext(AppContext);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);

    useEffect(() => {
        const fetchCourses = async (page) => {
            try {
                const response = await axios.get(`/api/Courses?Page=${page}&Size=6`);
                setCourses(response.data.data.items);
                setTotalPages(response.data.data.totalPages);
            } catch (error) {
                console.error('Failed to fetch courses:', error);
            }
        };

        fetchCourses(currentPage);
    }, [currentPage, setCourses]);

    const handlePageChange = (page) => {
        setCurrentPage(page);
    };

    return (
        <div className="container mt-5">
            <h3 className="mb-4 d-flex justify-content-center">COURSES</h3>
            <div className="row">
                {courses.length > 0 ? (
                    courses.map((course) => (
                        <div className="col-md-4 mb-4" key={course.id}>
                            <CourseCard
                                id={course.id}
                                name={course.name}
                                description={course.description}
                                price={course.price}
                                imageUrl={course.imageUrl}
                            />
                        </div>
                    ))
                ) : (
                    <p>No courses available at the moment.</p>
                )}
            </div>

            {/* Pagination */}
            <nav>
                <ul className="pagination justify-content-center">
                    <li className={`page-item ${currentPage === 1 && 'disabled'}`}>
                        <button
                            className="page-link"
                            onClick={() => handlePageChange(currentPage - 1)}
                            disabled={currentPage === 1}
                        >
                            Previous
                        </button>
                    </li>
                    {Array.from({ length: totalPages }, (_, index) => (
                        <li
                            key={index + 1}
                            className={`page-item ${currentPage === index + 1 && 'active'}`}
                        >
                            <button
                                className="page-link"
                                onClick={() => handlePageChange(index + 1)}
                            >
                                {index + 1}
                            </button>
                        </li>
                    ))}
                    <li className={`page-item ${currentPage === totalPages && 'disabled'}`}>
                        <button
                            className="page-link"
                            onClick={() => handlePageChange(currentPage + 1)}
                            disabled={currentPage === totalPages}
                        >
                            Next
                        </button>
                    </li>
                </ul>
            </nav>
        </div>
    );
}

export default HomePage;