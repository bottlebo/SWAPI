using System.Net;
//
namespace SWAPI.SERVICES
{
  public class ServiceOperationResult
  {
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Errors { get; set; } = String.Empty;
    //
    public static ServiceOperationResult Ok() => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.OK
    };

    public static ServiceOperationResult<TData> Ok<TData>(TData data) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.OK,
      Data = data
    };


    public static ServiceOperationResult Accepted() => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.Accepted
    };

    public static ServiceOperationResult<TData> Accepted<TData>(TData data) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.Accepted,
      Data = data
    };

    public static ServiceOperationResult NoContent() => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.NoContent
    };

    public static ServiceOperationResult<TData> NoContent<TData>(TData data) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.NoContent,
      Data = data
    };
    public static ServiceOperationResult BadRequest(string errors) => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.BadRequest,
      Errors = errors
    };

    public static ServiceOperationResult<TData> BadRequest<TData>(string errors) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.BadRequest,
      Errors = errors
    };


    public static ServiceOperationResult Unauthorized() => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.Unauthorized,
    };

    public static ServiceOperationResult<TData> Unauthorized<TData>() => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.Unauthorized,
    };


    public static ServiceOperationResult NotFound(string errors) => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.NotFound,
      Errors = errors
    };

    public static ServiceOperationResult<TData> NotFound<TData>(string errors) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.NotFound,
      Errors = errors
    };


    public static ServiceOperationResult Conflict(string errors) => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.Conflict,
      Errors = errors
    };

    public static ServiceOperationResult<TData> Conflict<TData>(string errors) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.Conflict,
      Errors = errors
    };

    public static ServiceOperationResult UnprocessableEntity(string errors) => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.UnprocessableEntity,
      Errors = errors
    };
    public static ServiceOperationResult UnprocessableEntity(Exception e) => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.UnprocessableEntity,
      Errors = e.InnerException == null ? e.Message : e.InnerException.Message
    };

    public static ServiceOperationResult<TData> UnprocessableEntity<TData>(string errors) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.UnprocessableEntity,
      Errors = errors
    };
    public static ServiceOperationResult<TData> UnprocessableEntity<TData>(Exception e) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.UnprocessableEntity,
      Errors = e.InnerException == null ? e.Message : e.InnerException.Message
    };
    public static ServiceOperationResult InternalServerError(string errors) => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.InternalServerError,
      Errors = errors
    };

    public static ServiceOperationResult<TData> InternalServerError<TData>(string errors) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.InternalServerError,
      Errors = errors
    };
    public static ServiceOperationResult NotImplemented(string errors) => new ServiceOperationResult()
    {
      StatusCode = HttpStatusCode.NotImplemented,
      Errors = errors
    };

    public static ServiceOperationResult<TData> NotImplemented<TData>(string errors) => new ServiceOperationResult<TData>()
    {
      StatusCode = HttpStatusCode.NotImplemented,
      Errors = errors
    };

  }
  //
  public class ServiceOperationResult<TData> : ServiceOperationResult
  {
    public TData Data { get; set; }

    public static ServiceOperationResult<TData> FromDataless(ServiceOperationResult serviceOperationResult) => new ServiceOperationResult<TData>
    {
      Errors = serviceOperationResult.Errors,
      StatusCode = serviceOperationResult.StatusCode
    };
  }
}
