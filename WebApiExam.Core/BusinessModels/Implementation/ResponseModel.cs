using WebApiExam.Core.BusinessModels.Contract;

namespace WebApiExam.Core.BusinessModels.Implementation
{
    public class ResponseModel : IResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}