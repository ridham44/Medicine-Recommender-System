<img width="1897" height="838" alt="Screenshot 2025-10-30 110039" src="https://github.com/user-attachments/assets/68d21992-8a70-43be-9142-99b536a3e4ae" />

````markdown
# 💊 Medicine Recommender System

An AI-powered **Medicine Recommender Web Application** that suggests suitable medicines based on user symptoms, age, and gender.  
The project uses **.NET** for the backend, **HTML/CSS/JS** for the frontend, and a **machine learning model** integrated with the API for predictions.

---

## 🚀 Features

- 🧠 **AI/ML Based Recommendations** — Suggests the most suitable medicine for entered symptoms.  
- 🩺 **Symptom Input Form** — Users can enter multiple symptoms to get predictions.  
- 🎨 **Modern UI** — Clean, centered, glassmorphism-inspired interface.  
- 🔗 **.NET API Integration** — Backend handles ML prediction and user requests.  
- 📊 **Prediction Confidence** — Displays model confidence score with each recommendation.  

---

## 🏗️ Tech Stack

### 🖥️ Frontend
- HTML5  
- CSS3 (Glassmorphism design)  
- JavaScript  

### ⚙️ Backend
- ASP.NET Core Web API  
- C#  
- Integrated ML Model (.pkl / ONNX)  
- Entity Framework (if database used)

### 🧠 Machine Learning
- Python (for model training)  
- Scikit-learn / TensorFlow (used offline for model training)
- Exported to ONNX or integrated through API

---

## ⚙️ Installation and Setup

### 1️⃣ Clone Repository
```bash
git clone https://github.com/ridham44/Medicine-Recommender-System.git
cd Medicine-Recommender-System
````

### 2️⃣ Open Project in Visual Studio / VS Code

* Open the `.sln` file if present.
* Restore NuGet packages.
* Build and run the project (F5).

### 3️⃣ Frontend Setup

* Place all HTML, CSS, and JS files inside the **wwwroot** (or `/frontend`) folder.
* Launch the application — it will serve the UI from the same server.

---

## 🧩 API Example

**Endpoint:**
`POST /api/medicine/recommend`

🧬 Sample Test Cases
Symptoms	Age	Gender	Medical History	Expected Recommendation
fever, cough	25	Male	none	Paracetamol
headache, nausea	30	Female	migraine	Ibuprofen
cold, sore throat	40	Male	none	Cetirizine
body pain, fatigue	22	Female	anemia	Dolo 650
stomach ache, acidity	28	Male	gastritis	Pantoprazole

MedicineRecommendation/
│
├── Backend/
│ └── MedicineRecommender.API/
│ ├── Controllers/
│ ├── MLModels/
│ ├── Models/
│ ├── appsettings.json
│ ├── Program.cs
│ └── MedicineRecommender.API.csproj
│
├── medicine-recommender-frontend/
│ ├── public/
│ ├── services/
│ ├── src/
│ ├── index.html
│ ├── package.json
│ ├── tailwind.config.js
│ ├── vite.config.js
│ └── README.md
│
└── .Net.sln
---

💻 Step 3: Run the Frontend (React App)

    Open a new terminal and navigate to the frontend:
    
        cd medicine-recommender-frontend
        
        
        Install dependencies:
        
        npm install
        
        
        Start the development server:
        
        npm run dev
        
        
      The frontend will run at:
    
    http://localhost:5173
    
    
    Ensure your backend (http://localhost:5116) is running before testing the form.
    
          cd MedicineRecommender.API
          
          dotnet run


## 🖥️ UI Overview

* Centered responsive layout
* Minimalistic form design
* Transparent glass-style containers
* Footer with proper spacing and clean typography


# 📚 Future Enhancements

* Add user authentication (patient/doctor mode)
* Include medicine side effects and dosage details
* Store search and prediction history
* Visual analytics dashboard

---

## 👨‍💻 Author

**Ridham Patel**
Backend Developer | AI & Web Enthusiast
