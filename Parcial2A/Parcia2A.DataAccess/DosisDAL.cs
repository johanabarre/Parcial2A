using Parcial2A.Entities;
using Parcial2A.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcia2A.DataAccess
{
    public class DosisDAL
    {
        private static DosisDAL _instance;

        public static DosisDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DosisDAL();
                }
                return _instance;

            }


        }

        public List<Dosis> SellectAll()
        {
            List<Dosis> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Doses.ToList();
            }

            return result;


        }

        public Dosis SellectById(int id)
        {
            Dosis result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Doses
                    .FirstOrDefault(x => x.DosisId == id);
            }

            return result;


        }
        public bool Insert(Dosis entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Doses.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Doses.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }
    }
}

