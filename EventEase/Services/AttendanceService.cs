using System.Collections.Concurrent;

namespace EventEase.Services;

public static class AttendanceService
{
    // Track event attendance: Event Name -> List of attendee emails
    private static ConcurrentDictionary<string, HashSet<string>> _eventAttendance = new();

    // Add an attendee to an event
    public static void AddAttendee(string eventName, string attendeeEmail)
    {
        if (string.IsNullOrWhiteSpace(eventName) || string.IsNullOrWhiteSpace(attendeeEmail))
            return;

        _eventAttendance.AddOrUpdate(
            eventName,
            // If the event doesn't exist, create a new HashSet with this attendee
            _ => new HashSet<string> { attendeeEmail },
            // If the event exists, add this attendee to the existing HashSet
            (_, attendees) => {
                attendees.Add(attendeeEmail);
                return attendees;
            }
        );
    }

    // Get all attendees for an event
    public static IEnumerable<string> GetEventAttendees(string eventName)
    {
        if (_eventAttendance.TryGetValue(eventName, out var attendees))
            return attendees;
        return Enumerable.Empty<string>();
    }

    // Get attendance count for an event
    public static int GetAttendanceCount(string eventName)
    {
        if (_eventAttendance.TryGetValue(eventName, out var attendees))
            return attendees.Count;
        return 0;
    }

    // Get all events a user is registered for
    public static IEnumerable<string> GetUserEvents(string email)
    {
        return _eventAttendance
            .Where(kvp => kvp.Value.Contains(email))
            .Select(kvp => kvp.Key);
    }
}
