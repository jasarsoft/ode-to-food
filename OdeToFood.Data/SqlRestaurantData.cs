using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace OdeToFood.Data
{
    public class SqlRestaurantData: IRestaurantData
    {
        private readonly OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in _context.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;

            return query;
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = _context.Restaurants.Attach(updateRestaurant);
            entity.State = EntityState.Modified;
            return updateRestaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
