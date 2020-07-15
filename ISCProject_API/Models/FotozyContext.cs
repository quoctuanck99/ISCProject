using System;
using ISCProject_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISCProject_API.Models
{
    public partial class FotozyContext : DbContext
    {
        public FotozyContext()
        {
        }

        public FotozyContext(DbContextOptions<FotozyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountRole> AccountRole { get; set; }
        public virtual DbSet<Ads> Ads { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<FavoritePost> FavoritePost { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<HashTag> HashTag { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostImage> PostImage { get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }
        public virtual DbSet<PostVideo> PostVideo { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportPost> ReportPost { get; set; }
        public virtual DbSet<ReportUser> ReportUser { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Fotozy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.AccountName)
                    .HasName("UQ__Account__6894C54A2DBB7177")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnName("account_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HashedPassword)
                    .IsRequired()
                    .HasColumnName("hashed_password")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.RoleId })
                    .HasName("PK__Account___91C2B4911BBE81F1");

                entity.ToTable("Account_role");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRole)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account_r__accou__5070F446");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account_r__role___5165187F");
            });

            modelBuilder.Entity<Ads>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__Ads__3ED78766C1FE88EC");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AgeFrom).HasColumnName("age_from");

                entity.Property(e => e.AgeTo).HasColumnName("age_to");

                entity.HasOne(d => d.Post)
                    .WithOne(p => p.Ads)
                    .HasForeignKey<Ads>(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ads__post_id__52593CB8");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => new { e.PostId, e.AccountId })
                    .HasName("UQ__Comment__FABDA54B592C5A24")
                    .IsUnique();

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(500);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__account__534D60F1");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__post_id__5441852A");
            });

            modelBuilder.Entity<FavoritePost>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.AccountId })
                    .HasName("PK__Favorite__FABDA54A34E55A42");

                entity.ToTable("Favorite_post");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FavoritePost)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorite___accou__5535A963");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.FavoritePost)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorite___post___5629CD9C");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.FollowingId })
                    .HasName("PK__Follow__C82D96453EDF4A6D");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.FollowingId).HasColumnName("following_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FollowAccount)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Follow__account___571DF1D5");

                entity.HasOne(d => d.Following)
                    .WithMany(p => p.FollowFollowing)
                    .HasForeignKey(d => d.FollowingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Follow__followin__5812160E");
            });

            modelBuilder.Entity<HashTag>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PK__Hash_tag__4296A2B67D257018");

                entity.ToTable("Hash_tag");

                entity.HasIndex(e => e.TagName)
                    .HasName("UQ__Hash_tag__E298655CA69FF587")
                    .IsUnique();

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasColumnName("tag_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.DateUploaded)
                    .HasColumnName("date_uploaded")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImageName)
                    .HasColumnName("image_name")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParticipantId).HasColumnName("participant_id");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.ParticipantId)
                    .HasConstraintName("FK__Message__partici__59063A47");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasIndex(e => new { e.AccountId, e.RoomId })
                    .HasName("UQ__Particip__F7345764376A9725")
                    .IsUnique();

                entity.Property(e => e.ParticipantId).HasColumnName("participant_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.NickName)
                    .HasColumnName("nick_name")
                    .HasMaxLength(50);

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__accou__59FA5E80");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__room___5AEE82B9");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Checkin)
                    .HasColumnName("checkin")
                    .HasMaxLength(500);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.IsAds).HasColumnName("is_ads");

                entity.Property(e => e.NumbFavorite).HasColumnName("numb_favorite");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post__account_id__5BE2A6F2");
            });

            modelBuilder.Entity<PostImage>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.ImageId })
                    .HasName("PK__Post_ima__731E2BF3CC8385E0");

                entity.ToTable("Post_image");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.PostImage)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_imag__image__5CD6CB2B");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostImage)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_imag__post___5DCAEF64");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId })
                    .HasName("PK__Post_tag__4AFEED4DC8C66C11");

                entity.ToTable("Post_tag");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_tag__post_i__5EBF139D");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_tag__tag_id__5FB337D6");
            });

            modelBuilder.Entity<PostVideo>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.VideoId })
                    .HasName("PK__Post_vid__2058968767B7963A");

                entity.ToTable("Post_video");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.VideoId).HasColumnName("video_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostVideo)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_vide__post___60A75C0F");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.PostVideo)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_vide__video__619B8048");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsClosed).HasColumnName("is_closed");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__account___628FA481");
            });

            modelBuilder.Entity<ReportPost>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.PostId })
                    .HasName("PK__Report_p__0476042E53FB438A");

                entity.ToTable("Report_post");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.ReportPost)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_po__post___6383C8BA");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportPost)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_po__repor__6477ECF3");
            });

            modelBuilder.Entity<ReportUser>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.AccountId })
                    .HasName("PK__Report_u__B3F15E74846F9C18");

                entity.ToTable("Report_user");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ReportUser)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_us__accou__656C112C");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportUser)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_us__repor__66603565");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.RoomName)
                    .HasColumnName("room_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__User__46A222CDD0C8BE0F");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__AB6E616441EF6458")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__User__B43B145F8A951E0F")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Info)
                    .HasColumnName("info")
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsAgency).HasColumnName("is_agency");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__account_id__6754599E");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.VideoId).HasColumnName("video_id");

                entity.Property(e => e.DateUploaded)
                    .HasColumnName("date_uploaded")
                    .HasColumnType("datetime");

                entity.Property(e => e.VideoName)
                    .HasColumnName("video_name")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
