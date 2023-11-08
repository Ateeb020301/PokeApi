using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using PokeApiNet.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace diagnoser.Controllers
{
    [Route("[controller]/[action]")]
    public class BrukerController : ControllerBase
    {
        private readonly BrukerContext _db;

        public BrukerController(BrukerContext db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Bruker innBruker)
        {
            try
            {

                var PokemonkortRad = new Pokemonkort();
                PokemonkortRad.pokemonkort = innBruker.Pokemonkort;


                var nyBrukerRad = new Brukere();
                nyBrukerRad.fornavn = innBruker.fornavn;
                nyBrukerRad.etternavn = innBruker.etternavn;
                nyBrukerRad.alder = innBruker.alder;
                nyBrukerRad.email = innBruker.email;
                nyBrukerRad.tlf = innBruker.tlf;
                nyBrukerRad.kjonn = innBruker.kjonn;
                PokemonkortRad.Brukere = nyBrukerRad;


                _db.Pokemonkort.Add(PokemonkortRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
         
         
        public async Task<List<Bruker>> HentAlle()
        {
            try
            {
                List<Bruker> alleBrukere = await _db.Brukere.Select(k => new Bruker
                {
                    id = k.id,
                    fornavn = k.fornavn,
                    etternavn = k.etternavn,
                    alder = k.alder,
                    kjonn = k.alder,
                    email = k.alder,
                    tlf = k.tlf
                }).ToListAsync();
                return alleBrukere;
            }
            catch
            {
                return null;
            }
        }*/

        public async Task<List<Pokemonkort>> HentAlleDiagnoser()
        {
            try
            {
                List<Pokemonkort> allePokemonkort = await _db.Pokemonkort.ToListAsync();
                return allePokemonkort;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Slett(int id)
        {
            try
            {
                Pokemonkort enDBBruker = await _db.Pokemonkort.FindAsync(id);
                _db.Pokemonkort.Remove(enDBBruker);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Brukere> HentEn(int id)
        {
            Brukere enBruker = await _db.Brukere.FindAsync(id);
            return enBruker;
        }

        /* public async Task<bool> Endre(Brukere endreBruker)
         {
             try
             {
                 Brukere enBruker = await _db.Brukere.FindAsync(endreBruker.id);
                 enBruker.fornavn = endreBruker.fornavn;
                 enBruker.etternavn = endreBruker.etternavn;
                 enBruker.alder = endreBruker.alder;
                 enBruker.email = endreBruker.email;
                 enBruker.tlf = endreBruker.tlf;
                 enBruker.kjonn = endreBruker.kjonn;
                 await _db.SaveChangesAsync();
             }
             catch
             {
                 return false;
             }
             return true;
         }
        */
        public async Task<bool> Endre(Pokemonkort endrePokemonkort)
        {
            try
            {
                Pokemonkort enPokemonkort = await _db.Pokemonkort.FindAsync(endrePokemonkort.pid);

                enPokemonkort.Brukere.fornavn = endrePokemonkort.Brukere.fornavn;
                enPokemonkort.Brukere.etternavn = endrePokemonkort.Brukere.etternavn;
                enPokemonkort.Brukere.alder = endrePokemonkort.Brukere.alder;
                enPokemonkort.Brukere.email = endrePokemonkort.Brukere.email;
                enPokemonkort.Brukere.tlf = endrePokemonkort.Brukere.tlf;
                enPokemonkort.Brukere.kjonn = endrePokemonkort.Brukere.kjonn;
                //Her er metoden for å endre både diagnoser og symptomer fra samme form, ja
                enPokemonkort.pokemonkort = endrePokemonkort.pokemonkort;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

