namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personeller")]
    public partial class Personeller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personeller()
        {
            KanTalepleri = new HashSet<KanTalepleri>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Ad { get; set; }

        [StringLength(250)]
        public string Soyad { get; set; }

        public int? HastaneId { get; set; }

        [StringLength(100)]
        public string KullaniciAdi { get; set; }

        [StringLength(50)]
        public string Parola { get; set; }

        [StringLength(150)]
        public string Mail { get; set; }

        public virtual Hastaneler Hastaneler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KanTalepleri> KanTalepleri { get; set; }
    }
}
