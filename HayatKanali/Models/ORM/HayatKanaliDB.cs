namespace HayatKanali.Models.ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HayatKanaliDB : DbContext
    {
        public HayatKanaliDB()
            : base("name=HayatKanaliDB")
        {
        }

        public virtual DbSet<Doktorlar> Doktorlar { get; set; }
        public virtual DbSet<GenelAdmin> GenelAdmin { get; set; }
        public virtual DbSet<Hastalar> Hastalar { get; set; }
        public virtual DbSet<HastaneKlinik> HastaneKlinik { get; set; }
        public virtual DbSet<Hastaneler> Hastaneler { get; set; }
        public virtual DbSet<HastaYakinlari> HastaYakinlari { get; set; }
        public virtual DbSet<KalitsalHastaliklar> KalitsalHastaliklar { get; set; }
        public virtual DbSet<KanGruplari> KanGruplari { get; set; }
        public virtual DbSet<KanTalepleri> KanTalepleri { get; set; }
        public virtual DbSet<Klinikler> Klinikler { get; set; }
        public virtual DbSet<KullaniciKalitsalHastalik> KullaniciKalitsalHastalik { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Personeller> Personeller { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doktorlar>()
                .Property(e => e.Telefon)
                .IsFixedLength();

            modelBuilder.Entity<Doktorlar>()
                .HasMany(e => e.Hastalar)
                .WithOptional(e => e.Doktorlar)
                .HasForeignKey(e => e.DoktorId);

            modelBuilder.Entity<Hastalar>()
                .Property(e => e.TcKimlik)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hastalar>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hastalar>()
                .HasMany(e => e.KanTalepleri)
                .WithOptional(e => e.Hastalar)
                .HasForeignKey(e => e.HastaId);

            modelBuilder.Entity<Hastaneler>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hastaneler>()
                .HasMany(e => e.Doktorlar)
                .WithOptional(e => e.Hastaneler)
                .HasForeignKey(e => e.HastaneId);

            modelBuilder.Entity<Hastaneler>()
                .HasMany(e => e.Hastalar)
                .WithOptional(e => e.Hastaneler)
                .HasForeignKey(e => e.HastaneId);

            modelBuilder.Entity<Hastaneler>()
                .HasMany(e => e.HastaneKlinik)
                .WithOptional(e => e.Hastaneler)
                .HasForeignKey(e => e.HastaneId);

            modelBuilder.Entity<Hastaneler>()
                .HasMany(e => e.Personeller)
                .WithOptional(e => e.Hastaneler)
                .HasForeignKey(e => e.HastaneId);

            modelBuilder.Entity<HastaYakinlari>()
                .Property(e => e.TcKimlik)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HastaYakinlari>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HastaYakinlari>()
                .HasMany(e => e.Hastalar)
                .WithOptional(e => e.HastaYakinlari)
                .HasForeignKey(e => e.HastaYakiniId);

            modelBuilder.Entity<KalitsalHastaliklar>()
                .HasMany(e => e.KullaniciKalitsalHastalik)
                .WithOptional(e => e.KalitsalHastaliklar)
                .HasForeignKey(e => e.KalitsalHastalikId);

            modelBuilder.Entity<KanGruplari>()
                .Property(e => e.KanGrubu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KanGruplari>()
                .HasMany(e => e.Hastalar)
                .WithOptional(e => e.KanGruplari)
                .HasForeignKey(e => e.KanGrubuId);

            modelBuilder.Entity<KanGruplari>()
                .HasMany(e => e.KanTalepleri)
                .WithOptional(e => e.KanGruplari)
                .HasForeignKey(e => e.KanGrupId);

            modelBuilder.Entity<KanGruplari>()
                .HasMany(e => e.Kullanicilar)
                .WithOptional(e => e.KanGruplari)
                .HasForeignKey(e => e.KanGrubuId);

            modelBuilder.Entity<Klinikler>()
                .HasMany(e => e.HastaneKlinik)
                .WithOptional(e => e.Klinikler)
                .HasForeignKey(e => e.KlinikId);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.TcKimlik)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.Telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.KullaniciKalitsalHastalik)
                .WithOptional(e => e.Kullanicilar)
                .HasForeignKey(e => e.KullaniciId);

            modelBuilder.Entity<Personeller>()
                .HasMany(e => e.KanTalepleri)
                .WithOptional(e => e.Personeller)
                .HasForeignKey(e => e.PersonelId);
        }
    }
}
