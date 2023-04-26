using System.Collections.Generic;

namespace Course.API.Models
{
    public class ValidatesFieldViewModelOutput
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidatesFieldViewModelOutput(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}