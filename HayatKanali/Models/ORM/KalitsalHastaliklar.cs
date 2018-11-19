namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KalitsalHastaliklar")]
    public partial class KalitsalHastaliklar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KalitsalHastaliklar()
        {
            KullaniciKalitsalHastalik = new HashSet<KullaniciKalitsalHastalik>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string HastalikAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciKalitsalHastalik> KullaniciKalitsalHastalik { get; set; }
    }
}
