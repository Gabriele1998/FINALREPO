using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Models.Tabelle
{
    public class Anagrafica
    {
        [Key]
        public int AnagraficaId {get;set;}
        public string CodiceAnagrafica {get;set;}
        public bool IsAzienda {get;set;}
        public string Nome{get;set;}
        public string Cognome {get;set;}
        public string RagioneSociale {get;set;}
        public string PartitaIva {get;set;}
        public string CodiceFiscale {get;set;}
        public int TipoAnagraficaId{ get;set;}
        public TipoAnagrafica TipoAnagrafica {get;set;}
        public ICollection<Contatti> Contatti { get; set; }
        public ICollection<Indirizzi> Indirizzi { get; set; }
    }
}