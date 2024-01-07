//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

//namespace StudentManagement.Server
//{
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
//    public class CustomCandidateNamingService : CandidateNamingService
//    {
//        public override string GetDependentEndCandidateNavigationPropertyName(IReadOnlyForeignKey foreignKey)
//        {
//            string name = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase
//            (foreignKey.Properties[0].GetColumnName().Replace("ma_", string.Empty).Replace('_', ' ')).Replace(" ", string.Empty);
//            return name;
//        }
//    }

//    public class DesignTimeServices : IDesignTimeServices
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
//        public void ConfigureDesignTimeServices(IServiceCollection services)
//        {
//            services.AddSingleton<ICandidateNamingService, CustomCandidateNamingService>();
//        }
//    }
//}
