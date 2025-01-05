import React, { useContext, useState, useEffect } from 'react';
import { AppContext } from '../context/AppContext';
import ProfileCourse from '../components/ProfileCourse';
import LoadingSpinner from '../components/LoadingSpinner';
import axios from 'axios';
import alertify from 'alertifyjs';

function Profile() {
    const { user } = useContext(AppContext);
    const [editMode, setEditMode] = useState(false);
    const [profileData, setProfileData] = useState(null);
    const [courses, setCourses] = useState([]);
    const [purchaseHistory, setPurchaseHistory] = useState([]);
    const [loading, setLoading] = useState(true);
    const [formLoading, setFormLoading] = useState(false);
    const [passwordLoading, setPasswordLoading] = useState(false);
    const [formData, setFormData] = useState({
        email: '',
        phoneNumber: '',
    });
    const [formErrors, setFormErrors] = useState({
        email: '',
        phoneNumber: '',
    });
    const [passwordData, setPasswordData] = useState({
        currentPassword: '',
        newPassword: '',
        confirmPassword: '',
    });
    const [passwordErrors, setPasswordErrors] = useState({
        currentPassword: '',
        newPassword: '',
        confirmPassword: '',
    });

    const fetchUserData = async () => {
        setLoading(true);
        try {
            const response = await axios.get('/api/users');
            const userData = response.data.data;
            setProfileData(userData);
            setFormData({
                email: userData.email || '',
                phoneNumber: userData.phoneNumber || '',
            });

            if (userData.purchasedCourses) {
                const courseIds = JSON.parse(userData.purchasedCourses);
                const courseRequests = courseIds.map((id) =>
                    axios.get(`/api/courses/${id}`)
                );
                const courseResponses = await Promise.all(courseRequests);
                const fetchedCourses = courseResponses.map((res) => res.data.data);
                setCourses(fetchedCourses);
            }

            const purchaseResponse = await axios.get('/api/orders');
            setPurchaseHistory(purchaseResponse.data.data);
        } catch (error) {
            console.error('Error fetching user data or courses:', error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        if (user) {
            fetchUserData();
        }
    }, [user]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
        setFormErrors((prevErrors) => ({
            ...prevErrors,
            [name]: '',
        }));
    };

    const handleEditToggle = () => {
        setEditMode((prev) => !prev);
    };

    const validateForm = () => {
        let valid = true;
        const errors = {};

        if (!formData.email) {
            errors.email = "Email can't be empty.";
            valid = false;
        } else if (!/\S+@\S+\.\S+/.test(formData.email)) {
            errors.email = 'Email is not valid.';
            valid = false;
        }

        if (formData.phoneNumber) {
            if (!/^(\+?[0-9]{10,15})$/.test(formData.phoneNumber)) {
                errors.phoneNumber = 'Phone number is not valid.';
                valid = false;
            }
        }

        setFormErrors(errors);
        return valid;
    };

    const handleSave = async () => {
        if (!validateForm()) {
            return;
        }

        setFormLoading(true);

        try {
            const updatedData = { email: formData.email, phoneNumber: formData.phoneNumber };
            await axios.put('/api/users', updatedData);
            setEditMode(false);
            setProfileData((prev) => ({
                ...prev,
                ...updatedData,
            }));
            alertify.success('Profile updated successfully.');
        } catch (error) {
            console.error('Error updating profile:', error);
        } finally {
            setFormLoading(false);
        }
    };

    const handlePasswordChange = (e) => {
        const { name, value } = e.target;
        setPasswordData((prev) => ({
            ...prev,
            [name]: value,
        }));
        setPasswordErrors((prevErrors) => ({
            ...prevErrors,
            [name]: '',
        }));
    };

    const validatePassword = () => {
        let valid = true;
        const errors = {};

        if (!passwordData.currentPassword) {
            errors.currentPassword = "Current password can't be empty.";
            valid = false;
        }

        if (!passwordData.newPassword || passwordData.newPassword.length < 6 ||
            !/[a-zA-Z]/.test(passwordData.newPassword) || !/\d/.test(passwordData.newPassword)) {
            errors.newPassword = 'New password must be at least 6 characters long, with letters and numbers.';
            valid = false;
        }

        if (passwordData.newPassword !== passwordData.confirmPassword) {
            errors.confirmPassword = 'Passwords do not match.';
            valid = false;
        }

        setPasswordErrors(errors);
        return valid;
    };

    const handlePasswordSubmit = async () => {
        if (!validatePassword()) return;

        setPasswordLoading(true);

        try {
            await axios.put('/api/Users/change-password', {
                currentPassword: passwordData.currentPassword,
                newPassword: passwordData.newPassword,
            });
            alertify.success('Password changed successfully.');
            setPasswordData({
                currentPassword: '',
                newPassword: '',
                confirmPassword: '',
            });
        } catch (error) {
            console.error('Error changing password:', error);
            setPasswordErrors((prev) => ({
                ...prev,
                currentPassword: 'Current password is incorrect.',
            }));
        } finally {
            setPasswordLoading(false); 
        }
    };

    if (!user) return <p className="alert alert-warning text-center mt-5">Please log in to view your profile.</p>;

    if (loading) return <LoadingSpinner />;

    return (
        <div className="container mt-5">
            <h2 className="text-center mb-4">My Profile</h2>
            <div className="row">
                <div className="col-md-6">
                    <div className="card p-4">
                        <h4>Profile Information</h4>
                        <div className="mb-3">
                            <label className="form-label">Full Name</label>
                            <h3 className="fw-bold text-primary">{profileData?.fullName || 'Loading...'}</h3>
                        </div>
                        <div className="mb-3">
                            <label className="form-label">Email</label>
                            <div className="d-flex align-items-center">
                                <input
                                    type="email"
                                    name="email"
                                    value={formData.email}
                                    onChange={handleChange}
                                    disabled={!editMode}
                                    className="form-control"
                                />
                                <i
                                    className="bi bi-pencil-fill ms-2 text-primary"
                                    role="button"
                                    onClick={handleEditToggle}
                                ></i>
                            </div>
                            {formErrors.email && <div className="text-danger">{formErrors.email}</div>}
                        </div>
                        <div className="mb-3">
                            <label className="form-label">Phone Number</label>
                            <div className="d-flex align-items-center">
                                <input
                                    type="text"
                                    name="phoneNumber"
                                    value={formData.phoneNumber}
                                    onChange={handleChange}
                                    disabled={!editMode}
                                    className="form-control"
                                />
                                <i
                                    className="bi bi-pencil-fill ms-2 text-primary"
                                    role="button"
                                    onClick={handleEditToggle}
                                ></i>
                            </div>
                            {formErrors.phoneNumber && <div className="text-danger">{formErrors.phoneNumber}</div>}
                        </div>
                        {editMode && (
                            <div className="text-center">
                                {formLoading ? (
                                    <p className="text-muted">Updating profile, please wait...</p>
                                ) : (
                                    <>
                                        <button className="btn btn-primary me-2" onClick={handleSave}>
                                            Save Changes
                                        </button>
                                        <button
                                            className="btn btn-secondary"
                                            onClick={() => setEditMode(false)}
                                        >
                                            Cancel
                                        </button>
                                    </>
                                )}
                            </div>
                        )}
                        <hr />
                        <h4>Change Password</h4>
                        <div className="mb-3">
                            <label className="form-label">Current Password</label>
                            <input
                                type="password"
                                name="currentPassword"
                                value={passwordData.currentPassword}
                                onChange={handlePasswordChange}
                                className="form-control"
                            />
                            {passwordErrors.currentPassword && <div className="text-danger">{passwordErrors.currentPassword}</div>}
                        </div>
                        <div className="mb-3">
                            <label className="form-label">New Password</label>
                            <input
                                type="password"
                                name="newPassword"
                                value={passwordData.newPassword}
                                onChange={handlePasswordChange}
                                className="form-control"
                            />
                            {passwordErrors.newPassword && <div className="text-danger">{passwordErrors.newPassword}</div>}
                        </div>
                        <div className="mb-3">
                            <label className="form-label">Confirm New Password</label>
                            <input
                                type="password"
                                name="confirmPassword"
                                value={passwordData.confirmPassword}
                                onChange={handlePasswordChange}
                                className="form-control"
                            />
                            {passwordErrors.confirmPassword && <div className="text-danger">{passwordErrors.confirmPassword}</div>}
                        </div>
                        <div className="text-center">
                            {passwordLoading ? (
                                <p className="text-muted">Updating password, please wait...</p>
                            ) : (
                                <button className="btn btn-primary" onClick={handlePasswordSubmit}>
                                    Change Password
                                </button>
                            )}
                        </div>
                    </div>
                </div>
                <div className="col-md-6">
                    <div className="card p-4">
                        <h4>My Courses</h4>
                        {courses.length > 0 ? (
                            courses.map((course) => (
                                <ProfileCourse key={course.id} course={course} id={course.id} />
                            ))
                        ) : (
                            <p className="text-muted">You have no courses.</p>
                        )}
                    </div>
                </div>
            </div>
            <div className="row mt-4">
                <div className="col-12">
                    <div className="card p-4">
                        <h4>Purchase History</h4>
                        <div className="dropdown">
                            <button
                                className="btn btn-secondary dropdown-toggle"
                                type="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                View Purchase History
                            </button>
                            <ul className="dropdown-menu">
                                {purchaseHistory.length > 0 ? (
                                    purchaseHistory.map((purchase, index) => (
                                        <li key={index} className="dropdown-item">
                                            <h6>Order Code: {purchase.orderCode}</h6>
                                            <p>Purchase Date: {new Date(purchase.date).toLocaleDateString()}</p>
                                            <ul>
                                                {purchase.courses.map((course) => (
                                                    <li key={course.id}>
                                                        {course.name} - ${course.price}
                                                    </li>
                                                ))}
                                            </ul>
                                            <hr />
                                        </li>
                                    ))
                                ) : (
                                    <li className="dropdown-item text-muted">No purchase history available.</li>
                                )}
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Profile;
