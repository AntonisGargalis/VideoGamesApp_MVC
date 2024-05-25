using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.DataAccess.Data;
using VideoGames.DataAccess.Repository.IRepository;
using VideoGames.Models;

namespace VideoGames.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {  
            _db = db; 
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }

    }
}
