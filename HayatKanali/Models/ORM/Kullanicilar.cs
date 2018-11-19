namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanicilar()
        {
            KullaniciKalitsalHastalik = new HashSet<KullaniciKalitsalHastalik>();
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

        [StringLength(500)]
        public string Adres { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }

        [StringLength(30)]
        public string Parola { get; set; }

        public bool? SigaraAlkolKullanimi { get; set; }

        public DateTime SonKanVermeTarihi { get; set; }

        public int? KanGrubuId { get; set; }

        public virtual KanGruplari KanGruplari { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciKalitsalHastalik> KullaniciKalitsalHastalik { get; set; }
    }
}
