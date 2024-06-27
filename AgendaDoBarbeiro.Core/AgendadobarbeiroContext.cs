using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgendaDoBarbeiro.Core;

public partial class AgendaDoBarbeiroContext : DbContext
{
    public AgendaDoBarbeiroContext()
    {
    }

    public AgendaDoBarbeiroContext(DbContextOptions<AgendaDoBarbeiroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BarberService> BarberServices { get; set; }

    public virtual DbSet<Enterprise> Enterprises { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Professional> Professionals { get; set; }

    public virtual DbSet<ProfessionalService> ProfessionalServices { get; set; }

    public virtual DbSet<ProfessionalWorkDay> ProfessionalWorkDays { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleStatus> SaleStatuses { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<ScheduleStatus> ScheduleStatuses { get; set; }

    public virtual DbSet<ScheduledService> ScheduledServices { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkDay> WorkDays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=AgendaDoBarbeiro;Username=postgres;Password=?v4quej4d4?");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => new { e.AddressId, e.UserId }).HasName("pk_address_user");

            entity.ToTable("addresses");

            entity.Property(e => e.AddressId)
                .ValueGeneratedOnAdd()
                .HasColumnName("address_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postal_code");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .HasColumnName("street");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("addresses_user_id_fkey");
        });

        modelBuilder.Entity<BarberService>(entity =>
        {
            entity.HasKey(e => e.BarberServiceId).HasName("barber_services_pkey");

            entity.ToTable("barber_services");

            entity.Property(e => e.BarberServiceId).HasColumnName("barber_service_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EnterpriseId).HasColumnName("enterprise_id");
            entity.Property(e => e.EstimatedTime).HasColumnName("estimated_time");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.Enterprise).WithMany(p => p.BarberServices)
                .HasForeignKey(d => d.EnterpriseId)
                .HasConstraintName("barber_services_enterprise_id_fkey");
        });

        modelBuilder.Entity<Enterprise>(entity =>
        {
            entity.HasKey(e => e.EnterpriseId).HasName("enterprises_pkey");

            entity.ToTable("enterprises");

            entity.Property(e => e.EnterpriseId).HasColumnName("enterprise_id");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(20)
                .HasColumnName("cnpj");
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .HasColumnName("cpf");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.SocialName)
                .HasMaxLength(100)
                .HasColumnName("social_name");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("inventory_pkey");

            entity.ToTable("inventory");

            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.QuantityOnHand).HasColumnName("quantity_on_hand");
            entity.Property(e => e.ReorderLevel).HasColumnName("reorder_level");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_inventory_product");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("item_pkey");

            entity.ToTable("item");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Discount)
                .HasPrecision(10, 2)
                .HasColumnName("discount");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Product).WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_item_product");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sent_at");

            entity.HasOne(d => d.Recipient).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("notifications_recipient_id_fkey");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("payment_methods_pkey");

            entity.ToTable("payment_methods");

            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");

