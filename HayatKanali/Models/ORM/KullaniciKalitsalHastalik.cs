namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullaniciKalitsalHastalik")]
    public partial class KullaniciKalitsalHastalik
    {
        public int Id { get; set; }

        public int? KalitsalHastalikId { get; set; }

        public int? KullaniciId { get; set; }

        public virtual KalitsalHastaliklar KalitsalHastaliklar { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
