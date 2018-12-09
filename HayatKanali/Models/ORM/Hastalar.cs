namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hastalar")]
    public partial class Hastalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hastalar()
        {
            KanTalepleri = new HashSet<KanTalepleri>();
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

        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }

        [StringLength(500)]
        public string Hastalik { get; set; }

        public string Cinsiyet { get; set; }

        public int? HastaYakiniId { get; set; }

        public int? KanGrubuId { get; set; }

        public int? DoktorId { get; set; }

        public int? HastaneId { get; set; }

        public virtual Doktorlar Doktorlar { get; set; }

        public virtual Hastaneler Hastaneler { get; set; }

        public virtual HastaYakinlari HastaYakinlari { get; set; }

        public virtual KanGruplari KanGruplari { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KanTalepleri> KanTalepleri { get; set; }
    }
}
