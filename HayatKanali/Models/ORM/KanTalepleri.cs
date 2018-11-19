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
        public int Id { get; set; }

        [StringLength(500)]
        public string TalepAciklama { get; set; }

        public int? HastaId { get; set; }

        public int? KanGrupId { get; set; }

        public int? UniteAdet { get; set; }

        public DateTime? TalepTarihi { get; set; }

        public int? PersonelId { get; set; }

        public virtual Hastalar Hastalar { get; set; }

        public virtual KanGruplari KanGruplari { get; set; }

        public virtual Personeller Personeller { get; set; }
    }
}
