namespace Arc.Models.BusinessLogic.Models.FilterProperties;

public record FilterPropertyRequestModel(
    string Property,
    string Operation,
    string Value
);