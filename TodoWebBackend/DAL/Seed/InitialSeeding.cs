using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Seed;

public class InitialSeeding
{
    public static void UseSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>()
            .HasData(new TodoList[]
            {
                new TodoList
                {
                    Id = 1,
                    Name = "Grocery list",
                },
                new TodoList
                {
                    Id = 2,
                    Name = "Work tasks",
                },
                new TodoList
                {
                    Id = 3,
                    Name = "Study plan",
                },
                new TodoList
                {
                    Id = 4,
                    Name = "Home chores",
                }
            });

        modelBuilder.Entity<Todo>()
            .HasData(new Todo[]
            {
                // Grocery list
                new Todo
                {
                    Id = 1,
                    Name = "Bread",
                    Description = null,
                    Active = true,
                    TodoListId = 1,
                },
                new Todo
                {
                    Id = 2,
                    Name = "Milk",
                    Description = "Fat",
                    Active = true,
                    TodoListId = 1,
                },
                new Todo
                {
                    Id = 3,
                    Name = "Cake",
                    Description = "San-Sebastian cake",
                    Active = true,
                    TodoListId = 1,
                },

                // Work tasks
                new Todo
                {
                    Id = 4,
                    Name = "Send report",
                    Description = "Send weekly status report",
                    Active = true,
                    TodoListId = 2,
                },
                new Todo
                {
                    Id = 5,
                    Name = "Review pull request",
                    Description = "Check backend changes",
                    Active = true,
                    TodoListId = 2,
                },
                new Todo
                {
                    Id = 6,
                    Name = "Update documentation",
                    Description = null,
                    Active = false,
                    TodoListId = 2,
                },

                // Study plan
                new Todo
                {
                    Id = 7,
                    Name = "Learn EF Core",
                    Description = "Practice migrations and relationships",
                    Active = true,
                    TodoListId = 3,
                },
                new Todo
                {
                    Id = 8,
                    Name = "Practice SQL",
                    Description = "Write SELECT and JOIN queries",
                    Active = true,
                    TodoListId = 3,
                },
                new Todo
                {
                    Id = 9,
                    Name = "Read about LINQ",
                    Description = null,
                    Active = false,
                    TodoListId = 3,
                },

                // Home chores
                new Todo
                {
                    Id = 10,
                    Name = "Clean kitchen",
                    Description = null,
                    Active = true,
                    TodoListId = 4,
                },
                new Todo
                {
                    Id = 11,
                    Name = "Do laundry",
                    Description = "Wash dark clothes",
                    Active = true,
                    TodoListId = 4,
                },
                new Todo
                {
                    Id = 12,
                    Name = "Water plants",
                    Description = null,
                    Active = false,
                    TodoListId = 4,
                }
            });
    }
}