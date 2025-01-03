import React, { useState, useContext } from "react";
import axios from "axios";
import { AppContext } from '../context/AppContext';
import { Link } from "react-router-dom";


const CreateCourse = () => {
  const [formData, setFormData] = useState({
    Name: "",
    Description: "",
    Price: "",
    Category: "",
    Image: null,
  });

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState([]);
  const [success, setSuccess] = useState(false);
  const [newCourseId, setNewCourseId] = useState(null);


  const { user } = useContext(AppContext);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleFileChange = (e) => {
    setFormData({
      ...formData,
      Image: e.target.files[0],
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError([]);
    setSuccess(false);

    const postData = new FormData();
    postData.append("Name", formData.Name);
    postData.append("Description", formData.Description);
    postData.append("Price", formData.Price);
    postData.append("Category", formData.Category);
    postData.append("InstructorId", user.id);
    postData.append("Image", formData.Image);

    try {
      const response = await axios.post("/api/Courses", postData, {
        headers: {
          "Content-Type": "multipart/form-data",
          Authorization: "Bearer " + localStorage.getItem("accessToken"),
        },
      });
      console.log("Response:", response.data);
      setSuccess(true);
      setNewCourseId(response.data.data);
      
    } catch (err) {
      console.error("Error:", err);
      if (err.response && err.response.data && err.response.data.fail) {
        const fail = err.response.data.fail;
        const customError = `${fail.title}: ${fail.detail}`;
        setError([customError]);
      } else if (err.response && err.response.data && err.response.data.message) {
        setError([err.response.data.message]);
      } else {
        setError([err.message || "An unknown error occurred."]);
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-8 col-lg-6">
          <div className="card shadow-lg">
            <div className="card-header bg-primary text-white text-center">
              <h3>Create a New Course</h3>
            </div>
            <div className="card-body">
              <form onSubmit={handleSubmit}>
                <div className="mb-4">
                  <label htmlFor="Name" className="form-label fw-semibold">
                    Course Name
                  </label>
                  <input
                    type="text"
                    className="form-control form-control-lg"
                    id="Name"
                    name="Name"
                    value={formData.Name}
                    onChange={handleChange}
                    placeholder="Enter course name"
                    required
                  />
                </div>
                <div className="mb-4">
                  <label htmlFor="Description" className="form-label fw-semibold">
                    Description
                  </label>
                  <textarea
                    className="form-control form-control-lg"
                    id="Description"
                    name="Description"
                    value={formData.Description}
                    onChange={handleChange}
                    rows="4"
                    placeholder="Enter course description"
                    required
                  ></textarea>
                </div>
                <div className="mb-4">
                  <label htmlFor="Price" className="form-label fw-semibold">
                    Price
                  </label>
                  <input
                    type="number"
                    className="form-control form-control-lg"
                    id="Price"
                    name="Price"
                    value={formData.Price}
                    onChange={handleChange}
                    placeholder="Enter course price"
                    required
                  />
                </div>
                <div className="mb-4">
                  <label htmlFor="Category" className="form-label fw-semibold">
                    Category
                  </label>
                  <input
                    type="text"
                    className="form-control form-control-lg"
                    id="Category"
                    name="Category"
                    value={formData.Category}
                    onChange={handleChange}
                    placeholder="Enter course category"
                    required
                  />
                </div>
                <div className="mb-4">
                  <label htmlFor="Image" className="form-label fw-semibold">
                    Course Image
                  </label>
                  <input
                    type="file"
                    className="form-control form-control-lg"
                    id="Image"
                    name="Image"
                    onChange={handleFileChange}
                    required
                  />
                </div>
                <button
                  type="submit"
                  className="btn btn-primary btn-lg w-100"
                  disabled={loading}
                >
                  {loading ? "Submitting..." : "Create Course"}
                </button>
              </form>
              {success && (
                <div className="alert alert-success mt-4 text-center">
                  Course created successfully!{" "}
                  <Link to={`/course/${newCourseId}`} className="alert-link">
                    Go to Course
                  </Link>
                </div>
              )}
              {error.length > 0 && (
                <div className="alert alert-danger mt-4">
                  <h5 className="alert-heading">Validation Errors</h5>
                  <ul className="mb-0">
                    {error.map((errMsg, index) => (
                      <li key={index}>{errMsg}</li>
                    ))}
                  </ul>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CreateCourse;
