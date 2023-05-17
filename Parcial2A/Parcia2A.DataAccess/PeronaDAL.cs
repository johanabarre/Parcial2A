using Parcial2A.Entities;
using Parcial2A.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcia2A.DataAccess
{
    public class PeronaDAL
    {
        private static PeronaDAL _instance;

        public static PeronaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PeronaDAL();
                }
                return _instance;

            }


        }

        public List<Persona> SellectAll()
        {
            List<Persona> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Personas.ToList();
            }

            return result;


        }

        public Persona SellectById(int id)
        {
            Persona result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Personas
                    .FirstOrDefault(x => x.PersonaId == id);
            }

            return result;


        }
        public bool Insert(Persona entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Personas.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Personas.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }
        public bool Update(Persona entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                result = _context.SaveChanges() > 0;
            }
            return result;

        }

    }
}
