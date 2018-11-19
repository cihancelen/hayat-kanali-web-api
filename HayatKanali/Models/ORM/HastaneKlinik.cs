namespace HayatKanali.Models.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HastaneKlinik")]
    public partial class HastaneKlinik
    {
        public int Id { get; set; }

        public int? KlinikId { get; set; }

        public int? HastaneId { get; set; }

        public virtual Hastaneler Hastaneler { get; set; }

        public virtual Klinikler Klinikler { get; set; }
    }
}
