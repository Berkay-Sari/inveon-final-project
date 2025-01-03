import React, { useContext } from 'react';
import { AppContext } from '../context/AppContext';

function Profile() {
    const { user } = useContext(AppContext);

    if (!user) return <p>Please log in to view your profile.</p>;

    return (
        <div>
            <h1 className="mb-4">Profile</h1>
            <p><strong>ID:</strong> {user.id}</p>
            <p><strong>Name:</strong> {user.name}</p>
            <p><strong>Role:</strong> {user.role}</p>
        </div>
    );
}

export default Profile;