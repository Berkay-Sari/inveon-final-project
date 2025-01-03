import React from 'react';
import { useNavigate } from 'react-router-dom';

const AccessDenied = () => {
    const navigate = useNavigate();

    return (
        <div className="container mt-5">
            <div className="alert alert-danger text-start shadow-sm" role="alert">
                <h1 className="h3">Access Denied</h1>
                <p className="mb-4">
                    You do not have the required permissions to view this page. Please contact your administrator if you believe this is an error.
                </p>
                <button
                    className="btn btn-primary btn-sm"
                    onClick={() => navigate('/')}
                >
                    Go Back to Home
                </button>
            </div>
        </div>
    );
};

export default AccessDenied;
