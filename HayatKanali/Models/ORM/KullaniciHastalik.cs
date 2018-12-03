namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullaniciHastalik")]
    public partial class KullaniciHastalik
    {
        public int Id { get; set; }

        public int? KullaniciId { get; set; }

        public int? HastalikId { get; set; }

        public virtual KalitsalHastaliklar KalitsalHastaliklar { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
