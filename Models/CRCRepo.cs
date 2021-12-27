using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace XtraMileTask2.Models
{
    public class CRCRepo
    {
        private readonly IDbConnection db;
        public CRCRepo()
        {
            db = new SqlConnection(DbConn.ConnStr);
        }

        public List<Country> GetAllCountry()
        {
            db.Open();
            var result = db.Query<Country>("select id, name from Countries order by name").ToList();
            db.Close();

            return result;
        }

        public List<Region> GetAllRegion(int id)
        {
            db.Open();
            var result = db.Query<Region>("select id, name from Regions where CountryId = @id order by name", new { id }).ToList();
            db.Close();

            return result;
        }

        public List<City> GetAllCity(int id)
        {
            db.Open();
            var result = db.Query<City>("select id, name from Cities where RegionId = @id order by name", new { id }).ToList();
            db.Close();

            return result;
        }
    }
}
