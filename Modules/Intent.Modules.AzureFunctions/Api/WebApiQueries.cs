using System;
using System.Linq;
using Intent.Modelers.Services.Api;

namespace Intent.AzureFunctions.Api;

public static class WebApiQueries
{
    public static ParameterModel GetRequestDtoParameter(this OperationModel operationModel)
    {
        var dtoParams = operationModel.Parameters
            .Where(IsParameterBody)
            .ToArray();
        switch (dtoParams.Length)
        {
            case 0:
                return null;
            case > 1:
                throw new Exception($"Multiple DTOs not supported on {operationModel.Name} operation");
            default:
            {
                var param = dtoParams.First();
                return param;
            }
        }
    }

    private static bool IsParameterBody(ParameterModel parameterModel)
    {
        return parameterModel.GetParameterSetting()?.Source().IsFromBody() == true
               || (parameterModel.GetParameterSetting()?.Source().IsDefault() == true &&
                   parameterModel.TypeReference.Element.IsDTOModel());
    }
}