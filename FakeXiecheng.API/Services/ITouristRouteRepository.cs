﻿using System;
using System.Collections.Generic;
using FakeXiecheng.API.Models;

namespace FakeXiecheng.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string operatorType, int? ratingValue);
        TouristRoute GetTouristRoute(Guid touristRouteId);
        bool TouristRouteExists(Guid touristRouteId);
        IEnumerable<TouristRoutePicture> GetPictureByTouristRouteId(Guid touristRouteId);
        TouristRoutePicture GetPicture(int pictureId);
        void AddTouristRoute(TouristRoute touristRoute);
        bool Save();
        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
    }
}
