using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
namespace StudentManagement.Server.API
{
	public static class API_File
	{
		public static WebApplication MapAPI_File(this WebApplication app)
		{
			app.MapPost("/upload", InternalMethods.UploadFileHandler);
			//app.MapPost("/download", InternalMethods.DownloadFileHandler);
			return app;
		}
		public static class InternalMethods
		{
			public static CloudinaryService? cloudinaryService;
			public static async Task<IResult> UploadFileHandler(
				[FromServices] IConfiguration configuration,
				HttpContext httpContext)
			{
				try
				{
					IFormFileCollection files = httpContext.Request.Form.Files;
					if (files == null || !files.Any())
					{
						return Results.BadRequest("No files selected");
					}
					IEnumerable<IFormFile> validFiles = files.Where(file => (file != null && file.Length > 0));
					if (!validFiles.Any())
					{
						return Results.BadRequest("No valid files upload");
					}
					cloudinaryService = new CloudinaryService(configuration);
					List<string> imageUrls = new();
					foreach (IFormFile file in validFiles)
					{
						imageUrls.Add(await cloudinaryService.UploadImage(file));
					}
					return Results.Ok(new
					{
						ImageUrls = imageUrls
					});
				}
				catch
				{
					return Results.StatusCode(500);
				}
			}
			//public static IResult DownloadFileHandler(
			//	[FromQuery(Name = "imageUrl")] string imageUrl)
			//{
			//	try
			//	{
			//		if (string.IsNullOrEmpty(imageUrl))
			//		{
			//			return Results.BadRequest("Image url is null or empty");
			//		}
			//		var uri = new Uri(imageUrl);
			//		var fileName = System.IO.Path.GetFileName(uri.LocalPath);
			//		var fileExtension = System.IO.Path.GetExtension(uri.LocalPath).TrimStart('.');

			//		var response = Results.File(imageUrl, $"application/{fileExtension}", fileName);
			//		return response;
			//	}
			//	catch
			//	{
			//		return Results.StatusCode(500);
			//	}
			//}
		}
	}
}
