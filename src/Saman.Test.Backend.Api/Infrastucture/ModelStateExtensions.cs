using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Api.Infrastucture
{
    public static class ModelStateExtensions
    {
        public static Dictionary<string, string> ToDictionary(this ModelStateDictionary state)
        {
            return new Dictionary<string, string>(
                state.Select(x => new KeyValuePair<string, string>(
                    x.Key,
                    string.Join(Environment.NewLine, x.Value.Errors.Select(v => v.ErrorMessage))
                ))
            );
        }
    }
}
