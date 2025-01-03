import React, { useContext } from 'react';
import { Navigate } from 'react-router-dom';
import { AppContext } from '../context/AppContext';

const ProtectedRoute = ({ children, role }) => {
    const { user } = useContext(AppContext);

    if (!user) {
        return <Navigate to="/login" />;
    }

    if (role && user.role !== role) {
        return <Navigate to="/access-denied" />;
    }

    return children;
};

export default ProtectedRoute;
