import React from 'react';
import { useNavigate } from 'react-router-dom';

function ProfileCourse({ course, id }) {
    const navigate = useNavigate();

    const handleCourseClick = () => {
        navigate(`/course/${id}`);
    };

    return (
        <div
            className="card mb-3"
            role="button"
            onClick={handleCourseClick}
            style={{ cursor: 'pointer' }}
        >
            <div className="row g-0">
                <div className="col-md-4">
                    <img
                        src={course.imageUrl}
                        alt={course.name}
                        className="img-fluid rounded-start"
                    />
                </div>
                <div className="col-md-8">
                    <div className="card-body">
                        <h5 className="card-title">{course.name}</h5>
                        <p className="card-text">Category: {course.category}</p>
                        <p className="card-text">Instructor: {course.instructorName}</p>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ProfileCourse;
