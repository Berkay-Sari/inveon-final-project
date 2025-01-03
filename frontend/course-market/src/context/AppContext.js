import React, { createContext, useState, useEffect } from 'react';
import { jwtDecode } from 'jwt-decode';
import axios from 'axios';


export const AppContext = createContext();

axios.defaults.baseURL = 'https://localhost:7180';

export const AppProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        if (!user) {
            const token = localStorage.getItem('accessToken');
            if (token) {
                try {
                    const decodedToken = jwtDecode(token);
                    const name = decodedToken.unique_name;
                    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
                    setUser({ name, role });
                } catch (error) {
                    console.error('Failed to decode token:', error);
                    localStorage.removeItem('accessToken');
                    localStorage.removeItem('refreshToken');
                }
            }
        }
    }, []);

    // Axios interceptor to add JWT token to headers
    axios.interceptors.request.use(
        (config) => {
            const token = localStorage.getItem('jwtToken');
            if (token) {
                config.headers['Authorization'] = `Bearer ${token}`;
            }
            return config;
        },
        (error) => Promise.reject(error)
    );

    const handleLogout = () => {
        setUser(null);
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
    };

    return (
        <AppContext.Provider value={{ user, setUser, courses, setCourses, handleLogout }}>
            {children}
        </AppContext.Provider>
    );
};
