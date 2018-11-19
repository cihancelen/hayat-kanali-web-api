namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klinikler")]
    public partial class Klinikler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klinikler()
        {
            HastaneKlinik = new HashSet<HastaneKlinik>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string KlinikAdi { get; set; }

        public string Aciklama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HastaneKlinik> HastaneKlinik { get; set; }
    }
}
