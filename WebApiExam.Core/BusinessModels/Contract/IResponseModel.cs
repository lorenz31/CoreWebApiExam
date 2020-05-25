namespace WebApiExam.Core.BusinessModels.Contract
{
    public interface IResponseModel
    {
        bool Status { get; set; }
        string Message { get; set; }
    }
}
