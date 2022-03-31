using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AssetManagementAPI.Entity.Entities
{
    public partial class AssetManagementContext : DbContext
    {
        //public AssetManagementContext()
        //{
        //}

        public AssetManagementContext(DbContextOptions<AssetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionStatus> ActionStatuses { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<AssetBarcode> AssetBarcodes { get; set; }
        public virtual DbSet<AssetCustomer> AssetCustomers { get; set; }
        public virtual DbSet<AssetOwner> AssetOwners { get; set; }
        public virtual DbSet<AssetStatus> AssetStatuses { get; set; }
        public virtual DbSet<AssetWithoutBarcode> AssetWithoutBarcodes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<CommType> CommTypes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Communication> Communications { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<OwnerType> OwnerTypes { get; set; }
        public virtual DbSet<Personnel> Personnel { get; set; }
        public virtual DbSet<PersonnelTeam> PersonnelTeams { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePersonnel> RolePersonnel { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=DESKTOP-LN7BH6H\\SQLExpress;Database=AssetManagement;Trusted_Connection=True;");
            //}


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("Action");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<ActionStatus>(entity =>
            {
                entity.ToTable("ActionStatus");

                entity.Property(e => e.ActionStatusId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionStatuses)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_ActionStatus_Action");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ActionStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_ActionStatus_Status");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.Description).UseCollation("Turkish_CI_AS");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.RetireDate).HasColumnType("date");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Asset_Brand");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Asset_Company");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_Asset_Currency");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Asset_Group");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Asset_Model");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Asset_Type");
            });

            modelBuilder.Entity<AssetBarcode>(entity =>
            {
                entity.ToTable("AssetBarcode");

                entity.Property(e => e.Barcode).UseCollation("Turkish_CI_AS");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetBarcodes)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetBarcode_Asset");
            });

            modelBuilder.Entity<AssetCustomer>(entity =>
            {
                entity.ToTable("AssetCustomer");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetCustomers)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetCustomer_Asset");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AssetCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_AssetCustomer_Customer");
            });

            modelBuilder.Entity<AssetOwner>(entity =>
            {
                entity.ToTable("AssetOwner");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetOwners)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetOwner_Asset");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.AssetOwners)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_AssetOwner_Owner");

                entity.HasOne(d => d.OwnerType)
                    .WithMany(p => p.AssetOwners)
                    .HasForeignKey(d => d.OwnerTypeId)
                    .HasConstraintName("FK_AssetOwner_OwnerType");
            });

            modelBuilder.Entity<AssetStatus>(entity =>
            {
                entity.ToTable("AssetStatus");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Note).UseCollation("Turkish_CI_AS");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetStatuses)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetStatus_Asset");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.AssetStatuses)
                    .HasForeignKey(d => d.PersonnelId)
                    .HasConstraintName("FK_AssetStatus_Personnel");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AssetStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_AssetStatus_Status");
            });

            modelBuilder.Entity<AssetWithoutBarcode>(entity =>
            {
                entity.ToTable("AssetWithoutBarcode");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetWithoutBarcodes)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetWithoutBarcode_Asset");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.AssetWithoutBarcodes)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_AssetWithoutBarcode_Unit");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("Claim");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<CommType>(entity =>
            {
                entity.ToTable("CommType");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Note).UseCollation("Turkish_CI_AS");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_Comment_Asset");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PersonnelId)
                    .HasConstraintName("FK_Comment_Personnel");
            });

            modelBuilder.Entity<Communication>(entity =>
            {
                entity.ToTable("Communication");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CommType)
                    .WithMany(p => p.Communications)
                    .HasForeignKey(d => d.CommTypeId)
                    .HasConstraintName("FK_Communication_CommType");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.Communications)
                    .HasForeignKey(d => d.PersonnelId)
                    .HasConstraintName("FK_Communication_Personnel");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PageCode)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsFixedLength(true)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.Owners)
                    .HasForeignKey(d => d.PersonnelId)
                    .HasConstraintName("FK_Owner_Personnel");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Owners)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Owner_Team");
            });

            modelBuilder.Entity<OwnerType>(entity =>
            {
                entity.ToTable("OwnerType");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description).UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Personnel)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Personnel_Company");
            });

            modelBuilder.Entity<PersonnelTeam>(entity =>
            {
                entity.ToTable("PersonnelTeam");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.PersonnelTeams)
                    .HasForeignKey(d => d.PersonnelId)
                    .HasConstraintName("FK_PersonnelTeam_Personnel");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PersonnelTeams)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_PersonnelTeam_Team");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Price1)
                    .HasColumnType("money")
                    .HasColumnName("Price");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_Price_Asset");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_Price_Currency");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<RolePersonnel>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.RolePersonnel)
                    .HasForeignKey(d => d.PersonnelId)
                    .HasConstraintName("FK_RolePersonnel_Personnel");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePersonnel)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RolePersonnel_Role");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .UseCollation("Turkish_CI_AS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
