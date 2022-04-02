using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IPregledNarudzbiService
    {
        IList<Model.PregledNarudzbi> GetAll(PregledNarudzbiSearchRequest search);
        Model.PregledNarudzbi Insert(PregledNarudzbiInsertRequest request);
    }
}
