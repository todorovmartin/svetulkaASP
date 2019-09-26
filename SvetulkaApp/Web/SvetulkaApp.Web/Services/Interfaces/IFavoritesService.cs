using SvetulkaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Services.Interfaces
{
    public interface IFavoritesService
    {
        bool Add(int id, string username);

        IEnumerable<FavoriteProduct> All(string username);

        void Delete(int id, string username);
    }
}
