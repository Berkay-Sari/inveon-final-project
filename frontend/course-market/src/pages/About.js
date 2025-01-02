import React from 'react';

function About() {
    return (
        <div className="container my-5">
            <div className="row">
                <div className="col-md-8 offset-md-2 text-center">
                    <h1 className="display-4 mb-4">About Us</h1>
                    <p className="lead">
                        Welcome to our course market! We offer a variety of courses to help you learn and grow.
                    </p>
                    <p className="text-muted">
                        Our mission is to provide high-quality education to everyone, everywhere.
                    </p>
                    <button className="btn btn-primary mt-3" onClick={() => window.location.href = '/contact'}>Learn More</button>
                </div>
            </div>
        </div>
    );
}

export default About;
