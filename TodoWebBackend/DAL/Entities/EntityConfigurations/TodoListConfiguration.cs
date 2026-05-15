using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities.EntityConfigurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>

{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}