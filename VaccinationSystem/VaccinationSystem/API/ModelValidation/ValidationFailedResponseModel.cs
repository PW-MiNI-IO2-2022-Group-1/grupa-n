using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace VaccinationSystem.API.ModelValidation
{
    public class ValidationFailedResponseModel
    {
        public bool Success { get; } = false;
        public object[] Data { get; }

        public ValidationFailedResponseModel(ModelStateDictionary modelState)
        {
            // klucz - nazwa pola
            Data = modelState.Keys
                    .SelectMany(key => modelState[key].Errors
                        .Select(x => CreateErrorObject(key, x.ErrorMessage)))
                    .ToArray();
        }

        private object CreateErrorObject(string key, string message)
        {
            // chyba tylko w ten sposob z uzyciem domyslnego serializatora
            // zwrocimy odpowiednie nazwy kluczy odpowiadajace nazwom zle
            // zwalidowanych pol
            if (key.StartsWith("Address"))
            {
                return new
                {
                    address = message
                };
            }
            switch (key)
            {
                case "FirstName":
                    return new
                    {
                        firstName = message
                    };
                case "LastName":
                    return new
                    {
                        lastName = message
                    };
                case "Password":                
                    return new
                    {
                        password = message
                    };
                case "Email":
                    return new
                    {
                        email = message
                    };
                default:
                    throw new ArgumentException($"Validating unexpected field: {key}");
            }
        }
    }
}
