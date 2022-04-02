using AutoMapper;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Mapping
{
    public class eProdajaProfile : Profile
    {
        public eProdajaProfile()
        {
            CreateMap<Database.Korisnici, Model.Korisnici>();
            CreateMap<Database.JediniceMjere, Model.JediniceMjere>();
            CreateMap<Database.VrsteProizvodum, Model.VrsteProizvodum>();
            CreateMap<Database.Proizvodi, Model.Proizvodi>();
            CreateMap<Database.Uloge, Model.Uloge>();
            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>();
            CreateMap<ProizvodiInsertRequest, Database.Proizvodi>();
            CreateMap<ProizvodiUpdateRequest, Database.Proizvodi>();
            CreateMap<KorisniciInsertRequest, Database.Korisnici>();
            CreateMap<KorisniciUpdateRequest, Database.Korisnici>();
            //
            CreateMap<Database.PregledNarudzbi, Model.PregledNarudzbi>();
            CreateMap<Database.Kupci, Model.Kupci>();
            CreateMap<Database.Narudzbe, Model.Narudzbe>();
            CreateMap<PregledNarudzbiSearchRequest, Database.PregledNarudzbi>();
            CreateMap<PregledNarudzbiInsertRequest, Database.PregledNarudzbi>();
            CreateMap<KupciSearchRequest, Database.Kupci>();
            CreateMap<NarudzbeSearchRequest, Database.Narudzbe>();
        }
    }
}
