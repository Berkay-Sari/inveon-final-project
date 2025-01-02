import React, { useContext } from 'react';
import { AppContext } from '../context/AppContext';

function Profile() {
    const { user } = useContext(AppContext);

    if (!user) return <p>Please log in to view your profile.</p>;

    return (
        <div>
            <h1 className="mb-4">Profile</h1>
            <div className="card mb-4">
                <div className="card-body">
                    <p><strong>Name:</strong> {user.name}</p>
                    <p><strong>Email:</strong> {user.email}</p>
                </div>
            </div>
            <h2>Your Courses</h2>
            <div className="list-group">
                {user.courses.map((course) => (
                    <div className="list-group-item" key={course.id}>
                        <p className="mb-1"><strong>{course.name}</strong></p>
                        <small>{course.date}</small>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Profile;