import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { AppContext } from '../context/AppContext';
import axios from 'axios';

function Login() {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const { setUser } = useContext(AppContext);
    const navigate = useNavigate();

    const handleLogin = (e) => {
        e.preventDefault();
        axios.post('/api/Auth', { userName, password })
            .then((response) => {
                if (response.status === 201 && response.data?.data) {
                    const { accessToken, refreshToken } = response.data.data;

                    localStorage.setItem('accessToken', accessToken);
                    localStorage.setItem('refreshToken', refreshToken);

                    console.log('Tokenler başarıyla kaydedildi.');

                    setUser(response.data.user);
                    navigate('/');
                } else {
                    console.error('Beklenmeyen yanıt formatı:', response);
                }
            })
            .catch((error) => console.error(error));
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
