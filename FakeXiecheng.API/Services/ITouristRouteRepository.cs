using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeXiecheng.API.Models;

namespace FakeXiecheng.API.Services
{
    public interface ITouristRouteRepository
    {
        Task<TouristRoute> GetTouristRouteAsync(Guid touristRouteId);
        Task<IEnumerable<TouristRoute>> GetTouristRoutesAsync(string keyword, string operatorType, int? ratingValue);
        Task<IEnumerable<TouristRoute>> GetTouristRouteByIdListAsync(IEnumerable<Guid> ids);
        Task<bool> TouristRouteExistsAsync(Guid touristRouteId);
        Task<TouristRoutePicture> GetPictureAsync(int pictureId);
        Task<IEnumerable<TouristRoutePicture>> GetPictureByTouristRouteIdAsync(Guid touristRouteId);
        Task<bool> SaveAsync();
        void AddTouristRoute(TouristRoute touristRoute);
        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutePicture(TouristRoutePicture picture);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);
    }
}
