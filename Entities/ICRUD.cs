using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ICRUD<T>
    {
        Response Insert(T item);
        Response Update(T item);
        DataResponse<T> GetAllView();
        DataResponse<T> GetByValue(string value);
        Response Delete(int ID);
    }
}
