global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using StudentManagement.Server.API;
global using StudentManagement.Server.Bodies.Req.Common;
global using StudentManagement.Server.Bodies.Req.Specific;
global using StudentManagement.Server.Bodies.Res.Common;
global using StudentManagement.Server.Bodies.Res.Specific;
global using StudentManagement.Server.Database;
global using Swashbuckle.AspNetCore.Annotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Linq.Expressions;
global using System.Reflection;
global using System.Text.Json.Serialization;

namespace StudentManagement.Server
{
    public static class Common
    {
        public record class BacDiem
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool   ? Dat            { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string ? XepLoai        { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public decimal? LonHonHoacBang { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public decimal? NhoHon         { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public decimal? NhoHonHoacBang { get; set; }
        }
    }
}
