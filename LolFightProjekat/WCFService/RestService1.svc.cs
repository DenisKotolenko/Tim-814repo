using System;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using LolFightProjekat.Models;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestService1.svc or RestService1.svc.cs at the Solution Explorer and start debugging.


    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestService1 : IRestService1
    {
        public String DoWork()
        {
            return "Radi Rest";
        }

        public Employee GetEmployee()
        {
            return new Employee() {Name = "Selvedin", Salary = 123};
        }

        public string IspisiSkilove(int idChampiona)
        {
            using (var context = new lolfightbazaEntities())
            {
                // selecting skills by champion
                var skills = 
                    from skilovi in context.skilovis
                    where skilovi.championi.idChampiona == idChampiona
                    select skilovi;

                StringBuilder builder = new StringBuilder();
                foreach (skilovi skilovi in skills)
                {
                    // here i'm supplying only the HP, just for show
                    // TODO: override a ToString method and/or do something about this database...
                    builder.Append(skilovi.HP).Append(Environment.NewLine);
                }
                // TODO: also revise this wonder where a single champion can have multiple skills containing HP, attack dmg etc...
                return builder.ToString();
            }
        }

        public void PosaljiPoruku(int idChampiona, string imePrimaoca, string naslov, string tekst)
        {
            using (var context = new lolfightbazaEntities())
            {
                // getting recipient's id by its name, i suppose
                var targetChampionIds = 
                    from championi in context.championis
                    where championi.svichampioni.Ime == imePrimaoca
                    select championi.idChampiona;
                int targetChampionId = targetChampionIds.FirstOrDefault();
                

                // creating a new message
                poruke message = new poruke()
                {
                    idPosiljaoca = idChampiona,
                    idPrimaoca = targetChampionId,
                    NaslovPoruke = naslov,
                    TekstPoruke = tekst,

                    VrijemePoruke = DateTime.Now.ToString(CultureInfo.CurrentCulture) // vrijeme is a string?
                    // NOTE: there are some unfilled properties here
                };

                // adding the newly created message and commiting to the context and the database
                context.porukes.Add(message);
                context.SaveChanges();
            }
        }


        /*
   //Sve vezano za admina NIJE na web servisu

//Metode za inicijanu registraciju
public void KreirajKorisnika(korisnici k);						
public void KreirajChampiona(korisnici k, championi c);

//Metode su razvrstane prema radu sa tabelama iz baze


//Metode za skilove
public void postaviPocetneSkilove(championi c, svichampioni sc);
public skilovi IspisiSkilove(int idChampiona); 						//Selva
public void PovecajSkilHP(int  idChampiona);
public void PovecajSkilAttackDmg(int  idChampiona);
public void PovecajSkilAbilityPowerDmg(int  idChampiona);
public void PovecajSkilAttackSpeed(int  idChampiona);
public void PovecajSkilArmor(int  idChampiona);
public void PovecajSkilMagicResist(int  idChampiona);


//Metode za sveIteme
public List<sviItemi> dajSveIteme(); //potrebno za shop

//Metode za iteme (tabela se zove Inventory)
public void kupiItem(int idItema, int idChampiona);
public void aktivirajItem(int idItema, int idChampiona); //potrebno za aktivaciju u profilu
public void prodajItem(int idItema, int idChampiona);

//Metode za poruke
public List<poruke> dajPrimljenePoruke(int idChampiona);
public List<poruke> dajPoslanePoruke(int idChampiona);   
public void posaljiPoruku(int idChampiona, String imePrimaoca, String naslov, String tekst);  //Selva
public void posaljiPoruku(int idChampiona, id idPrimaoca, String naslov, String tekst);
public void posaljiPorukuAdminu(int idChampiona, String naslov, String tekst);

//Metode za admina (nece biti u servisu)

//Metode za sveChampioni
public List<sviChampioni> dajSveChampione(String nacija); //Potrebno za registraciju (odabir championa)
public champion odabraniChampion(int idSviChamioni);


//Metode za rankStatistika
public List<championi> dajStatistiku(String kriterij);

//Metode za korisnici
public void promjeniPass(int idKorisnika, String staraSifra, String novaSifra, String ponovljenaNovaSifra);

//Metode za izvjestajBorbi
public int traziProtivnika(int idChampiona); //vraca idProtivnika
public izvjestajBorbi borba(int idChampiona, int idProtivnika);
public list<izvjestajBorbi> dajSveBorbe(int idChampiona);
public int dajSavOpljackaniGold(int idChampiona);


//Metode za LogAktivnosti i LogJunglanja
public logJunglanja idiUjunglu(int idChampiona, int trajanjeJunglanja);
public list<logjunglanja> dajListuJunglanja(int idChampiona);

//Metode za LogAktivnosti i LogFarmanja
public logFarmanja idiFarmaj(int idChampiona);
public list<logFarmanja> dajListuFarmanja(int idChampiona);
public int dajSvoNafarnanoZLato(int idChampiona);
         */
    }
}
