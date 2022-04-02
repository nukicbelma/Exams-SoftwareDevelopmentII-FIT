using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IKupciService
    {
        IList<Model.Kupci> GetAll(KupciSearchRequest search);
    }
}
