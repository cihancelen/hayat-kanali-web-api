namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullaniciTalep")]
    public partial class KullaniciTalep
    {
        public int Id { get; set; }

        public int? TalepId { get; set; }

        public int KullaniciId { get; set; }

        public virtual KanTalepleri KanTalepleri { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}