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
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" viewBox="0 0 24 24">
                                <path d="M19 0h-14c-2.761 0-5 2.239-5 5v14c0 2.761 2.239 5 5 5h14c2.761 0 5-2.239 5-5v-14c0-2.761-2.239-5-5-5zm-11 19h-3v-9h3v9zm-1.5-10.271c-.966 0-1.75-.787-1.75-1.75s.784-1.75 1.75-1.75 1.75.787 1.75 1.75-.784 1.75-1.75 1.75zm13.5 10.271h-3v-4.5c0-1.107-.893-2-2-2s-2 .893-2 2v4.5h-3v-9h3v1.341c.87-.631 1.919-1.341 3-1.341 2.481 0 4 2.019 4 4.5v4.5z"/>
                            </svg>
                        </a>
                        <a href="https://www.github.com/Berkay-Sari" target="_blank" rel="noopener noreferrer" className="mx-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" viewBox="0 0 24 24">
                                <path d="M12 .297c-6.63 0-12 5.373-12 12 0 5.303 3.438 9.8 8.205 11.385.6.113.82-.258.82-.577 0-.285-.01-1.04-.015-2.04-3.338.726-4.042-1.415-4.042-1.415-.546-1.385-1.333-1.754-1.333-1.754-1.09-.744.083-.729.083-.729 1.205.084 1.838 1.236 1.838 1.236 1.07 1.835 2.807 1.305 3.492.998.108-.776.418-1.305.762-1.605-2.665-.3-5.466-1.333-5.466-5.93 0-1.31.468-2.38 1.235-3.22-.123-.303-.535-1.523.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.005-.404 1.022.005 2.048.138 3.006.404 2.291-1.552 3.298-1.23 3.298-1.23.653 1.653.242 2.873.12 3.176.77.84 1.234 1.91 1.234 3.22 0 4.61-2.804 5.625-5.475 5.92.429.372.823 1.102.823 2.222 0 1.606-.014 2.896-.014 3.286 0 .322.216.694.824.576 4.765-1.585 8.2-6.082 8.2-11.384 0-6.627-5.373-12-12-12z"/>
                            </svg>
                        </a>
                        <a href="https://www.instagram.com/1.berkaysari" target="_blank" rel="noopener noreferrer" className="mx-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" viewBox="0 0 24 24">
                                <path d="M12 2.163c3.204 0 3.584.012 4.849.07 1.366.062 2.633.337 3.608 1.311.974.974 1.249 2.242 1.31 3.607.059 1.265.069 1.645.069 4.849s-.011 3.584-.069 4.849c-.061 1.366-.336 2.633-1.31 3.607-.975.974-2.242 1.249-3.608 1.311-1.265.059-1.645.069-4.849.069s-3.584-.011-4.849-.069c-1.366-.061-2.633-.336-3.607-1.311-.974-.975-1.249-2.242-1.311-3.607-.059-1.265-.069-1.645-.069-4.849s.012-3.584.07-4.849c.062-1.366.337-2.633 1.311-3.608.974-.974 2.242-1.249 3.607-1.31 1.265-.059 1.645-.07 4.849-.07zm0-2.163c-3.257 0-3.667.013-4.947.072-1.473.068-2.904.39-3.993 1.48-1.089 1.089-1.411 2.52-1.479 3.993-.059 1.28-.072 1.69-.072 4.947s.013 3.667.072 4.947c.068 1.473.39 2.904 1.479 3.993 1.089 1.089 2.52 1.411 3.993 1.479 1.28.059 1.69.072 4.947.072s3.667-.013 4.947-.072c1.473-.068 2.904-.39 3.993-1.479 1.089-1.089 1.411-2.52 1.479-3.993.059-1.28.072-1.69.072-4.947s-.013-3.667-.072-4.947c-.068-1.473-.39-2.904-1.479-3.993-1.089-1.089-2.52-1.411-3.993-1.479-1.28-.059-1.69-.072-4.947-.072zm0 5.838c-3.256 0-5.898 2.642-5.898 5.899s2.642 5.899 5.898 5.899 5.898-2.642 5.898-5.899-2.642-5.899-5.898-5.899zm0 9.665c-2.081 0-3.766-1.685-3.766-3.766s1.685-3.766 3.766-3.766 3.766 1.685 3.766 3.766-1.685 3.766-3.766 3.766zm6.406-10.845c-.796 0-1.441.645-1.441 1.441s.645 1.441 1.441 1.441 1.441-.645 1.441-1.441-.645-1.441-1.441-1.441z"/>
                            </svg>
                        </a>
                    </div>
                    <button className="btn btn-primary mt-3" onClick={() => window.location.href = '/about'}>Learn About Us</button>
                </div>
            </div>
        </div>
    );
}

export default Contact;
