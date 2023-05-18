using Parcia2A.DataAccess;
using Parcial2A.Entities;
using Parcial2A.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2A.BusinessLogic
{
    public class PersonaBL
    {

        private static PersonaBL _instance;

        public static PersonaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersonaBL();

                return _instance;
            }
        }

        public List<Persona> SellectAll()
        {
            List<Persona> result;
            try
            {
                result = PeronaDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Persona entity)
        {
            bool result = false;
            try
            {
                result = PeronaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Persona entity)
        {
            bool result = false;
            try
            {
                result = PeronaDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
