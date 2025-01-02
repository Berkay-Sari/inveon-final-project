function Footer() {
    return (
        <footer className="bg-dark text-light py-3 mt-5">
            <div className="container">
                <div className="row justify-content-between align-items-center">
                    <div className="col-md-6 text-md-start text-center">
                        <p className="mb-0">&copy; 2024 CourseMarket™</p>
                    </div>
                    <div className="col-md-6 text-md-end text-center">
                        <ul className="list-inline mb-0">
                            <li className="list-inline-item">
                                <a href="/" className="text-light text-decoration-none">Home</a>
                            </li>
                            <li className="list-inline-item ms-3">
                                <a href="/about" className="text-light text-decoration-none">About</a>
                            </li>
                            <li className="list-inline-item ms-3">
                                <a href="/contact" className="text-light text-decoration-none">Contact</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>
    );
}

export default Footer;
