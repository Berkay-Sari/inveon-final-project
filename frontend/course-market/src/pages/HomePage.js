import React, { useContext, useEffect, useState } from "react";
import { AppContext } from "../context/AppContext";
import axios from "axios";
import CourseCard from "../components/CourseCard";
import SearchByName from "../components/SearchByName";
import SearchByCategory from "../components/SearchByCategory";
import LoadingSpinner from "../components/LoadingSpinner";

function HomePage() {
    const { courses, setCourses } = useContext(AppContext);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [loading, setLoading] = useState(true);
    const [isSearchActive, setIsSearchActive] = useState(false);
    const [searchTerm, setSearchTerm] = useState("");
    const [categoryTerm, setCategoryTerm] = useState("");

    useEffect(() => {
        const fetchCourses = async () => {
            setLoading(true);
            try {
                let response;
                if (isSearchActive) {
                    if (categoryTerm) {
                        response = await axios.get(
                            `/api/Courses/filter-by-category?category=${categoryTerm}&Page=${currentPage}&Size=6`
                        );
                    } else {
                        response = await axios.get(
                            `/api/Courses/filter-by-name?name=${searchTerm}&Page=${currentPage}&Size=6`
                        );
                    }
                } else {
                    response = await axios.get(`/api/Courses?Page=${currentPage}&Size=6`);
                }
                setCourses(response.data.data.items);
                setTotalPages(response.data.data.totalPages);
            } catch (error) {
                console.error("Failed to fetch courses:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchCourses();
    }, [currentPage, isSearchActive, searchTerm, categoryTerm, setCourses]);

    const handlePageChange = (page) => {
        setCurrentPage(page);
    };

    const resetSearch = () => {
        setSearchTerm("");
        setCategoryTerm("");
        setIsSearchActive(false);
        setCurrentPage(1);
    };

    const getHeaderTitle = () => {
        if (isSearchActive) {
            if (categoryTerm) return `COURSES (${categoryTerm})`;
            if (searchTerm) return `COURSES (${searchTerm})`;
        }
        return "COURSES";
    };

    if (loading) {
        return <LoadingSpinner />;
    }

    return (
        <div className="container mt-5">
            <div className="d-flex justify-content-between align-items-center">
                <h3>{getHeaderTitle()}</h3>
                <div className="d-flex">
                    <SearchByCategory
                        setCourses={(data) => {
                            setCourses(data);
                            setIsSearchActive(true);
                        }}
                        setTotalPages={setTotalPages}
                        setCurrentPage={(page) => {
                            setCurrentPage(page);
                            setIsSearchActive(true);
                        }}
                        setCategoryTerm={setCategoryTerm}
                    />
                    <SearchByName
                        setCourses={(data) => {
                            setCourses(data);
                            setIsSearchActive(true);
                        }}
                        setTotalPages={setTotalPages}
                        setCurrentPage={(page) => {
                            setCurrentPage(page);
                            setIsSearchActive(true);
                        }}
                        setSearchTerm={setSearchTerm}
                    />
                    {isSearchActive && (
                        <button
                            onClick={resetSearch}
                            className="btn btn-link ms-3"
                        >
                            Reset Search
                        </button>
                    )}
                </div>
            </div>
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
            <nav>
                <ul className="pagination justify-content-center">
                    <li className={`page-item ${currentPage === 1 && "disabled"}`}>
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
                            className={`page-item ${currentPage === index + 1 && "active"}`}
                        >
                            <button className="page-link" onClick={() => handlePageChange(index + 1)}>
                                {index + 1}
                            </button>
                        </li>
                    ))}
                    <li className={`page-item ${currentPage === totalPages && "disabled"}`}>
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