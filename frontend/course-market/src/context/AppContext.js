import React, { createContext, useState, useEffect } from 'react';
import { jwtDecode } from 'jwt-decode';
import axios from 'axios';

export const AppContext = createContext();

axios.defaults.baseURL = 'https://localhost:7180';

export const AppProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    useEffect(() => {
        if (!user) {
            const token = localStorage.getItem('accessToken');
            if (token) {
                try {
                    extractUserDetails(jwtDecode(token));
                } catch (error) {
                    console.error('Failed to decode token:', error);
                    handleLogout();
                }
            }
        }
    }, [user]);

    // Axios request interceptor: access tokenı istek gönderirken headera ekler
    axios.interceptors.request.use(
        (config) => {
            const token = localStorage.getItem('accessToken');
            if (token) {
                config.headers['Authorization'] = `Bearer ${token}`;
            }
            return config;
        },
        (error) => Promise.reject(error)
    );

    // Axios response interceptor : 401 hatası alınırsa refresh token ile yeni access token alır
    axios.interceptors.response.use(
        (response) => response,
        async (error) => {
            if (error.response && error.response.status === 401) {
                const originalRequest = error.config;

                if (!originalRequest._retry) {
                    originalRequest._retry = true;

                    const refreshToken = localStorage.getItem('refreshToken');
                    if (refreshToken) {
                        try {
                            const { data } = await axios.post('/api/Auth/refresh', {
                                refreshToken,
                            });

                            const { accessToken, refreshToken: newRefreshToken } = data;

                            localStorage.setItem('accessToken', accessToken);
                            localStorage.setItem('refreshToken', newRefreshToken);

                            extractUserDetails(jwtDecode(accessToken));

                            // Orijinal isteği yeni token ile tekrar gönder
                            originalRequest.headers['Authorization'] = `Bearer ${accessToken}`;
                            return axios(originalRequest);
                        } catch (refreshError) {
                            console.error('Error refreshing token:', refreshError);
                            handleLogout();
                        }
                    } else {
                        handleLogout();
                    }
                }
            }
            return Promise.reject(error);
        }
    );

    const handleLogout = () => {
        setUser(null);
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        window.location.href = '/login';
    };

    const extractUserDetails = (decodedToken) => {
        const id = decodedToken.sub;
        const name = decodedToken.unique_name;
        const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        setUser({ id, name, role });
    };

    return (
        <AppContext.Provider value={{ user, setUser, handleLogout, extractUserDetails }}>
            {children}
        </AppContext.Provider>
    );
};
