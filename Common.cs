global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using StudentManagement.Server.Database;
global using StudentManagement.Server.Bodies.Req;
global using StudentManagement.Server.Bodies.Res;
global using StudentManagement.Server.API;
global using System.Linq.Expressions;

namespace StudentManagement.Server
{
    public static class Common
    {
        public record class ResBody<T> where T : IModel<T>
        {
            public IEnumerable<T> Result { get; set; } = null!;
        }
    }
}
