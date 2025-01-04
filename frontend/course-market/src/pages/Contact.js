const Contact = () => {
    return (
        <div className="container my-5">
            <div className="row">
                <div className="col-md-8 offset-md-2 text-center">
                    <h1 className="display-4 mb-4">Contact Us</h1>
                    <p className="lead">
                        Have a question or concern? We'd love to hear from you!
                    </p>
                    <p className="text-muted">
                        Reach out to us at <a href="mailto:support@example.com">support@example.com</a> or use the form below to send us a message.
                    </p>
                    <div className="mt-4">
                        <a href="https://www.linkedin.com/in/berkaysarı" target="_blank" rel="noopener noreferrer" className="mx-2">
                            <i className="bi bi-linkedin" style={{ fontSize: '24px' }}></i>
                        </a>
                        <a href="https://www.github.com/Berkay-Sari" target="_blank" rel="noopener noreferrer" className="mx-2">
                            <i className="bi bi-github" style={{ fontSize: '24px' }}></i>
                        </a>
                        <a href="https://www.instagram.com/1.berkaysari" target="_blank" rel="noopener noreferrer" className="mx-2">
                            <i className="bi bi-instagram" style={{ fontSize: '24px' }}></i>
                        </a>
                    </div>
                    <button className="btn btn-primary mt-3" onClick={() => window.location.href = '/about'}>Learn About Us</button>
                </div>
            </div>
        </div>
    );
}

export default Contact;
