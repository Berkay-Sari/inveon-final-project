import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AppProvider } from './context/AppContext';
import Navbar from './components/Navbar';
import Footer from './components/Footer';
import ProtectedRoute from './components/ProtectedRoute';
import HomePage from './pages/HomePage';
import CourseDetails from './pages/CourseDetails';
import CreateCourse from './pages/CreateCourse';
import Profile from './pages/Profile';
import Login from './pages/Login';
import Register from './pages/Register';
import About from './pages/About';
import Contact from './pages/Contact';
import AccessDenied from './pages/AccessDenied';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
    return (
        <AppProvider>
            <Router>
                <div className="d-flex flex-column vh-100">
                    <Navbar />
                    <main className="flex-grow-1 container my-3">
                        <Routes>
                            <Route path="/" element={<HomePage />} />
                            <Route path="/course/:id" element={<CourseDetails />} />
                            <Route
                                path="/create-course"
                                element={
                                    <ProtectedRoute role="Instructor">
                                        <CreateCourse />
                                    </ProtectedRoute>
                                }
                            />
                            <Route path="/profile" element={<Profile />} />
                            <Route path="/login" element={<Login />} />
                            <Route path="/register" element={<Register />} />
                            <Route path="/about" element={<About />} />
                            <Route path="/contact" element={<Contact />} />
                            <Route path="/access-denied" element={<AccessDenied />} />;
                        </Routes>
                    </main>
                    <Footer/>
                </div>
            </Router>
        </AppProvider>
    );
}

export default App;
