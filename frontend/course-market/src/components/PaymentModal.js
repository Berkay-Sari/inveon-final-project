import React, { useState } from 'react';
import alertify from 'alertifyjs';
import axios from 'axios';

const PaymentModal = ({ show, totalAmount, onClose, onPaymentSuccess, setOrderCode}) => {
    const [cardDetails, setCardDetails] = useState({
        number: "",
        name: "",
        expiry: "",
        cvc: "",
    });

    const [errors, setErrors] = useState({});
    const [isPaymentSuccessful, setIsPaymentSuccessful] = useState(true); 

    if (!show) {
        return null; 
    }

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setCardDetails({ ...cardDetails, [name]: value });
    };

    const validateCardNumber = (number) => {
        let sum = 0;
        let shouldDouble = false;
        for (let i = number.length - 1; i >= 0; i--) {
            let digit = parseInt(number[i], 10);
            if (shouldDouble) {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }
            sum += digit;
            shouldDouble = !shouldDouble;
        }
        return sum % 10 === 0;
    };

    const validateExpiry = (expiry) => {
        const [month, year] = expiry.split("/").map(Number);
        const currentDate = new Date();
        const enteredDate = new Date(`20${year}`, month - 1);
        return month > 0 && month <= 12 && enteredDate >= currentDate;
    };

    const validateCVC = (cvc) => /^\d{3,4}$/.test(cvc);

    const validateForm = () => {
        const newErrors = {};

        if (!cardDetails.number || !validateCardNumber(cardDetails.number.replace(/\s/g, ""))) {
            newErrors.number = "Invalid card number";
        }
        if (!cardDetails.name) {
            newErrors.name = "Name on card is required";
        }
        if (!cardDetails.expiry || !validateExpiry(cardDetails.expiry)) {
            newErrors.expiry = "Invalid expiry date. Format: MM/YY";
        }
        if (!cardDetails.cvc || !validateCVC(cardDetails.cvc)) {
            newErrors.cvc = "CVC must be 3 or 4 digits";
        }

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0;
    };

    const handlePayment = async (e) => {
        e.preventDefault();
        if (validateForm()) {
            try {
                var response = await axios.post('/api/Payments', null, {
                    params: { isSuccess : isPaymentSuccessful },
                    headers: { 'Content-Type': 'application/json' },
                });
                setOrderCode(response.data.data);
                onPaymentSuccess();
                onClose();
            } catch (error) {
                alertify.error(error.response.data.fail.detail);
            } 
        } else {
            alertify.error("Please fix the errors in the form");
        }
    };

    return (
        <div className="modal fade show d-block" tabIndex="-1" role="dialog">
            <div className="modal-dialog modal-dialog-centered" role="document">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title">Payment Details</h5>
                        <button type="button" className="btn-close" onClick={onClose}></button>
                    </div>
                    <div className="modal-body">
                        <p className="text-center mb-3">
                            Total amount: <strong>${totalAmount.toFixed(2)}</strong>
                        </p>
                        <div className="text-center mb-4">
                            <img
                                src="https://upload.wikimedia.org/wikipedia/commons/a/a4/Mastercard_2019_logo.svg"
                                alt="Mastercard"
                                style={{ height: '30px', marginRight: '10px' }}
                            />
                            <img
                                src="https://upload.wikimedia.org/wikipedia/commons/0/04/Visa.svg"
                                alt="Visa"
                                style={{ height: '30px' }}
                            />
                        </div>
                        <div className="mb-4 text-center">
                            <label className="form-label me-2">Payment Outcome:</label>
                            <div className="form-check form-switch d-inline-block">
                                <input
                                    className="form-check-input"
                                    type="checkbox"
                                    id="paymentToggle"
                                    checked={isPaymentSuccessful}
                                    onChange={() => setIsPaymentSuccessful(!isPaymentSuccessful)}
                                />
                                <label
                                    className="form-check-label ms-2"
                                    htmlFor="paymentToggle"
                                >
                                    {isPaymentSuccessful ? 'Successful' : 'Failed'}
                                </label>
                            </div>
                        </div>
                        <form onSubmit={handlePayment}>
                            <div className="mb-3">
                                <label className="form-label">Card Number</label>
                                <input
                                    type="text"
                                    name="number"
                                    className={`form-control ${errors.number ? "is-invalid" : ""}`}
                                    placeholder="1234 5678 9012 3456"
                                    maxLength="19"
                                    value={cardDetails.number}
                                    onChange={handleInputChange}
                                />
                                {errors.number && <div className="invalid-feedback">{errors.number}</div>}
                            </div>
                            <div className="mb-3">
                                <label className="form-label">Name on Card</label>
                                <input
                                    type="text"
                                    name="name"
                                    className={`form-control ${errors.name ? "is-invalid" : ""}`}
                                    placeholder="John Doe"
                                    value={cardDetails.name}
                                    onChange={handleInputChange}
                                />
                                {errors.name && <div className="invalid-feedback">{errors.name}</div>}
                            </div>
                            <div className="row mb-3">
                                <div className="col-md-6">
                                    <label className="form-label">Expiry Date</label>
                                    <input
                                        type="text"
                                        name="expiry"
                                        className={`form-control ${errors.expiry ? "is-invalid" : ""}`}
                                        placeholder="MM/YY"
                                        maxLength="5"
                                        value={cardDetails.expiry}
                                        onChange={handleInputChange}
                                    />
                                    {errors.expiry && <div className="invalid-feedback">{errors.expiry}</div>}
                                </div>
                                <div className="col-md-6">
                                    <label className="form-label">CVC</label>
                                    <input
                                        type="text"
                                        name="cvc"
                                        className={`form-control ${errors.cvc ? "is-invalid" : ""}`}
                                        placeholder="123"
                                        maxLength="4"
                                        value={cardDetails.cvc}
                                        onChange={handleInputChange}
                                    />
                                    {errors.cvc && <div className="invalid-feedback">{errors.cvc}</div>}
                                </div>
                            </div>
                            <button type="submit" className="btn btn-primary w-100">
                                Pay Now
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default PaymentModal;
