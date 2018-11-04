using System.ComponentModel.DataAnnotations;

namespace Models.Tabelle
{
    public class Contatti
    {
        [Key]
        public int ContattiId {get;set;}
        public string Valore{get;set;}
        public string Note {get;set;}
        public int AnagraficaId {get;set;}
        public Anagrafica Anagrafica {get;set;}
        public int TipoContattoId {get;set;}
        public TipoContatto TipoContatto {get;set;}
    }
}