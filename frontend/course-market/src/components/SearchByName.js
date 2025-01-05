import React, { useState } from "react";
import axios from "axios";

function SearchByName({ setCourses, setTotalPages, setCurrentPage, setSearchTerm }) {
  const [localSearchTerm, setLocalSearchTerm] = useState("");

  const handleSearch = async () => {
    try {
      setSearchTerm(localSearchTerm); // Update search term in HomePage
      const response = await axios.get(
        `/api/Courses/filter-by-name?name=${localSearchTerm}&Page=1&Size=6`
      );
      setCourses(response.data.data.items);
      setTotalPages(response.data.data.totalPages);
      setCurrentPage(1);
    } catch (error) {
      console.error("Failed to fetch courses:", error);
    }
  };

  const handleKeyDown = (e) => {
    if (e.key === "Enter") {
      handleSearch();
    }
  };

  return (
    <div className="search-container" style={{ position: "relative", marginBottom: "1rem" }}>
      <input
        type="text"
        className="form-control"
        placeholder="Search by name..."
        value={localSearchTerm}
        onChange={(e) => setLocalSearchTerm(e.target.value)}
        onKeyDown={handleKeyDown}
        style={{
          width: "100%",
          paddingRight: "40px",
          paddingLeft: "10px",
          borderRadius: "4px",
        }}
      />
      <span
        onClick={handleSearch}
        style={{
          position: "absolute",
          right: "10px",
          top: "50%",
          transform: "translateY(-50%)",
          cursor: "pointer",
        }}
      >
        <svg
          className="svg-icon search-icon"
          aria-labelledby="title desc"
          role="img"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 19.9 19.7"
          style={{ width: "24px", height: "24px", fill: "gray" }}
        >
          <title id="title">Search Icon</title>
          <desc id="desc">A magnifying glass icon.</desc>
          <g className="search-path" fill="none" stroke="#848F91">
            <path strokeLinecap="square" d="M18.5 18.3l-5.4-5.4" />
            <circle cx="8" cy="8" r="7" />
          </g>
        </svg>
      </span>
    </div>
  );
}

export default SearchByName;
