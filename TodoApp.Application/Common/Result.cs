using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Application.Common;

public class Result
{
    // Indicates whether the operation was successful
    public bool Success { get; }
    public string ? Error { get; }

    // Private constructor to enforce the use of static factory methods
    private Result(bool success, string ? error)
    {
        Success = success;
        Error = error;
    }

    // Static factory method to create a successful result
    public static Result Ok() => new Result(true, null);

    // Static factory method to create a failed result with an error message
    public static Result Fail(string error) => new Result(false, error);
}
