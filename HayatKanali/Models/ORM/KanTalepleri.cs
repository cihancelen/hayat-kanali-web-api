namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KanTalepleri")]
    public partial class KanTalepleri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KanTalepleri()
        {
            KullaniciTalep = new HashSet<KullaniciTalep>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string TalepAciklama { get; set; }

        public int? HastaId { get; set; }

        public int? KanGrupId { get; set; }

        public int? BeklenenUnite { get; set; }

        public int? TeminEdilenUniteAdet { get; set; }

        public int? UniteAdet { get; set; }

        public DateTime? TalepTarihi { get; set; }

        public int? PersonelId { get; set; }

        public virtual Hastalar Hastalar { get; set; }

        public virtual KanGruplari KanGruplari { get; set; }

        public virtual Personeller Personeller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciTalep> KullaniciTalep { get; set; }
    }
}
