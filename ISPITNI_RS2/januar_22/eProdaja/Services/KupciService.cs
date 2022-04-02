using AutoMapper;
using eProdaja.Database;
using eProdaja.Filters;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Korisnici = eProdaja.Model.Korisnici;

namespace eProdaja.Services
{
    public class KupciService : IKupciService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;

        public KupciService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }


        public IList<Model.Kupci> GetAll(KupciSearchRequest search)
        {
            var query = Context.Kupcis.AsQueryable();

            //if (!string.IsNullOrWhiteSpace(search?.Ime))
            //{
            //    query = query.Where(x => x.Ime == search.Ime);
            //}

            var entities = query.ToList();
            var result = _mapper.Map<IList<Model.Kupci>>(entities);
            return result;
        }
    }
}
