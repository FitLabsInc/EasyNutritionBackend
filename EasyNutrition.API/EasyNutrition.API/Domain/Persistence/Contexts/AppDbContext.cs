using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionDetail> SessionDetails { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Entidad Role

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(p => p.Id);
            builder.Entity<Role>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Role>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId);

            // Agregar data a Role
            builder.Entity<Role>().HasData
                (
                    new Role { Id = 1, Name = "Nutricionista" },
                    new Role { Id = 2, Name = "Cliente" },
                    new Role { Id = 3, Name = "Administrador" },
                    new Role { Id = 4, Name = "Invitado" }


                );

            // Entidad User

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id);
            builder.Entity<User>().Property(p => p.Username)
                .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Password)
               .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Name)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Lastname)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Birthday)
               .IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Email)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Phone)
               .IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Address)
               .IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(p => p.Active)
              .IsRequired();
            builder.Entity<User>().Property(p => p.Linkedin);

            builder.Entity<User>()
              .HasOne(pt => pt.Role)
              .WithMany(p => p.Users)
              .HasForeignKey(pt => pt.RoleId);

            builder.Entity<User>()
             .HasMany(pt => pt.Subscriptions)
             .WithOne(p => p.User)
             .HasForeignKey(pt => pt.UserId);

              builder.Entity<User>()
            .HasMany(pt => pt.Schedules)
            .WithOne(p => p.User)
            .HasForeignKey(pt => pt.UserId);



            builder.Entity<User>().HasData
          (
               new User { Id = 1, Username = "Alfredo Gomez", Password = "dbJe*D4xqfd|e]*p&", Name = "Alfredo", Lastname = "Gomez", Birthday = "10/10/1985", Email = "alfredito@gmail.com", Phone = "97531546", Address = "Las Malvinas 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 2, Username = "Hernesto Sanchez", Password = "1WH1wm%tL#AUsgqB@", Name = "Hernesto", Lastname = "Sanchez", Birthday = "10/10/1990", Email = "hernes@gmail.com", Phone = "97531546", Address = "Las Malvinas 667", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 3, Username = "Agusto Hernandez", Password = "exCBHH0UdzyGpCxE~", Name = "Agusto", Lastname = "Hernandez", Birthday = "10/10/1970", Email = "augus@gmail.com", Phone = "97532346", Address = "Las Poncinas 314", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 2 },
               new User { Id = 4, Username = "Jeremy ALfonso", Password = "HYO|@o7XJK@T<^W(^", Name = "Jeremy", Lastname = "ALfonso", Birthday = "10/10/1989", Email = "jere@gmail.com", Phone = "978561234", Address = "Villanueva 454", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 3 },
               new User { Id = 5, Username = "Augusto Salazar", Password = "1b}%Ct(Th*(0odt1l", Name = "Augusto", Lastname = "Salazar", Birthday = "10/10/1987", Email = "augus_14@gmail.com", Phone = "97512346", Address = "Las doce 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 2 },
               new User { Id = 6, Username = "Yimmy Neutron", Password = "MW~#o2z2#I)!WjDKR", Name = "Yimmy", Lastname = "Neutron", Birthday = "10/10/1982", Email = "yim23@gmail.com", Phone = "97559746", Address = "CHavin 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 7, Username = "Steve Robi", Password = "7k<GV(qEe%PHJOFc#", Name = "Steve", Lastname = "Robi", Birthday = "10/10/1990", Email = "steve789@gmail.com", Phone = "97539756", Address = "Cajamarca 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 2 },
               new User { Id = 8, Username = "Sandro Quispe", Password = "mh$!iPSvXAfCWkh$f", Name = "Sandro", Lastname = "Quispe", Birthday = "10/10/1990", Email = "san23@gmail.com", Phone = "94561546", Address = "Av. Ayacucho 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 3 },
               new User { Id = 9, Username = "Ali Jamelio", Password = "OHG2|CZ^9Z6#d!*Xf", Name = "Ali", Lastname = "Jamelio", Birthday = "10/10/1987", Email = "alimoha@gmail.com", Phone = "97821546", Address = "Av- Bolivar 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 10, Username = "Angel Gavidia", Password = "ZNrr&l*xeucG2W(*D", Name = "Angel", Lastname = "Gavidia", Birthday = "10/10/1989", Email = "angel123@gmail.com", Phone = "94861546", Address = "Alfonso Ugarte 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 4 }

          );
            // Entidad Subscription

            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.MaxSessions)
                .IsRequired();
            builder.Entity<Subscription>().Property(p => p.Price)
                  .IsRequired();
            builder.Entity<Subscription>().Property(p => p.Active)
                .IsRequired();


            builder.Entity<Subscription>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Subscriptions)
             .HasForeignKey(pt => pt.UserId);

            // Agregar data a Subscription
            builder.Entity<Subscription>().HasData
                 (
                     new Subscription { Id = 1, MaxSessions = 4, Price = 10, Active = true, UserId = 1 },
                     new Subscription { Id = 2, MaxSessions = 1, Price = 13, Active = true, UserId = 2 },
                     new Subscription { Id = 3, MaxSessions = 4, Price = 10, Active = true, UserId = 3 },
                     new Subscription { Id = 4, MaxSessions = 4, Price = 10, Active = true, UserId = 4 },
                     new Subscription { Id = 5, MaxSessions = 4, Price = 10, Active = true, UserId = 5 },
                     new Subscription { Id = 6, MaxSessions = 4, Price = 10, Active = true, UserId = 6 },
                     new Subscription { Id = 7, MaxSessions = 4, Price = 10, Active = true, UserId = 7 },
                     new Subscription { Id = 8, MaxSessions = 4, Price = 10, Active = true, UserId = 8 },
                     new Subscription { Id = 9, MaxSessions = 4, Price = 10, Active = true, UserId = 9 },
                     new Subscription { Id = 10, MaxSessions = 4, Price = 10, Active = true, UserId = 10 }
                 );

            // Entidad Schedule

            builder.Entity<Schedule>().ToTable("Schedules");
            builder.Entity<Schedule>().HasKey(p => p.Id);
            builder.Entity<Schedule>().Property(p => p.Id);
            builder.Entity<Schedule>().Property(p => p.StartAt)
                .IsRequired();
            builder.Entity<Schedule>().Property(p => p.EndAt)
                  .IsRequired();
            builder.Entity<Schedule>().Property(p => p.State)
                .IsRequired();

            //Entidad Complaint
            builder.Entity<Complaint>().ToTable("Complaint");
            builder.Entity<Complaint>().HasKey(p => p.Id);
            builder.Entity<Complaint>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Complaint>().Property(p => p.Description)
                .IsRequired().HasMaxLength(50);

            builder.Entity<Complaint>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Complaints)
             .HasForeignKey(pt => pt.UserId);


            // Agregar data a Complaint
            builder.Entity<Complaint>().HasData
               (
                   new Complaint { Id = 1, Description = "Descripcion de prueba complaint", UserId = 1 },
                   new Complaint { Id = 2, Description = "Descripcion de prueba complaint 2", UserId = 2 },
                   new Complaint { Id = 3, Description = "Descripcion de prueba complaint 3 ", UserId = 3 }
               ); ;
            

            builder.Entity<Schedule>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Schedules)
             .HasForeignKey(pt => pt.UserId);


            builder.Entity<Session>().ToTable("Session");
            builder.Entity<Session>().HasKey(p => p.Id);
            builder.Entity<Session>().Property(p => p.Id)
                  .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Session>().Property(p => p.StartAt)
                .IsRequired();
            builder.Entity<Session>().Property(p => p.EndAt)
                  .IsRequired();
            builder.Entity<Session>().Property(p => p.Link)
                  .IsRequired().HasMaxLength(100);



            builder.Entity<Session>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Sessions)
             .HasForeignKey(pt => pt.UserId);

            builder.Entity<Session>()
                .HasMany(p => p.Diets)
                .WithOne(p => p.Session)
                .HasForeignKey(p => p.SessionId);
            builder.Entity<Session>()
                .HasMany(p => p.Progresses)
                .WithOne(p => p.Session)
                .HasForeignKey(p => p.SessionId);

            // Agregar data a Session
            builder.Entity<Session>().HasData
                  (
                      new Session { Id = 1, StartAt = "Monday, March 24,2019 17:00:00 PM", EndAt = "Monday, March 24 ,2019 18:00:00 PM", Link = "https", UserId = 1 },
                      new Session { Id = 2, StartAt = "Thursday, March 26,2019 20:00:00 PM", EndAt = "Thurday, March 26 ,2019 21:00:00 PM", Link = "https", UserId = 2 },
                      new Session { Id = 3, StartAt = "Monday, March 13,2019 17:00:00 PM", EndAt = "Monday, March 13 ,2019 18:00:00 PM", Link = "https", UserId = 3 },
                      new Session { Id = 4, StartAt = "Monday, March 24,2019 16:00:00 PM", EndAt = "Monday, March 24 ,2019 17:00:00 PM", Link = "https", UserId = 4 },
                      new Session { Id = 5, StartAt = "Monday, March 24,2019 17:00:00 PM", EndAt = "Monday, March 24 ,2019 18:00:00 PM", Link = "https", UserId = 5 },
                      new Session { Id = 6, StartAt = "Monday, March 24,2019 17:00:00 PM", EndAt = "Monday, March 24 ,2019 18:00:00 PM", Link = "https", UserId = 6 },
                      new Session { Id = 7, StartAt = "Thursday, March 26,2019 20:00:00 PM", EndAt = "Thurday, March 26 ,2019 21:00:00 PM", Link = "https", UserId = 7 },
                      new Session { Id = 8, StartAt = "Monday, March 13,2019 17:00:00 PM", EndAt = "Monday, March 13 ,2019 18:00:00 PM", Link = "https", UserId = 8 },
                      new Session { Id = 9, StartAt = "Monday, March 24,2019 16:00:00 PM", EndAt = "Monday, March 24 ,2019 17:00:00 PM", Link = "https", UserId = 9 },
                      new Session { Id = 10, StartAt = "Monday, March 24,2019 17:00:00 PM", EndAt = "Monday, March 24 ,2019 18:00:00 PM", Link = "https", UserId = 10 }

                  );


            //Entidad SessionDetails

            builder.Entity<SessionDetail>().ToTable("SessionDetail");
            builder.Entity<SessionDetail>().HasKey(p => p.Id);
            builder.Entity<SessionDetail>().Property(p => p.Id)
                 .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SessionDetail>().Property(p => p.State)
               .IsRequired().HasMaxLength(100);


            builder.Entity<SessionDetail>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.SessionDetails)
             .HasForeignKey(pt => pt.UserId);

            builder.Entity<SessionDetail>()
            .HasOne(pt => pt.Session)
            .WithMany(p => p.SessionDetails)
            .HasForeignKey(pt => pt.SessionId);

            builder.Entity<Schedule>().HasData
                 (
                     new Schedule { Id = 1, StartAt = "Friday, February 22, 2019 2:00:55 PM", EndAt = "Friday, February 22, 2019 2:40:55 PM", State = true, UserId = 1 },
                     new Schedule { Id = 2, StartAt = "Friday, February 23, 2019 5:00:55 PM", EndAt = "Friday, February 23, 2019 6:40:55 PM", State = true, UserId = 2 },
                     new Schedule { Id = 3, StartAt = "Friday, February 24, 2019 7:00:55 PM", EndAt = "Friday, February 24, 2019 8:40:55 PM", State = true, UserId = 3 },
                     new Schedule { Id = 4, StartAt = "Friday, February 25, 2019 9:00:55 PM", EndAt = "Friday, February 25, 2019 10:40:55 PM",State = true, UserId = 4 },
                     new Schedule { Id = 5, StartAt = "Friday, February 03, 2019 2:00:55 PM", EndAt = "Friday, February 03, 2019 3:40:55 PM", State = true, UserId = 5 },
                     new Schedule { Id = 6, StartAt = "Friday, February 18, 2019 5:00:55 PM", EndAt = "Friday, February 18, 2019 6:40:55 PM", State = true, UserId = 6 },
                     new Schedule { Id = 7, StartAt = "Friday, February 02, 2019 3:00:55 PM", EndAt = "Friday, February 02, 2019 4:40:55 PM", State = true, UserId = 7 },
                     new Schedule { Id = 8, StartAt = "Friday, February 10, 2019 2:00:55 PM", EndAt = "Friday, February 10, 2019 3:40:55 PM", State = true, UserId = 8 },
                     new Schedule { Id = 9, StartAt = "Friday, February 11, 2019 1:00:55 PM", EndAt = "Friday, February 11, 2019 2:40:55 PM", State = true, UserId = 9 },
                     new Schedule { Id = 10,StartAt = "Friday, February 13, 2019 5:00:55 PM", EndAt = "Friday, February 13, 2019 6:40:55 PM", State = true, UserId = 10 }


                 );



    builder.Entity<SessionDetail>().HasData
                (
                    new SessionDetail { Id = 1, State = "Disponible", UserId = 1, SessionId = 1 },
                    new SessionDetail { Id = 2, State = "Disponible", UserId = 1, SessionId = 2 },
                    new SessionDetail { Id = 3, State = "Restringida", UserId = 2, SessionId = 3 },
                    new SessionDetail { Id = 4, State = "Disponible", UserId = 3, SessionId = 4 },
                    new SessionDetail { Id = 5, State = "Disponible", UserId = 4, SessionId = 5 },
                    new SessionDetail { Id = 6, State = "Disponible", UserId = 5, SessionId = 6 },
                    new SessionDetail { Id = 7, State = "Restringida", UserId = 6, SessionId = 7 },
                    new SessionDetail { Id = 8, State = "Disponible", UserId = 7, SessionId = 8 },
                    new SessionDetail { Id = 9, State = "Restringida", UserId = 8, SessionId = 9 },
                    new SessionDetail { Id = 10, State = "Restringida", UserId = 9, SessionId = 10 }


                );

            //Entidad Experience
            builder.Entity<Experience>().ToTable("Experience");
            builder.Entity<Experience>().HasKey(p => p.Id);
            builder.Entity<Experience>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Experience>().Property(p => p.Name)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Experience>().Property(p => p.Description)
                .IsRequired().HasMaxLength(50);

            builder.Entity<Experience>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Experiences)
             .HasForeignKey(pt => pt.UserId);

            // Agregar data a Experience
            builder.Entity<Experience>().HasData
               (
                   new Experience { Id = 1, Name = "Augusto", Description = "Estoy notando los resultados positivos", UserId = 1 },
                   new Experience { Id = 4, Name = "Hernesto", Description = "Excelentes resultados por las dietas", UserId = 2}

               );


            //Entidad Diet
            builder.Entity<Diet>().ToTable("Diets");
            builder.Entity<Diet>().HasKey(p => p.Id);
            builder.Entity<Diet>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Diet>().Property(p => p.Title)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Diet>().Property(p => p.Description)
                .IsRequired().HasMaxLength(500);

            // Agregar data a Diet
            builder.Entity<Diet>().HasData
              (
                  new Diet { Id = 1, Title = "Dieta Vegetariana", Description = "Lunes: x Martes: x Miercoles: x", SessionId = 1 },
                  new Diet { Id = 2, Title = "Dieta para aumentar masa musuclar", Description = "Lunes: x Martes: x Miercoles: x", SessionId = 2 },
                  new Diet { Id = 3, Title = "Dieta miniCut", Description = "Lunes: x Martes: x Miercoles: x", SessionId = 3 },
                  new Diet { Id = 4, Title = "Dieta Tonificación Muscular", Description = "Lunes: x Martes: x Miercoles: x", SessionId = 4 },
                  new Diet { Id = 5, Title = "Dieta definición", Description = "Lunes: x Martes: x Miercoles: x", SessionId = 5 }


              );

            //Entidad Progress
            builder.Entity<Progress>().ToTable("Progresses");
            builder.Entity<Progress>().HasKey(p => p.Id);
            builder.Entity<Progress>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Progress>().Property(p => p.Description)
                .IsRequired().HasMaxLength(500);

            // Agregar data a Diet
            builder.Entity<Progress>().HasData
              (
                  new Progress { Id = 1, Description = "Bajó 4 kilos", SessionId = 1 },
                  new Progress { Id = 2, Description = "Aumentó su masa en 3 kilos", SessionId = 2 },
                  new Progress { Id = 3, Description = "Logró bajar mi porcentaje de grasa a un 12%", SessionId = 3 },
                  new Progress { Id = 4, Description = "Aumentó 1kg de masa muscular", SessionId = 4 },
                  new Progress { Id = 5, Description = "Aumentó su masa en 2 kilos", SessionId = 5 }

              );


            // Apply Naming Conventions Policy

            builder.ApplySnakeCaseNamingConvention();

        }



    }
}
