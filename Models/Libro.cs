using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoITT.Models
{
    public class Libro
    {
        [Key]
        public int libro_id { get; set; }
        public string nombre { get; set; }
        public string autor { get; set; }
        public string edicion { get; set; }
        public string editorial { get; set; }
        public string isbn { get; set; }
        public string paginas { get; set; }
        public string clasificacion { get; set; }
        public string anio_publicacion { get; set; }
        public string registro_en_siabuk { get; set; }
        public string reserva { get; set; }
    }
}
