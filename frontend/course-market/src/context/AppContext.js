import React, { createContext, useState } from 'react';
import axios from 'axios';


export const AppContext = createContext();

axios.defaults.baseURL = 'https://localhost:7180';

export const AppProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [courses, setCourses] = useState([]);

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

    return (
        <AppContext.Provider value={{ user, setUser, courses, setCourses }}>
            {children}
        </AppContext.Provider>
    );
};
