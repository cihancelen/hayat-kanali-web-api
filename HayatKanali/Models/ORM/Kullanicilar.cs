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
            KullaniciHastalik = new HashSet<KullaniciHastalik>();
            KullaniciTalep = new HashSet<KullaniciTalep>();
        }

        public int Id { get; set; }

        [StringLength(11)]
        public string TcKimlik { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        [Column(TypeName = "date")]
        public DateTime DogumTarihi { get; set; }

        [StringLength(50)]
        public string Parola { get; set; }

        public bool? SigaraAlkolKullanimi { get; set; }

        public DateTime SonKanVermeTarihi { get; set; }

        public int? KanGrubuId { get; set; }

        public int? CityId { get; set; }

        [StringLength(250)]
        public string District { get; set; }

        public virtual KanGruplari KanGruplari { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciHastalik> KullaniciHastalik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciTalep> KullaniciTalep { get; set; }
    }
}
