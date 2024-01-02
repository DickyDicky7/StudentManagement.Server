using System.Reflection;

namespace StudentManagement.Server
{
    public class SchemaFilterOnCommonRequestVirtualProperty : Swashbuckle.AspNetCore.SwaggerGen.ISchemaFilter
    {
        public void Apply(
            Microsoft.OpenApi.Models.OpenApiSchema schema,Swashbuckle.AspNetCore.SwaggerGen.SchemaFilterContext context)
        {
            IEnumerable<PropertyInfo> virtualPropertyInfos =
            context
            .Type.GetProperties()
            .Where(propertyInfo =>
            propertyInfo.GetMethod != null &&
            propertyInfo.GetMethod!.IsVirtual &&
            propertyInfo.SetMethod != null &&
            propertyInfo.SetMethod!.IsVirtual);
            foreach (PropertyInfo virtualPropertyInfo in virtualPropertyInfos)
            {
                string virtualPropertyToHide =
                    schema.Properties.Keys.SingleOrDefault(key => key.ToLower() == virtualPropertyInfo.Name.ToLower())!;
                if (virtualPropertyToHide != null)
                {
                    schema.Properties[
                    virtualPropertyToHide].ReadOnly = true;
                    //schema.Properties.Remove(virtualPropertyToHide);
                }
            }
        }
    }
}
