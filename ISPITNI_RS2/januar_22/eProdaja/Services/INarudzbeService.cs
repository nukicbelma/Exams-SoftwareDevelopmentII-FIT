using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface INarudzbeService
    {
        IList<Model.Narudzbe> GetAll(NarudzbeSearchRequest search);
    }
}
