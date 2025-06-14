# EventEase

EventEase is a modern web application for managing and attending corporate and social events. 
This Project is for **coursera** to do the final project.
Built with **Blazor (.NET 8)**, it enables users to browse upcoming events, view event details, register with validation, and track attendance—all with a responsive, interactive UI.

---

## How Copilot Assisted in the Development Process

GitHub Copilot was extensively used throughout the development of EventEase to accelerate and improve the coding process:

* **Component Scaffolding**: Generated the initial structure for Blazor components, including parameterized event cards and forms.
* **Data Validation**: Suggested `DataAnnotations` for form fields, ensuring robust client-side and server-side validation.
* **Routing and Navigation**: Provided best-practice routing patterns and navigation logic for seamless page transitions.
* **State Management**: Helped design the `StateContainer` service for user session tracking and reactive UI updates.
* **Attendance Tracking**: Generated thread-safe attendance tracking logic using concurrent collections.
* **Debugging and Optimization**: Identified and resolved issues with data binding, event handling, and performance (e.g., correct use of `Virtualize` for large lists).
* **Error Handling**: Suggested defensive programming patterns and user-friendly error messages for invalid routes or data.
* **UI/UX Enhancements**: Provided suggestions for responsive layouts, navigation updates, and user feedback mechanisms.

By leveraging Copilot, development was faster, code quality was improved, and best practices were consistently applied across the project.

---

## Features

* **Event Browse**: View a list of upcoming events with details such as name, date, and location.
* **Event Details**: See attendee counts and registration status for each event.
* **Registration Form**: Register for events with a form that validates name, email, and attendee count.
* **Attendance Tracker**: Monitor and display event participation in real time.
* **User Session Management**: Track user sessions and display personalized registration history.
* **Responsive Navigation**: Seamless navigation between event list, details, registration, and user profile.

---

## Getting Started

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/yangzhang1908/EventEase
    ```
    Open the solution in Visual Studio 2022.
2.  **Run the application**: Press `F5` or `Ctrl+F5`. The app will be available at `https://localhost:xxxx`.
3.  **Explore**: Browse events, register, and view your profile using the navigation menu.

---

## Project Structure

* **`Components/Pages/`**: Main Blazor pages (e.g., `EventList`, `EventDetails`, `EventRegistration`, `UserProfile`, `Login`)
* **`Components/Layout/`**: Shared layout and navigation components
* **`Models/`**: Data models (e.g., `Event`)
* **`Services/`**: State management and attendance tracking services