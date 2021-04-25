﻿using System;
using System.Collections.Generic;
using FakeXiecheng.API.Models;

namespace FakeXiecheng.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword);
        TouristRoute GetTouristRoutes(Guid touristRouteId);
        bool TouristRouteExists(Guid touristRouteId);
        IEnumerable<TouristRoutePicture> GetPictureByTouristRouteId(Guid touristRouteId);
        TouristRoutePicture GetPicture(int pictureId);
    }
}
