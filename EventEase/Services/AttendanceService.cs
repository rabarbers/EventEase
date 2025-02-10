namespace EventEase.Services;

public class AttendanceService
{
    private readonly SessionStorageService _sessionStorageService;
    private const string AttendanceKey = "eventAttendance";

    public AttendanceService(SessionStorageService sessionStorageService)
    {
        _sessionStorageService = sessionStorageService;
    }

    public async Task RegisterAttendance(int eventId, string attendeeName)
    {
        var attendance = await GetAttendance(eventId) ?? [];
        attendance.Add(attendeeName);
        await SaveAttendance(eventId, attendance);
    }

    public async Task<List<string>> GetAttendance(int eventId)
    {
        var attendanceData = await _sessionStorageService.GetItemAsync<Dictionary<int, List<string>>>(AttendanceKey);
        return attendanceData != null && attendanceData.TryGetValue(eventId, out var value) ? value : [];
    }

    private async Task SaveAttendance(int eventId, List<string> attendance)
    {
        var attendanceData = await _sessionStorageService.GetItemAsync<Dictionary<int, List<string>>>(AttendanceKey) ??
                             new Dictionary<int, List<string>>();
        attendanceData[eventId] = attendance;
        await _sessionStorageService.SaveItemAsync(AttendanceKey, attendanceData);
    }
}