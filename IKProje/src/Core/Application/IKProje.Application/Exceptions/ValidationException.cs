﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Errors { get; set; }
    public ValidationException()
        : base("One or more validation failures have occurred")
    {
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}
