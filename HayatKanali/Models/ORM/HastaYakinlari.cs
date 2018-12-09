namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HastaYakinlari")]
    public partial class HastaYakinlari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HastaYakinlari()
        {
            Hastalar = new HashSet<Hastalar>();
        }

        public int Id { get; set; }

        [StringLength(11)]
        public string TcKimlik { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [StringLength(10)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        [StringLength(10)]
        public string Cinsiyet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hastalar> Hastalar { get; set; }
    }
}
