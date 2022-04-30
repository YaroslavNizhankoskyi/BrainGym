using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Models
{
    public class AuthResult<T> : AuthResult
    {
        public AuthResult(T result)
        {
            Result = result;
        }

        public AuthResult(AuthResult authResult)
        {
            ErrorList = authResult.ErrorList;
        }

        public AuthResult()
        {

        }

        public static AuthResult<T> Error(string error)
        {
            var result = new AuthResult<T>();
            result.ErrorList.Add(error);
            return result;
        }

        public static AuthResult<T> Error(IEnumerable<string> errors)
        {
            var result = new AuthResult<T>();
            result.ErrorList.AddRange(errors);
            return result;
        }

        public T Result { get; set; }
    }

    public class AuthResult
    { 
        public bool Secceeded { get => !ErrorList.Any(); }

        public List<string> ErrorList { get; set; } = new List<string>();

        public AuthResult()
        {

        }

        public static AuthResult Error(string error)
        {
            var result = new AuthResult();
            result.ErrorList.Add(error);
            return result;
        }

        public static AuthResult Error(IEnumerable<string> errors)
        {
            var result = new AuthResult();
            result.ErrorList.AddRange(errors);
            return result;
        }
    }
}
