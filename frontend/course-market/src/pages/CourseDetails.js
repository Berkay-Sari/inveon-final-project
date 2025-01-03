import React, { useContext, useEffect, useState } from "react";
import { AppContext } from "../context/AppContext";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

const CourseDetails = () => {
  const { user } = useContext(AppContext);
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
      navigate("/login");
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
      <div className="card shadow">
        <div className="row g-0">
          <div className="col-md-5">
            <img
              src={`${axios.defaults.baseURL}/${course.imageUrl}`}
              className="img-fluid rounded-start"
              alt={course.name}
            />
          </div>
          <div className="col-md-7">
            <div className="card-body d-flex flex-column">
              <h1 className="card-title fw-bold">{course.name}</h1>
              <p className="card-text text-muted">{course.description}</p>
              <ul className="list-group list-group-flush">
                <li className="list-group-item">
                  <strong>Category:</strong> {course.category}
                </li>
                <li className="list-group-item">
                  <strong>Price:</strong> ${course.price}
                </li>
                <li className="list-group-item">
                  <strong>Instructor:</strong> {course.instructorName}
                </li>
              </ul>
              <div className="mt-auto">
                <button
                  className="btn btn-primary btn-lg mt-5"
                  onClick={handlePurchase}
                >
                  Purchase Now
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CourseDetails;