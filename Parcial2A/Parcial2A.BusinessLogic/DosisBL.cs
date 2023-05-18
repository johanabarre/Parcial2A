using Parcia2A.DataAccess;
using Parcial2A.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2A.BusinessLogic
{
    public class DosisBL
    {
        private static DosisBL _instance;

        public static DosisBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DosisBL();

                return _instance;
            }
        }

        public List<Dosis> SellectAll()
        {
            List<Dosis> result;
            try
            {
                result = DosisDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Dosis entity)
        {
            bool result = false;
            try
            {
                result = DosisDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        
    }
}
