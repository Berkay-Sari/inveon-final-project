import React, { useContext, useState, useEffect } from 'react';
import { AppContext } from '../context/AppContext';
import ProfileCourse from '../components/ProfileCourse';
import axios from 'axios';

function Profile() {
    const { user } = useContext(AppContext);
    const [editMode, setEditMode] = useState(false);
    const [profileData, setProfileData] = useState(null); // Kullanıcı bilgileri
    const [courses, setCourses] = useState([]); // Kullanıcının kursları
    const [purchaseHistory, setPurchaseHistory] = useState([]); // Satın alma geçmişi
    const [formData, setFormData] = useState({
        email: '',
        phoneNumber: '',
        password: '',
    });

    const fetchUserData = async () => {
        try {
            const response = await axios.get('/api/users');
            const userData = response.data.data;
            setProfileData(userData);
            setFormData({
                email: userData.email || '',
                phoneNumber: userData.phoneNumber || '',
                password: '',
            });

            // purchasedCourses ile kurs bilgilerini çek
            if (userData.purchasedCourses) {
                const courseIds = JSON.parse(userData.purchasedCourses);
                const courseRequests = courseIds.map((id) =>
                    axios.get(`/api/courses/${id}`)
                );
                const courseResponses = await Promise.all(courseRequests);
                const fetchedCourses = courseResponses.map((res) => res.data.data); // Response içindeki course verisi
                setCourses(fetchedCourses);
            }

            // Purchase history çek
            const purchaseResponse = await axios.get('/api/orders');
            console.log(purchaseResponse.data.data);
            setPurchaseHistory(purchaseResponse.data.data);
        } catch (error) {
            console.error('Error fetching user data or courses:', error);
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
    };

    const handleEditToggle = () => {
        setEditMode((prev) => !prev);
    };

    const handleSave = async () => {
        try {
            const updatedData = { email: formData.email, phoneNumber: formData.phoneNumber };
            await axios.put(`/api/users/${user?.id}`, updatedData);
            setEditMode(false);
            setProfileData((prev) => ({
                ...prev,
                ...updatedData,
            }));
        } catch (error) {
            console.error('Error updating profile:', error);
        }
    };

    if (!user) return <p className="alert alert-warning text-center">Please log in to view your profile.</p>;

    return (
        <div className="container mt-5">
            <h2 className="text-center mb-4">My Profile</h2>
            <div className="row">
                {/* Sol Taraf: Profil Bilgileri */}
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
                        </div>
                        <div className="mb-3">
                            <label className="form-label">Change Password</label>
                            <input
                                type="password"
                                name="password"
                                placeholder="Enter new password"
                                value={formData.password}
                                onChange={handleChange}
                                className="form-control"
                            />
                        </div>
                        {editMode && (
                            <div className="text-center">
                                <button className="btn btn-primary me-2" onClick={handleSave}>
                                    Save Changes
                                </button>
                                <button
                                    className="btn btn-secondary"
                                    onClick={() => setEditMode(false)}
                                >
                                    Cancel
                                </button>
                            </div>
                        )}
                    </div>
                </div>

                {/* Sağ Taraf: Kurslar */}
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

            {/* Dropdown: Satın Alma Geçmişi */}
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