            entity.HasOne(d => d.Sale).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("fk_payment_method_sales");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Ean)
                .HasMaxLength(255)
                .HasColumnName("ean");
            entity.Property(e => e.ExternalId)
                .HasMaxLength(255)
                .HasColumnName("external_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Professional>(entity =>
        {
            entity.HasKey(e => e.ProfessionalId).HasName("professionals_pkey");

            entity.ToTable("professionals");

            entity.Property(e => e.ProfessionalId)
                .ValueGeneratedNever()
                .HasColumnName("professional_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EnterpriseId).HasColumnName("enterprise_id");
            entity.Property(e => e.FirstMessage).HasColumnName("first_message");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(50)
                .HasColumnName("whatsapp");

            entity.HasOne(d => d.Enterprise).WithMany(p => p.Professionals)
                .HasForeignKey(d => d.EnterpriseId)
                .HasConstraintName("professionals_enterprise_id_fkey");

            entity.HasOne(d => d.ProfessionalNavigation).WithOne(p => p.Professional)
                .HasForeignKey<Professional>(d => d.ProfessionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("professionals_professional_id_fkey");
        });

        modelBuilder.Entity<ProfessionalService>(entity =>
        {
            entity.HasKey(e => e.ProfessionalServiceId).HasName("professional_services_pkey");

            entity.ToTable("professional_services");

            entity.Property(e => e.ProfessionalServiceId).HasColumnName("professional_service_id");
            entity.Property(e => e.BarberServiceId).HasColumnName("barber_service_id");
            entity.Property(e => e.ProfessionalId).HasColumnName("professional_id");

            entity.HasOne(d => d.BarberService).WithMany(p => p.ProfessionalServices)
                .HasForeignKey(d => d.BarberServiceId)
                .HasConstraintName("professional_services_barber_service_id_fkey");

            entity.HasOne(d => d.Professional).WithMany(p => p.ProfessionalServices)
                .HasForeignKey(d => d.ProfessionalId)
                .HasConstraintName("professional_services_professional_id_fkey");
        });

        modelBuilder.Entity<ProfessionalWorkDay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("professional_work_days");

            entity.Property(e => e.ProfessionalId).HasColumnName("professional_id");
            entity.Property(e => e.WorkDayId).HasColumnName("work_day_id");

            entity.HasOne(d => d.Professional).WithMany()
                .HasForeignKey(d => d.ProfessionalId)
                .HasConstraintName("professional_work_days_professional_id_fkey");

            entity.HasOne(d => d.WorkDay).WithMany()
                .HasForeignKey(d => d.WorkDayId)
                .HasConstraintName("professional_work_days_work_day_id_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => new { e.ReviewId, e.CustomerId, e.ScheduledServiceId }).HasName("pk_review_customer_service");

            entity.ToTable("reviews");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedOnAdd()
                .HasColumnName("review_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ScheduledServiceId).HasColumnName("scheduled_service_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewText).HasColumnName("review_text");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reviews_customer_id_fkey");

            entity.HasOne(d => d.ScheduledService).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ScheduledServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reviews_scheduled_service_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("sale_pkey");

            entity.ToTable("sale");

            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.FinalizedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finalized_at");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");

            entity.HasMany(d => d.Items).WithMany(p => p.Sales)
                .UsingEntity<Dictionary<string, object>>(
                    "SaleItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("sale_items_item_id_fkey"),
                    l => l.HasOne<Sale>().WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("sale_items_sale_id_fkey"),
                    j =>
                    {
                        j.HasKey("SaleId", "ItemId").HasName("pk_sale_item");
                        j.ToTable("sale_items");
                        j.IndexerProperty<long>("SaleId").HasColumnName("sale_id");
                        j.IndexerProperty<long>("ItemId").HasColumnName("item_id");
                    });

            entity.HasMany(d => d.ScheduledServices).WithMany(p => p.Sales)
                .UsingEntity<Dictionary<string, object>>(
                    "SaleScheduledService",
                    r => r.HasOne<ScheduledService>().WithMany()
                        .HasForeignKey("ScheduledServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("sale_scheduled_services_scheduled_service_id_fkey"),
                    l => l.HasOne<Sale>().WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("sale_scheduled_services_sale_id_fkey"),
                    j =>
                    {
                        j.HasKey("SaleId", "ScheduledServiceId").HasName("pk_sale_scheduled_service");
                        j.ToTable("sale_scheduled_services");
                        j.IndexerProperty<long>("SaleId").HasColumnName("sale_id");
                        j.IndexerProperty<long>("ScheduledServiceId").HasColumnName("scheduled_service_id");
                    });
        });

        modelBuilder.Entity<SaleStatus>(entity =>
        {
            entity.HasKey(e => e.Description).HasName("sale_status_pkey");

            entity.ToTable("sale_status");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("schedules_pkey");

            entity.ToTable("schedules");

            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ProfessionalId).HasColumnName("professional_id");
            entity.Property(e => e.ScheduleStatus)
                .HasMaxLength(50)
                .HasColumnName("schedule_status");
            entity.Property(e => e.ScheduledDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.ScheduleCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("schedules_customer_id_fkey");

            entity.HasOne(d => d.Professional).WithMany(p => p.ScheduleProfessionals)
                .HasForeignKey(d => d.ProfessionalId)
                .HasConstraintName("schedules_professional_id_fkey");
        });

        modelBuilder.Entity<ScheduleStatus>(entity =>
        {
            entity.HasKey(e => e.Description).HasName("schedule_status_pkey");

            entity.ToTable("schedule_status");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<ScheduledService>(entity =>
        {
            entity.HasKey(e => e.ScheduledServiceId).HasName("scheduled_services_pkey");

            entity.ToTable("scheduled_services");

            entity.Property(e => e.ScheduledServiceId).HasColumnName("scheduled_service_id");
            entity.Property(e => e.BarberServiceId).HasColumnName("barber_service_id");
            entity.Property(e => e.EstimatedTime).HasColumnName("estimated_time");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

            entity.HasOne(d => d.BarberService).WithMany(p => p.ScheduledServices)
                .HasForeignKey(d => d.BarberServiceId)
                .HasConstraintName("scheduled_services_barber_service_id_fkey");

            entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduledServices)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("scheduled_services_schedule_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.PhoneNumber, "users_phone_number_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("users_roles_role_id_fkey"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("users_roles_user_id_fkey"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("pk_user_role");
                        j.ToTable("users_roles");
                        j.IndexerProperty<long>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<long>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<WorkDay>(entity =>
        {
            entity.HasKey(e => e.WorkDayId).HasName("work_days_pkey");

            entity.ToTable("work_days");

            entity.Property(e => e.WorkDayId).HasColumnName("work_day_id");
            entity.Property(e => e.ClosesAt).HasColumnName("closes_at");
            entity.Property(e => e.Day)
                .HasMaxLength(20)
                .HasColumnName("day");
            entity.Property(e => e.StartAt).HasColumnName("start_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
