using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.Repository
{
    public class NotificationRepository
    {
        private readonly AppDbContext _Notificationcontext;

        public NotificationRepository(AppDbContext Notificationcontext)
        {
            _Notificationcontext = Notificationcontext;
        }
        //public async Task<List<Notification>> GetNotificationsByUserId(Guid userId)
        //{
        //    return await _Notificationcontext.Notifications
        //                         .Where(n => n.ReceiverId == userId)
        //                         .OrderByDescending(n => n.Date)
        //                         .ToListAsync();
        //}

        //public async Task<Notification?> GetNotificationById(Guid notificationId)
        //{
        //    return await _Notificationcontext.Notifications
        //                         .FirstOrDefaultAsync(n => n.Id == notificationId);
        //}

        //public async Task<bool> AddNotification(Notification notification)
        //{
        //    await _Notificationcontext.Notifications.AddAsync(notification);
        //    return await _Notificationcontext.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> UpdateNotification(Notification notification)
        //{
        //    _Notificationcontext.Notifications.Update(notification);
        //    return await _Notificationcontext.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> DeleteNotification(Guid notificationId)
        //{
        //    var notification = await _Notificationcontext.Notifications.FindAsync(notificationId);
        //    if (notification != null)
        //    {
        //        _Notificationcontext.Notifications.Remove(notification);
        //        return await _Notificationcontext.SaveChangesAsync() > 0;
        //    }
        //    return false;
        //}
    }
}
