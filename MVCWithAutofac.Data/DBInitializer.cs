using MVCWithAutofac.Core.Model;
using System.Data.Entity;


namespace MVCWithAutofac.Data
{
    public class DBInitializer : CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            var sqlRep = new SqlRepository(context);

            var userSul = new User { Name = "Abhi", Description = "Abhi user description", email = "abhi@email.com"};
            var userJames = new User { Name = "Emmiliean", Description = "Emmiliean user description", email = "emmiliean@email.com"};
            var userNikolay = new User { Name = "Nikolay", Description = "Nikolay user description", email = "nikolay@email.com" };
            sqlRep.Insert<User>(userSul);
            sqlRep.Insert<User>(userJames);
            sqlRep.Insert<User>(userNikolay);


            var newTask = new TaskStatus { Name = "New", Description = "New Task"};
            var inProgressTask = new TaskStatus { Name = "In Progress", Description = "In Progress Task" };
            var closedTask = new TaskStatus { Name = "Closed", Description = "Closed Task" };
            sqlRep.Insert<TaskStatus>(newTask);
            sqlRep.Insert<TaskStatus>(inProgressTask);
            sqlRep.Insert<TaskStatus>(closedTask);

            var bugTaskType = new TaskType { Name = "Bug", Description = "Bug Task Type" };
            var featureTaskType = new TaskType { Name = "Feature", Description = "Feature Task Type" };
            var enhancementTaskType = new TaskType { Name = "Enhancement", Description = "Enhancement Task Type" };
            sqlRep.Insert<TaskType>(bugTaskType);
            sqlRep.Insert<TaskType>(featureTaskType);
            sqlRep.Insert<TaskType>(enhancementTaskType);

            var Task1 = new Tasks { TaskStatusId = 1, TaskTypeId = 1, Name = "New Task To Be Decided", Description = "New Task To Be Decided", TaskAssignedTo = 1, TaskDateCreated = System.DateTime.Now.ToShortDateString().ToString() };
            var Task2 = new Tasks { TaskStatusId = 2, TaskTypeId = 2, Name = "Some Inprogress Task", Description = "Some Inprogress Task", TaskAssignedTo = 2, TaskDateCreated = System.DateTime.Now.ToShortDateString().ToString() };
            var Task3 = new Tasks { TaskStatusId = 3, TaskTypeId = 3, Name = "This is a closed Task", Description = "This is a closed Task", TaskAssignedTo = 3, TaskDateCreated = System.DateTime.Now.ToShortDateString().ToString() };

            sqlRep.Insert<Tasks>(Task1);
            sqlRep.Insert<Tasks>(Task2);
            sqlRep.Insert<Tasks>(Task3);

            sqlRep.SaveChanges();
            context.SaveChanges();

        }
    }
}
