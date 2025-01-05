import React, { useContext, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { AppContext } from '../context/AppContext';
import { jwtDecode } from "jwt-decode";
import 'alertifyjs/build/css/alertify.css';
import 'alertifyjs/build/css/themes/default.css';
import alertify from 'alertifyjs';
import axios from 'axios';

function Login() {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const { extractUserDetails } = useContext(AppContext);
    const navigate = useNavigate();
    const location = useLocation();

    const handleLogin = (e) => {
        e.preventDefault();
        axios.post('/api/Auth/login', { userName, password })
            .then((response) => {
                if (response.status === 201 && response.data?.data) {
                    const { accessToken, refreshToken } = response.data.data;

                    localStorage.setItem('accessToken', accessToken);
                    localStorage.setItem('refreshToken', refreshToken);

                    alertify.success('Login successful!');
                    try {
                        extractUserDetails(jwtDecode(accessToken));
                    } catch (error) {
                        console.error('Error decoding accessToken:', error);
                        alertify.error('Server error. Please try again.');
                    }
                    const redirectUrl = new URLSearchParams(location.search).get("redirect");
                    navigate(redirectUrl || "/");
                } else {
                    alertify.error('Server error. Please try again.');
                }
            })
            .catch((error) => {
                console.error('Error:', error);
                if (error.response && error.response.status === 400) {
                    alertify.error(error.response.data.fail.detail);
                } else {
                    alertify.error('An unexpected error occurred. Please try again.');
                }
            });
    };

    return (
        <div className="d-flex justify-content-center align-items-center vh-100">
            <div className="card shadow-lg p-4" style={{ width: '24rem' }}>
                <form onSubmit={handleLogin}>
                    <h2 className="mb-4 text-center text-primary">Login</h2>
                    <div className="mb-3">
                        <label htmlFor="username" className="form-label">Username</label>
                        <input
                            type="text"
                            id="username"
                            className="form-control"
                            placeholder="Enter your username"
                            value={userName}
                            onChange={(e) => setUserName(e.target.value)}
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="password" className="form-label">Password</label>
                        <input
                            type="password"
                            id="password"
                            className="form-control"
                            placeholder="Enter your password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-100">Login</button>
                </form>
            </div>
        </div>
    );
}

export default Login;
