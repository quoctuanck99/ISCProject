using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISCProject_Models
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
        public virtual DbSet<ReportAccount> ReportAccount { get; set; }
        public virtual DbSet<ReportPost> ReportPost { get; set; }
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
                    .HasName("UQ__Account__6894C54AC2CEABAE")
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
                    .HasName("PK__Account___91C2B49162DFA713");

                entity.ToTable("Account_role");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRole)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account_r__accou__4F7CD00D");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account_r__role___5070F446");
            });

            modelBuilder.Entity<Ads>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__Ads__3ED787664AB8276F");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AgeFrom).HasColumnName("age_from");

                entity.Property(e => e.AgeTo).HasColumnName("age_to");

                entity.HasOne(d => d.Post)
                    .WithOne(p => p.Ads)
                    .HasForeignKey<Ads>(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ads__post_id__5165187F");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => new { e.PostId, e.AccountId })
                    .HasName("UQ__Comment__FABDA54B124F673C")
                    .IsUnique();

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Comment__account__52593CB8");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Comment__post_id__534D60F1");
            });

            modelBuilder.Entity<FavoritePost>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.AccountId })
                    .HasName("PK__Favorite__FABDA54A0BCB77EC");

                entity.ToTable("Favorite_post");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FavoritePost)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorite___accou__5441852A");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.FavoritePost)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorite___post___5535A963");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.FollowingId })
                    .HasName("PK__Follow__C82D964572E6C1DC");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.FollowingId).HasColumnName("following_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FollowAccount)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Follow__account___5629CD9C");

                entity.HasOne(d => d.Following)
                    .WithMany(p => p.FollowFollowing)
                    .HasForeignKey(d => d.FollowingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Follow__followin__571DF1D5");
            });

            modelBuilder.Entity<HashTag>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PK__Hash_tag__4296A2B67B16BC04");

                entity.ToTable("Hash_tag");

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
                    .HasMaxLength(50);
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
                    .HasConstraintName("FK__Message__partici__5812160E");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasIndex(e => new { e.AccountId, e.RoomId })
                    .HasName("UQ__Particip__F7345764A158B527")
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
                    .HasConstraintName("FK__Participa__accou__59063A47");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Participa__room___59FA5E80");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Checkin)
                    .HasColumnName("checkin")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsAds).HasColumnName("is_ads");

                entity.Property(e => e.NumbFavorite).HasColumnName("numb_favorite");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Post__account_id__5AEE82B9");
            });

            modelBuilder.Entity<PostImage>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.ImageId })
                    .HasName("PK__Post_ima__731E2BF397767C25");

                entity.ToTable("Post_image");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.PostImage)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_imag__image__5BE2A6F2");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostImage)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_imag__post___5CD6CB2B");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId })
                    .HasName("PK__Post_tag__4AFEED4DA1397681");

                entity.ToTable("Post_tag");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_tag__post_i__5DCAEF64");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_tag__tag_id__5EBF139D");
            });

            modelBuilder.Entity<PostVideo>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.VideoId })
                    .HasName("PK__Post_vid__20589687D1F2CD68");

                entity.ToTable("Post_video");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.VideoId).HasColumnName("video_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostVideo)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_vide__post___5FB337D6");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.PostVideo)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_vide__video__60A75C0F");
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
                    .HasConstraintName("FK__Report__account___619B8048");
            });

            modelBuilder.Entity<ReportAccount>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.AccountId })
                    .HasName("PK__Report_a__B3F15E748CFF4E75");

                entity.ToTable("Report_account");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ReportAccount)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_ac__accou__628FA481");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportAccount)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_ac__repor__6383C8BA");
            });

            modelBuilder.Entity<ReportPost>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.PostId })
                    .HasName("PK__Report_p__0476042EDDC64D0B");

                entity.ToTable("Report_post");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.ReportPost)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_po__post___6477ECF3");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportPost)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report_po__repor__656C112C");
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
                    .HasName("PK__User__46A222CD38F90C67");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__AB6E6164AF36BFF8")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__User__B43B145FB82B7F63")
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
                    .HasConstraintName("FK__User__account_id__66603565");
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
