using DataAccessLayer;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{


    public class LaboratorioBLL : ICRUD<Laboratorio>
    {
        private LaboratorioDAL laboratorioDAL = new ();
        private Validator validator = new ();

        public Response Insert(Laboratorio item)
        {
            Response response = validator.ValidateLaboratorio(item);
            if (response.HasSuccess)
                return laboratorioDAL.Insert(item);
            return response;
        }

        public Response Update(Laboratorio item)
        {
            Response response = validator.ValidateLaboratorio(item);
            if (response.HasSuccess)
            {
                return laboratorioDAL.Update(item);
            }
            return response;
        }

        public DataResponse<Laboratorio> GetByValue(string value)
        {
            return laboratorioDAL.GetByValue(value.Trim());
        }

        public void ChangeAtivo(int laboratorioID, bool checkAtivo)
        {
            throw new NotImplementedException();
        }

        public DataResponse<Laboratorio> GetAllView()
        {
            return laboratorioDAL.GetAllView();
        }

        public Response Delete(int ID)
        {
            return laboratorioDAL.Delete(ID);
        }
    }

}