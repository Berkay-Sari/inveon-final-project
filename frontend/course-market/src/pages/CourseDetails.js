import React, { useContext, useEffect, useState } from "react";
import { AppContext } from "../context/AppContext";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";
import LoadingSpinner from "../components/LoadingSpinner";
import alertify from "alertifyjs";

const CourseDetails = () => {
  const { user } = useContext(AppContext);
  const [course, setCourse] = useState(null);
  const [loading, setLoading] = useState(true);
  const [userCourses, setUserCourses] = useState([]);
  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCourseDetails = async () => {
      setLoading(true);
      try {
        const courseResponse = await axios.get(`/api/courses/${id}`);
        setCourse(courseResponse.data.data);

        if (user) {
          const userCoursesResponse = await axios.get(`/api/users/courses`);
          setUserCourses(userCoursesResponse.data.data || []);
        }
      } catch (error) {
        console.error("Error fetching course details or user courses:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchCourseDetails();
  }, [id, user]);

  const handlePurchase = async () => {
    if (!user) {
      alertify.error("You need to log in to purchase this course.");
      navigate(`/login?redirect=/course/${id}`);
      return;
    }

    try {
      const response = await axios.post(`/api/Baskets/${id}`);
      if (response.status === 204) {
        alertify.success("Course successfully added to your basket!");
      } else {
        alertify.error("Failed to add the course to the basket. Please try again.");
      }
    } catch (error) {
      console.error("Error adding course to basket:", error);
      if (error.response && error.response.status === 400) {
        alertify.error(error.response.data.fail.title);
      } else {
        alertify.error("An unexpected error occurred. Please try again.");
      }
    }
  };

  if (loading) {
    return <LoadingSpinner />;
  }

  if (!course) {
    return <div className="text-center mt-5">Course not found.</div>;
  }

  const isOwned = userCourses.includes(id);

  return (
    <div className="container mt-5">
      <button className="btn btn-secondary mb-3" onClick={() => navigate("/")}>
        Go Back To Courses
      </button>
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
                {isOwned ? (
                  <div className="alert alert-success mt-5" role="alert">
                    You have this course. Start learning!
                  </div>
                ) : (
                  <button
                    className="btn btn-primary btn-lg mt-5"
                    onClick={handlePurchase}
                  >
                    Purchase Now
                  </button>
                )}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CourseDetails;
