using Insttantt.Context;

namespace Insttantt.Models
{
    internal class DbInitializer
    {
        internal static void Initialize(ApplicationContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            //FielsdCatalogs
            if (!dbContext.FielsCatalogs.Any())
            {

                var fielsCatalogs = new FielsCatalog[]
                {
                new FielsCatalog{ 
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Code="F-0001",
                    Name="Primer nombre"
                },
                new FielsCatalog{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Code="F-0002",
                    Name="Segundo nombre"
                }
                //add other users
                    };

                foreach (var fielsCatalog in fielsCatalogs)
                    dbContext.FielsCatalogs.Add(fielsCatalog);
            }
            //StepCatalogs
            if (!dbContext.StepsCatalogs.Any())
            {

                var stepsCatalogs = new StepsCatalog[]
                {
                new StepsCatalog{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Code="STP-0001",
                    Name="Paso 1",
                    Target = "Step1",
                    Description = ""
                },
                new StepsCatalog{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Code="STP-0002",
                    Name="Paso 1",
                    Target = "Step2",
                    Description = ""
                },
                new StepsCatalog{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    Code="STP-0003",
                    Name="Paso 3",
                    Target = "Step3",
                    Description = ""
                },
                new StepsCatalog{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa9"),
                    Code="STP-0004",
                    Name="Paso 4",
                    Target = "Step4",
                    Description = ""
                }
                    };

                foreach (var stepsCatalog in stepsCatalogs)
                    dbContext.StepsCatalogs.Add(stepsCatalog);
            }
            //Flow
            if (!dbContext.Flows.Any())
            {

                var flows = new Flow[]
                {
                new Flow{ 
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Description = "Flujo1"
                }
                //add other users
                    };

                foreach (var flow in flows)
                    dbContext.Flows.Add(flow);
            }
            //FlowConfig
            if (!dbContext.FlowConfigs.Any())
            {

                var flowConfigs = new FlowConfig[]
                {
                new FlowConfig{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Flow= dbContext.Flows.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    StepsCatalog = dbContext.StepsCatalogs.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    Level = 1
                },
                new FlowConfig{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Flow= dbContext.Flows.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    StepsCatalog = dbContext.StepsCatalogs.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7")),
                    Level = 2
                },
                new FlowConfig{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    Flow= dbContext.Flows.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    StepsCatalog = dbContext.StepsCatalogs.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa8")),
                    Level = 3
                },
                new FlowConfig{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa9"),
                    Flow= dbContext.Flows.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    StepsCatalog = dbContext.StepsCatalogs.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa9")),
                    Level = 4
                }
                    };

                foreach (var flowConfig in flowConfigs)
                    dbContext.FlowConfigs.Add(flowConfig);
            }

            //Users
            if (!dbContext.Users.Any())
            {

                var users = new User[]
                {
                new User{ Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6") }
                //add other users
                    };

                foreach (var user in users)
                    dbContext.Users.Add(user);
            }
            //UserFields
            if (!dbContext.UserFields.Any())
            {

                var usersFiels = new UserField[]
                {
                new UserField{ 
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    User= dbContext.Users.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    FielsCatalog = dbContext.FielsCatalogs.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    Value = "Oswaldo"
                },
                new UserField{
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    User= dbContext.Users.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                    FielsCatalog = dbContext.FielsCatalogs.Find(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7")),
                    Value = "Ortiz"
                }
                    };

                foreach (var usersField in usersFiels)
                    dbContext.UserFields.Add(usersField);
            }

            dbContext.SaveChanges();
        }
    }
}
