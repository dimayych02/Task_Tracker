using Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

using (var db = new TaskContext())
{
    /*// �������� ������������� ������� ����� ������ �������� (Include/ thenInclude)
    var tasks = db.Tasks
        .Include(a => a!.TaskAuthor)
        .Include(e => e!.Executor);
        //.ToList();
    foreach( var t in tasks)
    {
        Console.WriteLine("������");
        Console.WriteLine($"{t?.TaskAuthor?.AuthorId}");
        Console.WriteLine("�����������");
        Console.WriteLine($"{t?.Executor?.ExecutorId}");
    }
*//*

    var role1 = new Roles() { UserRole = UserRole.�������� };
    var role2 = new Roles() { UserRole = UserRole.������������� };

    db.Roles.AddRange(role1, role2);
    var uR1 = new UserRoles() {Roles = role1};
    var uR2 = new UserRoles() { Roles = role2 };
    db.AddRange(uR1, uR2);
    var us = db.Users.FirstOrDefault();
    us.Roles = new List<UserRoles>() {uR1, uR2 };
    db.SaveChanges();*/
   
}

using (var db = new TaskContext())
{
    /*// ����� �������� ������ (����� ����� Load)
    Console.WriteLine("-----");
    var author = db.Authors.Where(a => a.AuthorId == 5).FirstOrDefault();
    var executor = db.Executors.Where(e => e.ExecutorId == 2).FirstOrDefault();

    db.Entry(executor).Collection(e => e.ExecutorTasks).Load();
    foreach (var e in executor.ExecutorTasks)
        Console.WriteLine(e.TaskName);

    db.Entry(author).Collection(a => a.AuthorTasks).Load();
    foreach (var a in author.AuthorTasks)
        Console.WriteLine(a.TaskName);

    var executor1 = db.Executors.Where(e => e.UserId == 18).FirstOrDefault();
    db.Entry(executor1).Reference(e => e.TaskExecutor).Load();
    Console.WriteLine($"�����������:{executor1.TaskExecutor.Name}");*/

    //db.Users.Load();
    var at = db.Authors.ToList();
    Console.WriteLine("----------------------");
    at.ForEach(a =>
    {
        Console.WriteLine("------���������");
        Console.WriteLine(a?.TaskAuthor?.Name);
    });
}

