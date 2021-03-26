using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using GPSTracker.Models;

namespace GPSTracker.Data
{
    public class RouteDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public RouteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Route>().Wait();
        }

        public Task<List<Route>> GetRoutesAsync()
        {
            //Get all notes.
            return database.Table<Route>().ToListAsync();
        }

        public Task<Route> GetRouteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Route>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRouteAsync(Route route)
        {
            if (route.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(route);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(route);
            }
        }

        public Task<int> DeleteRouteAsync(Route route)
        {
            // Delete a note.
            return database.DeleteAsync(route);
        }
    }
}