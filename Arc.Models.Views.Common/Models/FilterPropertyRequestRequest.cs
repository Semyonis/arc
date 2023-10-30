namespace Arc.Models.Views.Common.Models;

public record FilterPropertyRequestRequest(
    string Property,
    string Operation,
    string Value
);