
namespace RoomsEnglish.Api.Endpoints.User;

public static class UserEndpoints
{
    private static string[] Tags = ["User"];

    public static WebApplication MapUsersEndpoints(this WebApplication app)
    {

       // app.MapPost(ApiEndpointsPaths.Cities, async (CreateCityModel model, IMediator mediator) =>
        //    {

        //        var result = await mediator.Send(model.FromCommand());

        //        ModelResult<CityModel> response = result.FromModel();

        //        return result.CreateResult(response, status201CreatedPath: $"{ApiEndpointsPaths.States}/{result.Data?.Id}");


        //    })
        //    .WithName("CreateCity")
        //    .WithTags(Tags)
        //    .Produces<ModelResult<CityModel>>(StatusCodes.Status201Created)
        //    .Produces<ModelResultBase>(StatusCodes.Status400BadRequest)
        //    .Produces<ModelResultBase>(StatusCodes.Status404NotFound)
        //    .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        //app.MapGet(ApiEndpointsPaths.Cities, async (PagingData queryModel, IMediator mediator) =>
        //{
        //    var query = new GetCitiesWithPaginationQuery()
        //    {
        //        PageNumber = queryModel.Page,
        //        PageSize = queryModel.PageSize
        //    };

        //    var result = await mediator.Send(query);

        //    var dataResult = result.Results?
        //    .Select(CitiesDataModelsExtensions.FromCityModel)
        //    .ToArray();

        //    return new ModelResult<IEnumerable<CityModel>>(dataResult!);

        //})
        //    .WithName("ListCities")
        //    .WithTags(Tags)
        //    .Produces<ModelResult<IEnumerable<CityModel>>>(StatusCodes.Status200OK)
        //    .Produces<ModelResultBase>(StatusCodes.Status500InternalServerError);
        
        //app.MapGet($"{ApiEndpointsPaths.Cities}/search", async (string? term, PagingData queryModel, IMediator mediator) =>
        //{
        //    var query = new SearchCitiesParametersQuery()
        //    {
        //        Term = term,
        //        PageNumber = queryModel.Page,
        //        PageSize = queryModel.PageSize
        //    };

        //    var result = await mediator.Send(query);

        //    var dataResult = result.Results?
        //    .Select(CitiesDataModelsExtensions.FromCityModel)
        //    .ToArray();

        //    return new ModelResult<IEnumerable<CityModel>>(dataResult!);

        //})
        //    .WithName("SearhCities")
        //    .WithTags(Tags)
        //    .Produces<ModelResult<IEnumerable<CityModel>>>(StatusCodes.Status200OK)
        //    .Produces<ModelResultBase>(StatusCodes.Status500InternalServerError);

        //app.MapGet($"{ApiEndpointsPaths.Cities}/{{ibgeCode}}", async (string ibgeCode, IMediator mediator) =>
        //{

        //    var query = new GetCityDetailByIbgeCodeQuery(ibgeCode);

        //    var result = await mediator.Send(query);

        //    var response = result.Results?.FromCityModel();

        //    var modelResult = new ModelResult<CityModel>(response);

        //    return result.Results is not null ? Results.Ok(modelResult) : Results.NotFound(modelResult);


        //})
        //    .WithName("CityDetails")
        //    .WithTags(Tags)
        //    .Produces<ModelResult<CityModel>>(StatusCodes.Status200OK)
        //    .Produces<ModelResultBase>(StatusCodes.Status404NotFound)
        //    .Produces<ModelResultBase>(StatusCodes.Status500InternalServerError);

        //app.MapPut($"{ApiEndpointsPaths.Cities}/{{ibgeCode}}", async (string ibgeCode, UpdateCityModel model, IMediator mediator) =>
        //   {
        //       var result = await mediator.Send(model.FromCommand(ibgeCode));

        //       ModelResult<CityModel> response = result.FromModel();

        //       return result.CreateResult(response);
        //   })
        //   .WithName("UpdateCity")
        //   .WithTags(Tags)
        //   .Produces<ModelResult<CityModel>>(StatusCodes.Status200OK)
        //   .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        //app.MapDelete($"{ApiEndpointsPaths.Cities}/{{ibgeCode}}", async (string ibgeCode, IMediator mediator) =>
        //    {
        //        var result = await mediator.Send(ibgeCode.FromCommand());

        //        ModelResultBase response = result.FromModel();

        //        return result.CreateResult(response);

        //    })
        //    .WithName("DeleteCity")
        //    .WithTags(Tags)
        //    .Produces<ModelResultBase>(StatusCodes.Status200OK)
        //    .Produces<ModelResultBase>(StatusCodes.Status422UnprocessableEntity);

        return app;
    }
}
