import { useState } from "react";
import axios from "axios";
import "./App.css";

export default function App() {
  const [formData, setFormData] = useState({
    symptoms: "",
    age: "",
    gender: "Male",
    medicalHistory: "",
  });
  const [result, setResult] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const response = await axios.post("http://localhost:5116/api/medicine/recommend", formData);
      setResult(response.data);
    } catch (err) {
      console.error("Error fetching recommendation:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="app-container">
      {/* Navbar */}
      <nav className="navbar glass">
        <div className="navbar-left">
          <img src="https://cdn-icons-png.flaticon.com/512/2966/2966488.png" alt="logo" className="logo-img" />
          <span className="logo-text">Medicine Recommender System </span>
        </div>
        <div>
         
        </div>
        <div className="navbar-right">
          <a href="#">Home</a>
          <a href="#">About</a>
          <a href="#">Contact</a>
        </div>
      </nav>

      {/* Center Form */}
      <main className="form-container glass">
        <h1>💊 Enter Your Personal Details</h1>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            name="symptoms"
            placeholder="Enter symptoms (e.g. fever, cough)"
            value={formData.symptoms}
            onChange={handleChange}
          />
          <input
            type="number"
            name="age"
            placeholder="Age"
            value={formData.age}
            onChange={handleChange}
          />
          <select name="gender" value={formData.gender} onChange={handleChange}>
            <option>Male</option>
            <option>Female</option>
          </select>
          <input
            type="text"
            name="medicalHistory"
            placeholder="Medical history (if any)"
            value={formData.medicalHistory}
            onChange={handleChange}
          />
          <button type="submit">{loading ? "Processing..." : "Get Recommendation"}</button>
        </form>

        {result && (
          <div className="result glass">
            <h2>Recommended Medicine: {result.recommendedMedicine}</h2>
            <p>Confidence: {(result.confidence * 100).toFixed(2)}%</p>
          </div>
        )}
      </main>

      {/* Footer */}
      <footer className="footer glass">
        <div className="footer-content">
          <p className="footer-desc">
            Created by <h2><a href="Ridham Patel">Ridham Patel</a></h2> This project is for educational purposes only and not intended for real medical advice.
          </p>
          <hr className="footer-separator" />
          <p className="footer-copy">© 2025 Medicine Recommender | All Rights Reserved</p>
        </div>
      </footer>
    </div>
  );
}
