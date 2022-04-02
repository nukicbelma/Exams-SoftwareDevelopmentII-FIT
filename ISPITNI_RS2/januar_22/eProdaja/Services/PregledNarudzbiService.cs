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
    public class PregledNarudzbiService : IPregledNarudzbiService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;

        public PregledNarudzbiService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }


        public IList<Model.PregledNarudzbi> GetAll(PregledNarudzbiSearchRequest search)
        {
            var query = Context.PregledNarudzbi.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.KupciId.ToString()))
            {
                query = query.Where(x => x.KupciId == search.KupciId);
            }
            var entities = query.ToList();
            var result = _mapper.Map<IList<Model.PregledNarudzbi>>(entities);
            return result;
        }
        public Model.PregledNarudzbi Insert(PregledNarudzbiInsertRequest request)
        {
            var entity = _mapper.Map<Database.PregledNarudzbi>(request);
            Context.Add(entity);
            Context.SaveChanges();
            return _mapper.Map<Model.PregledNarudzbi>(entity);
        }
    }
}
