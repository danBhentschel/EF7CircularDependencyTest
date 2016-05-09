using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EFTest;

namespace EFTest.Migrations
{
    [DbContext(typeof(TestContext))]
    partial class TestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("EFTest.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentParentId");

                    b.HasKey("ChildId");
                });

            modelBuilder.Entity("EFTest.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FavoriteChildChildId");

                    b.Property<string>("Name");

                    b.HasKey("ParentId");
                });

            modelBuilder.Entity("EFTest.Child", b =>
                {
                    b.HasOne("EFTest.Parent")
                        .WithMany()
                        .HasForeignKey("ParentParentId");
                });

            modelBuilder.Entity("EFTest.Parent", b =>
                {
                    b.HasOne("EFTest.Child")
                        .WithMany()
                        .HasForeignKey("FavoriteChildChildId");
                });
        }
    }
}
