// using EventPlanner.Models;
// using EventPlanner.Repositories;

// namespace EventPlanner.Extensions;

// public static class EventExtensions
// {

//     // public static async Task<List<Event>> FilterByDate(this IEventRepository _eventRepository, DateTime startDate, DateTime? endDate)
//     // {
//     //     List<Event> events = await _eventRepository.Get();
        
//     //     if (endDate is not null)
//     //     {
//     //         events = events.Where(x => x.Date >= startDate && x.Date <= endDate).ToList();
//     //     } else 
//     //     {
//     //         events = events.Where(x => x.Date >= startDate).ToList();
//     //     }

//     //     return events;
//     // }

//     public static async Task<List<Event>> FilterByLocationAndDate(this IEventRepository _eventRepository, string location, DateTime startDate, DateTime? endDate)
//     {
//         List<Event> events = await _eventRepository.Get();
//         events = events.Where(x => x.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
        
//         if (endDate is not null)
//         {
//             events = events.Where(x => x.Date >= startDate && x.Date <= endDate).ToList();
//         } else 
//         {
//             events = events.Where(x => x.Date >= startDate).ToList();
//         }

//         return events;
//     }
// }
