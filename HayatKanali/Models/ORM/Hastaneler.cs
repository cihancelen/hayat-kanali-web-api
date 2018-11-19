namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hastaneler")]
    public partial class Hastaneler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hastaneler()
        {
            Doktorlar = new HashSet<Doktorlar>();
            Hastalar = new HashSet<Hastalar>();
            HastaneKlinik = new HashSet<HastaneKlinik>();
            Personeller = new HashSet<Personeller>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Adres { get; set; }

        [StringLength(10)]
        public string Telefon { get; set; }

        [StringLength(250)]
        public string Konum { get; set; }

        [StringLength(50)]
        public string Parola { get; set; }

        [StringLength(150)]
        public string KullaniciAdi { get; set; }

        [StringLength(150)]
        public string Mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doktorlar> Doktorlar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hastalar> Hastalar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HastaneKlinik> HastaneKlinik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personeller> Personeller { get; set; }
    }
}
