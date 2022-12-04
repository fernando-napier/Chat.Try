﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Chat.Try.Db.Models;

namespace Chat.Try.Db.Context
{
    public partial class ChatContext : DbContext
    {
        public ChatContext()
        {
        }

        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ConversationUsers> ConversationUsers { get; set; }
        public virtual DbSet<Conversations> Conversations { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<ReadReceipts> ReadReceipts { get; set; }
        public virtual DbSet<UserMessages> UserMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ConversationUsers>(entity =>
            {
                entity.ToTable("ConversationUsers", "chat");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.ConversationUsers)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Converstion_On_ConversationUsers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConversationUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConversationUser_On_User");
            });

            modelBuilder.Entity<Conversations>(entity =>
            {
                entity.ToTable("Conversations", "chat");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("Counter", "chat");

                entity.HasIndex(e => e.UserId, "counter_userid_index")
                    .IsUnique();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Counter)
                    .HasForeignKey<Counter>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Counter_On_User");
            });

            modelBuilder.Entity<ReadReceipts>(entity =>
            {
                entity.ToTable("ReadReceipts", "chat");

                entity.HasOne(d => d.UserMessage)
                    .WithMany(p => p.ReadReceipts)
                    .HasForeignKey(d => d.UserMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReadReceipts_On_UserMessages");
            });

            modelBuilder.Entity<UserMessages>(entity =>
            {
                entity.ToTable("UserMessages", "chat");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.ConversationUser)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.ConversationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConversationUsers_On_UserMessages");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}