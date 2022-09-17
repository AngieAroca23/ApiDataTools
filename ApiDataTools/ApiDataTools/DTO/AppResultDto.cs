using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace ApiDataTools.DTO
{
    public class AppResultDto
    {
		public bool IsSuccessful { get; set; } = true;
		public int StatusCode { get; set; } = 200;
		public string Message { get; set; }


		public AppResultDto()
		{
		}

		internal AppResultDto(bool isSuccessful, string message, int statusCode = 200)
		{
			IsSuccessful = isSuccessful;
			Message = message;
			StatusCode = statusCode;
		}

		public static AppResultDto CreateSuccessful(string message = null)
		{
			return new AppResultDto(isSuccessful: true, message);
		}

		public static AppResultDto CreateError(string errorMessage, int statusCode = 500)
		{
			return new AppResultDto(isSuccessful: false, errorMessage, statusCode);
		}

		public static string CreateErrorMessage(string errorMessage, int statusCode = 500)
		{
			return new AppResultDto(isSuccessful: false, errorMessage,  statusCode).ToString();
		}

		public override string ToString()
		{
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new List<JsonConverter>
			{
				new StringEnumConverter()
			}
			};
			return JsonConvert.SerializeObject(this, settings);
		}
	}
}
