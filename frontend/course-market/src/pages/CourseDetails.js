import React, { useContext, useEffect, useState } from "react";
import { AppContext } from "../context/AppContext"; // Import AppContext
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

const CourseDetails = () => {
  const { user } = useContext(AppContext); // Get user information from AppContext
  const [course, setCourse] = useState(null);
  const [loading, setLoading] = useState(true);
  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(`api/courses/${id}`)
      .then((response) => {
        setCourse(response.data.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching course details:", error);
        setLoading(false);
      });
  }, [id]);

  const handlePurchase = () => {
    if (!user) {
      alert("You need to log in to purchase this course.");
      navigate("/login"); // Redirect to login page
    } else {
      alert("Course successfully purchased!");
      // API call for purchase can be made here
    }
  };

  if (loading) {
    return <div className="text-center mt-5">Loading...</div>;
  }

  if (!course) {
    return <div className="text-center mt-5">Course not found.</div>;
  }

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="row g-0">
          <div className="col-md-4">
            <img
            //axios get base url
        
                src={`${axios.defaults.baseURL}/${course.imageUrl}`}
              className="img-fluid rounded-start"
              alt={course.name}
            />
          </div>
          <div className="col-md-8">
            <div className="card-body">
              <h5 className="card-title">{course.name}</h5>
              <p className="card-text">{course.description}</p>
              <p className="card-text">
                <strong>Category:</strong> {course.category}
              </p>
              <p className="card-text">
                <strong>Price:</strong> ${course.price}
              </p>
              <button
                className="btn btn-primary"
                onClick={handlePurchase}
              >
                Purchase
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CourseDetails;