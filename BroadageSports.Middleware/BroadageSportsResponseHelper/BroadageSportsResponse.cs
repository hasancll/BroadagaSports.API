using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Middleware.BroadageSportsResponseHelper
{
    public class BroadageSportsResponse
    {
        public static String GetBroadagaSportsResponseModel(bool isSucces, String statusCode, String message, object response = null)
        {
            var responseModel = new BroadagaSportsModel();

            responseModel.IsSuccess = isSucces.ToString();
            responseModel.Message = message;
            responseModel.StatusCode = statusCode;
            responseModel.Response = response;

            return JsonConvert.SerializeObject(responseModel);
        }
        public static BroadagaSportsModel GetBroadageSportsModelTry(bool isSucces, String statusCode, String message, object response = null)
        {
            var responseModel = new BroadagaSportsModel();

            responseModel.IsSuccess = isSucces.ToString();
            responseModel.Message = message;
            responseModel.StatusCode = statusCode;
            responseModel.Response = response;

            return responseModel;
        }
    }
}
